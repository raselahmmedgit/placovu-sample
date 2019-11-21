﻿namespace Nest
{
	public class IpAttribute : ElasticsearchDocValuesPropertyAttributeBase, IIpProperty
	{
		private IIpProperty Self => this;

		public IpAttribute() : base(FieldType.Ip) { }

		double? IIpProperty.Boost { get; set; }
		bool? IIpProperty.Index { get; set; }
		string IIpProperty.NullValue { get; set; }

		public double Boost { get { return Self.Boost.GetValueOrDefault(); } set { Self.Boost = value; } }
		public bool Index { get { return Self.Index.GetValueOrDefault(); } set { Self.Index = value; } }
		public string NullValue { get { return Self.NullValue; } set { Self.NullValue = value; } }

	}
}
