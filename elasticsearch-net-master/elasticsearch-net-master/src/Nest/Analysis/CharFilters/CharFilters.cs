﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Nest
{
	[JsonConverter(typeof(VerbatimDictionaryKeysJsonConverter<CharFilters, string, ICharFilter>))]
	public interface ICharFilters : IIsADictionary<string, ICharFilter> { }

	public class CharFilters : IsADictionaryBase<string, ICharFilter>, ICharFilters
	{
		public CharFilters() {}
		public CharFilters(IDictionary<string, ICharFilter> container) : base(container) { }
		public CharFilters(Dictionary<string, ICharFilter> container)
			: base(container.Select(kv => kv).ToDictionary(kv => kv.Key, kv => kv.Value))
		{}

		public void Add(string name, ICharFilter analyzer) => BackingDictionary.Add(name, analyzer);
	}

	public class CharFiltersDescriptor : IsADictionaryDescriptorBase<CharFiltersDescriptor, ICharFilters, string, ICharFilter>
	{
		public CharFiltersDescriptor() : base(new CharFilters()) { }

		public CharFiltersDescriptor UserDefined(string name, ICharFilter analyzer) => Assign(name, analyzer);

		/// <summary>
		/// The pattern_replace char filter allows the use of a regex to manipulate the characters in a string before analysis.
		/// </summary>
		public CharFiltersDescriptor PatternReplace(string name, Func<PatternReplaceCharFilterDescriptor, IPatternReplaceCharFilter> selector) =>
			Assign(name, selector?.Invoke(new PatternReplaceCharFilterDescriptor()));

		/// <summary>
		/// A char filter of type html_strip stripping out HTML elements from an analyzed text.
		/// </summary>
		public CharFiltersDescriptor HtmlStrip(string name, Func<HtmlStripCharFilterDescriptor, IHtmlStripCharFilter> selector = null) =>
			Assign(name, selector.InvokeOrDefault(new HtmlStripCharFilterDescriptor()));

		/// <summary>
		/// A char filter of type mapping replacing characters of an analyzed text with given mapping.
		/// </summary>
		public CharFiltersDescriptor Mapping(string name, Func<MappingCharFilterDescriptor, IMappingCharFilter> selector) =>
			Assign(name, selector?.Invoke(new MappingCharFilterDescriptor()));

		/// <summary>
		/// The kuromoji_iteration_mark normalizes Japanese horizontal iteration marks (odoriji) to their expanded form.
		/// Part of the `analysis-kuromoji` plugin: https://www.elastic.co/guide/en/elasticsearch/plugins/current/analysis-kuromoji.html
		/// </summary>
		public CharFiltersDescriptor KuromojiIterationMark(string name, Func<KuromojiIterationMarkCharFilterDescriptor, IKuromojiIterationMarkCharFilter> selector = null) =>
			Assign(name, selector?.InvokeOrDefault(new KuromojiIterationMarkCharFilterDescriptor()));

		/// <summary>
		/// Normalizes as defined here: http://userguide.icu-project.org/transforms/normalization
		/// Part of the `analysis-icu` plugin: https://www.elastic.co/guide/en/elasticsearch/plugins/current/analysis-icu.html
		/// </summary>
		public CharFiltersDescriptor IcuNormalization(string name, Func<IcuNormalizationCharFilterDescriptor, IIcuNormalizationCharFilter> selector) =>
			Assign(name, selector?.Invoke(new IcuNormalizationCharFilterDescriptor()));
	}
}
