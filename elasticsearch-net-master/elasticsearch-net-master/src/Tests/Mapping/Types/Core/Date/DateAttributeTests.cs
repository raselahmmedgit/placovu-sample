﻿using System;
using Nest;

namespace Tests.Mapping.Types.Core.Date
{
	public class DateTest
	{
		[Date(
			DocValues = true,
			Similarity = "classic",
			Store = true,
			Index = false,
			Boost = 1.2,
			IgnoreMalformed = true,
			Format = "MM/dd/yyyy")]
		public DateTime Full { get; set; }

		[Date]
		public DateTime Minimal { get; set; }

		public DateTime Inferred { get; set; }

		public DateTimeOffset InferredOffset { get; set; }
	}

	public class DateAttributeTests : AttributeTestsBase<DateTest>
	{
		protected override object ExpectJson => new
		{
			properties = new
			{
				full = new
				{
					type = "date",
					doc_values = true,
					similarity = "classic",
					store = true,
					index = false,
					boost = 1.2,
					ignore_malformed = true,
					format = "MM/dd/yyyy"
				},
				minimal = new
				{
					type = "date"
				},
				inferred = new
				{
					type = "date"
				},
				inferredOffset = new
				{
					type = "date"
				}
			}
		};
	}
}
