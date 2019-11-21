﻿using System.Threading.Tasks;
using Nest;
using Tests.Framework;
using Tests.Framework.MockData;
using static Tests.Framework.UrlTester;

namespace Tests.Document.Multiple.ReindexRethrottle
{
	public class ReindexRethrottleUrlTests : IUrlTests
	{
		private readonly TaskId _taskId = "rhtoNesNR4aXVIY2bRR4GQ:13056";

		[U] public async Task Urls()
		{
			await POST($"/_reindex/{EscapeUriString(_taskId.ToString())}/_rethrottle")
				.Fluent(c => c.Rethrottle(f=>f.TaskId(_taskId)))
				.Request(c => c.Rethrottle(new ReindexRethrottleRequest(_taskId)))
				.FluentAsync(c => c.RethrottleAsync(f=>f.TaskId(_taskId)))
				.RequestAsync(c => c.RethrottleAsync(new ReindexRethrottleRequest(_taskId)))
				;

		}
	}
}
