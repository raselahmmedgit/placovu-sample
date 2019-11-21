﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace Elasticsearch.Net
{
	public class StickyConnectionPool : StaticConnectionPool
	{
		public StickyConnectionPool(IEnumerable<Uri> uris, IDateTimeProvider dateTimeProvider = null)
			: base(uris, false, dateTimeProvider)
		{ }

		public StickyConnectionPool(IEnumerable<Node> nodes, IDateTimeProvider dateTimeProvider = null)
			: base(nodes, false, dateTimeProvider)
		{ }

		public override IEnumerable<Node> CreateView(Action<AuditEvent, Node> audit = null)
		{
			var nodes = this.AliveNodes;

			if (nodes.Count == 0)
			{
				var globalCursor = Interlocked.Increment(ref this.GlobalCursor);

				//could not find a suitable node retrying on first node off globalCursor
				yield return this.RetryInternalNodes(globalCursor, audit);
				yield break;
			}

			// If the cursor is greater than the default then it's been
			// set already but we now have a live node so we should reset it
			if (this.GlobalCursor > -1)
				Interlocked.Exchange(ref this.GlobalCursor, -1);

			var localCursor = 0;
			foreach (var aliveNode in this.SelectAliveNodes(localCursor, nodes, audit))
				yield return aliveNode;
		}

		public override void Reseed(IEnumerable<Node> nodes) { }
	}
}
