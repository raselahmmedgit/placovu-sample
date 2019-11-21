﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest
{
	/// <summary>
	/// Normalizers are similar to analyzers except that they may only emit a single token.
	/// As a consequence, they do not have a tokenizer and only accept a subset of the available
	/// char filters and token filters. Only the filters that work on a per-character basis are
	/// allowed. For instance a lowercasing filter would be allowed, but not a stemming filter,
	/// which needs to look at the keyword as a whole.
	/// <para>Elasticsearch does not ship with built-in normalizers so far, so the only way to create one is through composing a custom one</para>
	/// </summary>
	public interface ICustomNormalizer : INormalizer
	{
		/// <summary>
		/// Char filters to normalize the keyword
		/// </summary>
		[JsonProperty("char_filter")]
		IEnumerable<string> CharFilter { get; set; }

		/// <summary>
		/// An optional list of logical / registered name of token filters.
		/// </summary>
		[JsonProperty("filter")]
		IEnumerable<string> Filter { get; set; }
	}

	/// <inheritdoc/>
	public class CustomNormalizer : NormalizerBase, ICustomNormalizer
	{
		public CustomNormalizer() : base("custom") {}

		/// <inheritdoc/>
		public IEnumerable<string> Filter { get; set; }

		/// <inheritdoc/>
		public IEnumerable<string> CharFilter { get; set; }
	}

	/// <inheritdoc/>
	public class CustomNormalizerDescriptor
		: NormalizerDescriptorBase<CustomNormalizerDescriptor, ICustomNormalizer>, ICustomNormalizer
	{
		protected override string Type => "custom";

		IEnumerable<string> ICustomNormalizer.CharFilter { get; set; }
		IEnumerable<string> ICustomNormalizer.Filter { get; set; }
		/// <inheritdoc/>
		public CustomNormalizerDescriptor Filters(params string[] filters) => Assign(a => a.Filter = filters);

		/// <inheritdoc/>
		public CustomNormalizerDescriptor Filters(IEnumerable<string> filters) => Assign(a => a.Filter = filters);

		/// <inheritdoc/>
		public CustomNormalizerDescriptor CharFilters(params string[] charFilters) => Assign(a => a.CharFilter = charFilters);

		/// <inheritdoc/>
		public CustomNormalizerDescriptor CharFilters(IEnumerable<string> charFilters) => Assign(a => a.CharFilter = charFilters);

	}
}
