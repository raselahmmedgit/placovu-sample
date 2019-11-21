﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Nest
{
	[JsonConverter(typeof(VerbatimDictionaryKeysJsonConverter<Normalizers, string, INormalizer>))]
	public interface INormalizers : IIsADictionary<string, INormalizer> { }

	public class Normalizers : IsADictionaryBase<string, INormalizer>, INormalizers
	{
		public Normalizers() {}
		public Normalizers(IDictionary<string, INormalizer> container) : base(container) { }
		public Normalizers(Dictionary<string, INormalizer> container)
			: base(container.ToDictionary(kv => kv.Key, kv => kv.Value))
		{ }

		public void Add(string name, INormalizer analyzer) => BackingDictionary.Add(name, analyzer);
	}

	public class NormalizersDescriptor : IsADictionaryDescriptorBase<NormalizersDescriptor, INormalizers, string, INormalizer>
	{
		public NormalizersDescriptor() : base(new Normalizers()) { }

		public NormalizersDescriptor UserDefined(string name, INormalizer analyzer) => Assign(name, analyzer);

		/// <summary>
		/// Elasticsearch does not ship with built-in normalizers so far, so the only way to
		/// get one is by building a custom one. Custom normalizers take a list of char character
		/// filters and a list of token filters.
		/// </summary>
		public NormalizersDescriptor Custom(string name, Func<CustomNormalizerDescriptor, ICustomNormalizer> selector) =>
			Assign(name, selector?.Invoke(new CustomNormalizerDescriptor()));
	}
}
