﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[JsonConverter(typeof (VariableFieldNameQueryJsonConverter<GeoPolygonQuery, IGeoPolygonQuery>))]
	public interface IGeoPolygonQuery : IFieldNameQuery
	{
		[VariableField("points")]
		IEnumerable<GeoLocation> Points { get; set; }

		[JsonProperty("validation_method")]
		GeoValidationMethod? ValidationMethod { get; set; }

	}

	public class GeoPolygonQuery : FieldNameQueryBase, IGeoPolygonQuery
	{
		protected override bool Conditionless => IsConditionless(this);
		public IEnumerable<GeoLocation> Points { get; set; }

		public GeoValidationMethod? ValidationMethod { get; set; }

		internal override void InternalWrapInContainer(IQueryContainer c) => c.GeoPolygon = this;
		internal static bool IsConditionless(IGeoPolygonQuery q) => q.Field == null || !q.Points.HasAny();
	}

	public class GeoPolygonQueryDescriptor<T>
		: FieldNameQueryDescriptorBase<GeoPolygonQueryDescriptor<T>, IGeoPolygonQuery, T>
		, IGeoPolygonQuery where T : class
	{
		protected override bool Conditionless => GeoPolygonQuery.IsConditionless(this);
		IEnumerable<GeoLocation> IGeoPolygonQuery.Points { get; set; }
		GeoValidationMethod? IGeoPolygonQuery.ValidationMethod { get; set; }

		public GeoPolygonQueryDescriptor<T> Points(IEnumerable<GeoLocation> points) => Assign(a => a.Points = points);

		public GeoPolygonQueryDescriptor<T> Points(params GeoLocation[] points) => Assign(a => a.Points = points);

		public GeoPolygonQueryDescriptor<T> ValidationMethod(GeoValidationMethod? validation) => Assign(a => a.ValidationMethod = validation);
	}
}
