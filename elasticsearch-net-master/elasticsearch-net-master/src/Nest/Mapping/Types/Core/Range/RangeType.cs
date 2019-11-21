﻿using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum RangeType
	{
		/// <summary>
		/// A range of signed 32-bit integers with a minimum value of -231 and maximum of 231-1.
		/// </summary>
		[EnumMember(Value = "integer_range")]
		IntegerRange,
		/// <summary>
		/// A range of single-precision 32-bit IEEE 754 floating point values.
		/// </summary>
		[EnumMember(Value = "float_range")]
		FloatRange,
		/// <summary>
		/// A range of signed 64-bit integers with a minimum value of -263 and maximum of 263-1.
		/// </summary>
		[EnumMember(Value = "long_range")]
		LongRange,
		/// <summary>
		/// A range of double-precision 64-bit IEEE 754 floating point values.
		/// </summary>
		[EnumMember(Value = "double_range")]
		DoubleRange,
		/// <summary>
		/// A range of date values represented as unsigned 64-bit integer milliseconds elapsed since system epoch.
		/// </summary>
		[EnumMember(Value = "date_range")]
		DateRange
	}
	internal static class RangeTypeExtensions
	{
		public static FieldType ToFieldType(this RangeType rangeType)
		{
			switch (rangeType)
			{
				case RangeType.IntegerRange: return FieldType.IntegerRange;
				case RangeType.FloatRange: return FieldType.FloatRange;
				case RangeType.LongRange: return FieldType.LongRange;
				case RangeType.DoubleRange: return FieldType.DoubleRange;
				case RangeType.DateRange: return FieldType.DateRange;
				default:
					throw new ArgumentOutOfRangeException(nameof(rangeType), rangeType, null);
			}

		}
	}
}
