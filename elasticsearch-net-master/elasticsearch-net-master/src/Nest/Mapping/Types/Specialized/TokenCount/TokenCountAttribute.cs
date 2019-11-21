﻿using System;

namespace Nest
{
	public class TokenCountAttribute : ElasticsearchDocValuesPropertyAttributeBase, ITokenCountProperty
	{
		private ITokenCountProperty Self => this;

		public TokenCountAttribute() : base(FieldType.TokenCount) { }

		string ITokenCountProperty.Analyzer { get; set; }
		bool? ITokenCountProperty.Index { get; set; }
		double? ITokenCountProperty.Boost { get; set; }
		double? ITokenCountProperty.NullValue { get; set; }

		public string Analyzer { get { return Self.Analyzer; } set { Self.Analyzer = value; } }
		public bool Index { get { return Self.Index.GetValueOrDefault(); } set { Self.Index = value; } }
		public double Boost { get { return Self.Boost.GetValueOrDefault(); } set { Self.Boost = value; } }
		public double NullValue { get { return Self.NullValue.GetValueOrDefault(); } set { Self.NullValue = value; } }

	}
}
