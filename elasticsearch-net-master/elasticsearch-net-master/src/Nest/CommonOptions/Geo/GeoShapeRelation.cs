﻿using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nest
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum GeoShapeRelation
	{
		[EnumMember(Value = "intersects")]
		Intersects,
		[EnumMember(Value = "disjoint")]
		Disjoint,
		[EnumMember(Value = "within")]
		Within,
		[EnumMember(Value = "contains")]
		Contains
	}
}
