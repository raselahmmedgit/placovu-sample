﻿using Elasticsearch.Net;

namespace Nest
{
	/// <summary>
	/// Maps a property as a number type. If no type is specified,
	/// the default type is float (single precision floating point).
	/// </summary>
	public class NumberAttribute : ElasticsearchDocValuesPropertyAttributeBase, INumberProperty
	{
		private INumberProperty Self => this;

		public NumberAttribute() : base(FieldType.Float) { }
		public NumberAttribute(NumberType type) : base(type.ToFieldType()) { }
#pragma warning disable 618
		protected NumberAttribute(string type) : base(type) { }
#pragma warning restore 618

		bool? INumberProperty.Index { get; set; }
		double? INumberProperty.Boost { get; set; }
		double? INumberProperty.NullValue { get; set; }
		bool? INumberProperty.IgnoreMalformed { get; set; }
		bool? INumberProperty.Coerce { get; set; }
		INumericFielddata INumberProperty.Fielddata { get; set; }
		double? INumberProperty.ScalingFactor { get; set; }

		public bool Index { get { return Self.Index.GetValueOrDefault(); } set { Self.Index = value; } }
		public double Boost { get { return Self.Boost.GetValueOrDefault(); } set { Self.Boost = value; } }
		public double NullValue { get { return Self.NullValue.GetValueOrDefault(); } set { Self.NullValue = value; } }
		public bool IgnoreMalformed { get { return Self.IgnoreMalformed.GetValueOrDefault(); } set { Self.IgnoreMalformed = value; } }
		public bool Coerce { get { return Self.Coerce.GetValueOrDefault(); } set { Self.Coerce = value; } }
		public double ScalingFactor { get { return Self.ScalingFactor.GetValueOrDefault(); } set { Self.ScalingFactor = value; } }

	}
}
