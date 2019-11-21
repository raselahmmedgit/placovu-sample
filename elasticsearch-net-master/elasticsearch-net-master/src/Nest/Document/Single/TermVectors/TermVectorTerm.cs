﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject]
	public class TermVectorTerm
	{
		[JsonProperty("doc_freq")]
		public int DocumentFrequency { get; internal set; }

		[JsonProperty("term_freq")]
		public int TermFrequency { get; internal set; }

		[JsonProperty("tokens")]
		public IReadOnlyCollection<Token> Tokens { get; internal set; } =
			EmptyReadOnly<Token>.Collection;

		[JsonProperty("ttf")]
		public int TotalTermFrequency { get; internal set; }
	}
}
