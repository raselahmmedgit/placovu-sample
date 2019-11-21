﻿using System;
using System.Collections.Generic;
using System.Linq;
using Elasticsearch.Net;
using Newtonsoft.Json;

namespace Nest
{
	public interface ISearchResponse<T> : IResponse where T : class
	{
		/// <summary>
		/// Gets the meta data about the shards on which the search query was executed.
		/// </summary>
		ShardsMetaData Shards { get; }

		/// <summary>
		/// Gets the meta data about the hits that match the search query criteria.
		/// </summary>
		HitsMetaData<T> HitsMetaData { get; }

		/// <summary>
		/// Gets the collection of aggregations
		/// </summary>
		IReadOnlyDictionary<string, IAggregate> Aggregations { get; }

		/// <summary>
		/// Gets the results of profiling the search query. Has a value only when
		/// <see cref="ISearchRequest.Profile"/> is set to <c>true</c> on the search request.
		/// </summary>
		Profile Profile { get; }

		/// <summary>
		/// Gets the aggregations helper that can be used to more easily handle aggregation
		/// results.
		/// </summary>
		AggregationsHelper Aggs { get; }

		/// <summary>
		/// Gets the suggester results.
		/// </summary>
		IReadOnlyDictionary<string, Suggest<T>[]> Suggest { get; }

		/// <summary>
		/// Time in milliseconds for Elasticsearch to execute the search
		/// </summary>
		long Took { get; }

		/// <summary>
		/// Gets a value indicating whether the search timed out or not
		/// </summary>
		bool TimedOut { get; }

		/// <summary>
		/// Gets a value indicating whether the search was terminated early
		/// </summary>
		bool TerminatedEarly { get; }

		/// <summary>
		/// Gets the scroll id which can be passed to the Scroll API in order to retrieve the next batch
		/// of results. Has a value only when <see cref="SearchRequest{T}.Scroll"/> is specified on the
		/// search request
		/// </summary>
		string ScrollId { get; }

		/// <summary>
		/// Gets the total number of documents matching the search query criteria
		/// </summary>
		long Total { get; }

		/// <summary>
		/// Gets the maximum score for documents matching the search query criteria
		/// </summary>
		double MaxScore { get; }

		/// <summary>
		/// Number of times the server performed an incremental reduce phase
		/// </summary>
		long NumberOfReducePhases { get; }

		/// <summary>
		/// Gets the documents inside the hits, by deserializing <see cref="IHitMetadata{T}.Source"/> into T.
		/// <para>NOTE: if you use <see cref="ISearchRequest.StoredFields"/> on the search request,
		/// <see cref="Documents"/> will be empty and you should use <see cref="Fields"/>
		/// instead to get the field values. As an alternative to
		/// <see cref="Fields"/>, try source filtering using <see cref="ISearchRequest.Source"/> on the
		/// search request to return <see cref="Documents"/> with partial fields selected
		/// </para>
		/// </summary>
		IReadOnlyCollection<T> Documents { get; }

		/// <summary>
		/// Gets the collection of hits that matched the query
		/// </summary>
		/// <value>
		/// The hits.
		/// </value>
		IReadOnlyCollection<IHit<T>> Hits { get; }

		/// <summary>
		/// Gets the field values inside the hits, when the search request uses
		/// <see cref="SearchRequest{T}.StoredFields"/>.
		/// </summary>
		IReadOnlyCollection<FieldValues> Fields { get; }
	}

	[JsonObject]
	public class SearchResponse<T> : ResponseBase, ISearchResponse<T> where T : class
	{
		internal ServerError MultiSearchError { get; set; }
		protected override IApiCallDetails ApiCall => MultiSearchError != null ? new ApiCallDetailsOverride(base.ApiCall, MultiSearchError) : base.ApiCall;

		[JsonProperty(PropertyName = "_shards")]
		public ShardsMetaData Shards { get; internal set; }

		[JsonProperty(PropertyName = "aggregations")]
		[JsonConverter(typeof(VerbatimDictionaryKeysJsonConverter<string, IAggregate>))]
		public IReadOnlyDictionary<string, IAggregate> Aggregations { get; internal set; } = EmptyReadOnly<string, IAggregate>.Dictionary;

		[JsonProperty(PropertyName = "profile")]
		public Profile Profile { get; internal set; }

		private AggregationsHelper _agg;

		[JsonIgnore]
		public AggregationsHelper Aggs => _agg ?? (_agg = new AggregationsHelper(this.Aggregations));

		[JsonProperty(PropertyName = "suggest")]
		public IReadOnlyDictionary<string, Suggest<T>[]> Suggest { get; internal set; } =
			EmptyReadOnly<string, Suggest<T>[]>.Dictionary;

		[JsonProperty(PropertyName = "took")]
		public long Took { get; internal set; }

		[JsonProperty("timed_out")]
		public bool TimedOut { get; internal set; }

		[JsonProperty("terminated_early")]
		public bool TerminatedEarly { get; internal set; }

		/// <summary>
		/// Only set when search type = scan and scroll specified
		/// </summary>
		[JsonProperty(PropertyName = "_scroll_id")]
		public string ScrollId { get; internal set; }

		[JsonProperty(PropertyName = "hits")]
		public HitsMetaData<T> HitsMetaData { get; internal set; }

		[JsonProperty(PropertyName = "num_reduce_phases")]
		public long NumberOfReducePhases { get; internal set; }

		[JsonIgnore]
		public long Total => this.HitsMetaData?.Total ?? 0;

		[JsonIgnore]
		public double MaxScore => this.HitsMetaData?.MaxScore ?? 0;

		private IReadOnlyCollection<T> _documents;

		/// <inheritdoc/>
		[JsonIgnore]
		public IReadOnlyCollection<T> Documents =>
			this._documents ?? (this._documents = this.Hits
				.Select(h => h.Source)
				.ToList());

		private IReadOnlyCollection<IHit<T>> _hits;

		[JsonIgnore]
		public IReadOnlyCollection<IHit<T>> Hits =>
			this._hits ?? (this._hits = this.HitsMetaData?.Hits ?? EmptyReadOnly<IHit<T>>.Collection);

		private IReadOnlyCollection<FieldValues> _fields;

		/// <inheritdoc/>
		public IReadOnlyCollection<FieldValues> Fields =>
			this._fields ?? (this._fields = this.Hits
				.Select(h => h.Fields)
				.ToList());
	}
}
