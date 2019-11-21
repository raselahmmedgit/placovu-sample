﻿using Newtonsoft.Json;

namespace Nest
{
	[JsonObject]
	public class SearchStats
	{
		[JsonProperty(PropertyName = "open_contexts")]
		public long OpenContexts { get; set; }

		[JsonProperty(PropertyName = "fetch_current")]
		public long FetchCurrent { get; set; }

		[JsonProperty(PropertyName = "fetch_time_in_millis")]
		public long FetchTimeInMilliseconds { get; set; }

		[JsonProperty(PropertyName = "fetch_total")]
		public long FetchTotal { get; set; }

		[JsonProperty(PropertyName = "query_current")]
		public long QueryCurrent { get; set; }

		[JsonProperty(PropertyName = "query_time_in_millis")]
		public long QueryTimeInMilliseconds { get; set; }

		[JsonProperty(PropertyName = "query_total")]
		public long QueryTotal { get; set; }

		[JsonProperty(PropertyName = "scroll_current")]
		public long ScrollCurrent { get; set; }

		[JsonProperty(PropertyName = "scroll_time_in_millis")]
		public long ScrollTimeInMilliseconds { get; set; }

		[JsonProperty(PropertyName = "scroll_total")]
		public long ScrollTotal { get; set; }

		[JsonProperty(PropertyName = "suggest_current")]
		public long SuggestCurrent { get; set; }

		[JsonProperty(PropertyName = "suggest_time_in_millis")]
		public long SuggestTimeInMilliseconds { get; set; }

		[JsonProperty(PropertyName = "suggest_total")]
		public long SuggestTotal { get; set; }
	}
}
