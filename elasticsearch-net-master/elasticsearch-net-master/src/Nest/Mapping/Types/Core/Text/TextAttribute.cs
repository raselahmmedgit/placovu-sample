﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
	public class TextAttribute : ElasticsearchCorePropertyAttributeBase, ITextProperty
	{
		private ITextProperty Self => this;

		public TextAttribute() : base(FieldType.Text) { }

		string ITextProperty.Analyzer { get; set; }
		double? ITextProperty.Boost { get; set; }
		bool? ITextProperty.EagerGlobalOrdinals { get; set; }
		bool? ITextProperty.Fielddata { get; set; }
		IFielddataFrequencyFilter ITextProperty.FielddataFrequencyFilter { get; set; }
		bool? ITextProperty.Index { get; set; }
		IndexOptions? ITextProperty.IndexOptions { get; set; }
		bool? ITextProperty.Norms { get; set; }
		int? ITextProperty.PositionIncrementGap { get; set; }
		string ITextProperty.SearchAnalyzer { get; set; }
		string ITextProperty.SearchQuoteAnalyzer { get; set; }
		TermVectorOption? ITextProperty.TermVector { get; set; }

		public string Analyzer { get { return Self.Analyzer; } set { Self.Analyzer = value; } }
		public double Boost { get { return Self.Boost.GetValueOrDefault(); } set { Self.Boost = value; } }
		public bool EagerGlobalOrdinals { get { return Self.EagerGlobalOrdinals.GetValueOrDefault(); } set { Self.EagerGlobalOrdinals = value; } }
		public bool Fielddata { get { return Self.Fielddata.GetValueOrDefault(); } set { Self.Fielddata = value; } }
		public bool Index { get { return Self.Index.GetValueOrDefault(); } set { Self.Index = value; } }
		public IndexOptions IndexOptions { get { return Self.IndexOptions.GetValueOrDefault(); } set { Self.IndexOptions = value; } }
		public int PositionIncrementGap { get { return Self.PositionIncrementGap.GetValueOrDefault(); } set { Self.PositionIncrementGap = value; } }
		public string SearchAnalyzer { get { return Self.SearchAnalyzer; } set { Self.SearchAnalyzer = value; } }
		public string SearchQuoteAnalyzer { get { return Self.SearchQuoteAnalyzer; } set { Self.SearchQuoteAnalyzer = value; } }
		public bool Norms { get { return Self.Norms.GetValueOrDefault(true); } set { Self.Norms = value; } }
		public TermVectorOption TermVector { get { return Self.TermVector.GetValueOrDefault();  } set { Self.TermVector = value; } }

	}
}
