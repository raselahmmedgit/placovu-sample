﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
	public class KeywordAttribute : ElasticsearchDocValuesPropertyAttributeBase, IKeywordProperty
	{
		private IKeywordProperty Self => this;

		public KeywordAttribute() : base(FieldType.Keyword) { }

		double? IKeywordProperty.Boost { get; set; }
		bool? IKeywordProperty.EagerGlobalOrdinals { get; set; }
		int? IKeywordProperty.IgnoreAbove { get; set; }
		bool? IKeywordProperty.Index { get; set; }
		IndexOptions? IKeywordProperty.IndexOptions { get; set; }
		bool? IKeywordProperty.Norms { get; set; }
		string IKeywordProperty.NullValue { get; set; }
		string IKeywordProperty.Normalizer { get; set; }

		public double Boost { get { return Self.Boost.GetValueOrDefault(); } set { Self.Boost = value; } }
		public bool EagerGlobalOrdinals { get { return Self.EagerGlobalOrdinals.GetValueOrDefault(); } set { Self.EagerGlobalOrdinals = value; } }
		public int IgnoreAbove { get { return Self.IgnoreAbove.GetValueOrDefault(); } set { Self.IgnoreAbove = value; } }
		public bool Index { get { return Self.Index.GetValueOrDefault(); } set { Self.Index = value; } }
		public IndexOptions IndexOptions { get { return Self.IndexOptions.GetValueOrDefault(); } set { Self.IndexOptions = value; } }
		public string NullValue { get { return Self.NullValue; } set { Self.NullValue = value; } }
		public bool Norms { get { return Self.Norms.GetValueOrDefault(true); } set { Self.Norms = value; } }
		public string Normalizer { get { return Self.Normalizer; } set { Self.Normalizer = value; } }

	}
}
