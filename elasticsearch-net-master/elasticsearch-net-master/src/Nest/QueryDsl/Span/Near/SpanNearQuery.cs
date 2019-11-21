﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof(ReadAsTypeJsonConverter<SpanNearQueryDescriptor<object>>))]
	public interface ISpanNearQuery : ISpanSubQuery
	{
		[JsonProperty(PropertyName = "clauses")]
		IEnumerable<ISpanQuery> Clauses { get; set; }

		[JsonProperty(PropertyName = "slop")]
		int? Slop { get; set; }

		[JsonProperty(PropertyName = "in_order")]
		bool? InOrder { get; set; }

#pragma warning disable 618
		[JsonProperty(PropertyName = "collect_payloads")]
		[Obsolete("Payloads will be loaded when needed")]
		bool? CollectPayloads { get; set; }
#pragma warning restore 618
	}

	public class SpanNearQuery : QueryBase, ISpanNearQuery
	{
		protected override bool Conditionless => SpanNearQuery.IsConditionless(this);
		public IEnumerable<ISpanQuery> Clauses { get; set; }
		public int? Slop { get; set; }
		public bool? InOrder { get; set; }

#pragma warning disable 618
		[Obsolete("Payloads will be loaded when needed")]
		public bool? CollectPayloads { get; set; }
#pragma warning restore 618

		internal override void InternalWrapInContainer(IQueryContainer c) => c.SpanNear = this;
		internal static bool IsConditionless(ISpanNearQuery q) => !q.Clauses.HasAny() || q.Clauses.Cast<IQuery>().All(qq => qq.Conditionless);
	}

	public class SpanNearQueryDescriptor<T>
		: QueryDescriptorBase<SpanNearQueryDescriptor<T>, ISpanNearQuery>
		, ISpanNearQuery where T : class
	{
		protected override bool Conditionless => SpanNearQuery.IsConditionless(this);
		IEnumerable<ISpanQuery> ISpanNearQuery.Clauses { get; set; }
		int? ISpanNearQuery.Slop { get; set; }
		bool? ISpanNearQuery.InOrder { get; set; }

#pragma warning disable 618
		[Obsolete("Payloads will be loaded when needed")]
		bool? ISpanNearQuery.CollectPayloads { get; set; }
#pragma warning restore 618

		public SpanNearQueryDescriptor<T> Clauses(params Func<SpanQueryDescriptor<T>, SpanQueryDescriptor<T>>[] selectors) => Clauses(selectors.ToList());

		public SpanNearQueryDescriptor<T> Clauses(IEnumerable<Func<SpanQueryDescriptor<T>, SpanQueryDescriptor<T>>> selectors) => Assign(a =>
		{
			a.Clauses = selectors.Select(selector => selector?.Invoke(new SpanQueryDescriptor<T>()))
				.Where(query => query != null && !((IQuery) query).Conditionless).ToListOrNullIfEmpty();
		});

		public SpanNearQueryDescriptor<T> Slop(int? slop) => Assign(a => a.Slop = slop);

		public SpanNearQueryDescriptor<T> InOrder(bool? inOrder = false) => Assign(a => a.InOrder = inOrder);

#pragma warning disable 618
		[Obsolete("Payloads will be loaded when needed")]
		public SpanNearQueryDescriptor<T> CollectPayloads(bool? collectPayloads = false) => Assign(a => a.CollectPayloads = collectPayloads);
#pragma warning restore 618
	}
}
