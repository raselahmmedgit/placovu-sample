﻿using System;
using System.Linq.Expressions;

namespace Nest
{
	public static class Query<T> where T : class
	{
		public static QueryContainer Bool(Func<BoolQueryDescriptor<T>, IBoolQuery> selector) =>
			new QueryContainerDescriptor<T>().Bool(selector);

		public static QueryContainer Boosting(Func<BoostingQueryDescriptor<T>, IBoostingQuery> selector) =>
			new QueryContainerDescriptor<T>().Boosting(selector);

		public static QueryContainer CommonTerms(Func<CommonTermsQueryDescriptor<T>, ICommonTermsQuery> selector) =>
			new QueryContainerDescriptor<T>().CommonTerms(selector);

		public static QueryContainer Conditionless(Func<ConditionlessQueryDescriptor<T>, IConditionlessQuery> selector) =>
			new QueryContainerDescriptor<T>().Conditionless(selector);

		public static QueryContainer ConstantScore(Func<ConstantScoreQueryDescriptor<T>, IConstantScoreQuery> selector) =>
			new QueryContainerDescriptor<T>().ConstantScore(selector);

		public static QueryContainer DateRange(Func<DateRangeQueryDescriptor<T>, IDateRangeQuery> selector) =>
			new QueryContainerDescriptor<T>().DateRange(selector);

		public static QueryContainer DisMax(Func<DisMaxQueryDescriptor<T>, IDisMaxQuery> selector) =>
			new QueryContainerDescriptor<T>().DisMax(selector);

		public static QueryContainer Exists(Func<ExistsQueryDescriptor<T>, IExistsQuery> selector) =>
			new QueryContainerDescriptor<T>().Exists(selector);

		public static QueryContainer FunctionScore(Func<FunctionScoreQueryDescriptor<T>, IFunctionScoreQuery> selector) =>
			new QueryContainerDescriptor<T>().FunctionScore(selector);

		public static QueryContainer Fuzzy(Func<FuzzyQueryDescriptor<T>, IFuzzyQuery> selector) =>
			new QueryContainerDescriptor<T>().Fuzzy(selector);

		public static QueryContainer GeoBoundingBox(Func<GeoBoundingBoxQueryDescriptor<T>, IGeoBoundingBoxQuery> selector) =>
			new QueryContainerDescriptor<T>().GeoBoundingBox(selector);

		public static QueryContainer GeoDistance(Func<GeoDistanceQueryDescriptor<T>, IGeoDistanceQuery> selector) =>
			new QueryContainerDescriptor<T>().GeoDistance(selector);

		public static QueryContainer GeoHashCell(Func<GeoHashCellQueryDescriptor<T>, IGeoHashCellQuery> selector) =>
			new QueryContainerDescriptor<T>().GeoHashCell(selector);

		public static QueryContainer GeoPolygon(Func<GeoPolygonQueryDescriptor<T>, IGeoPolygonQuery> selector) =>
			new QueryContainerDescriptor<T>().GeoPolygon(selector);

		public static QueryContainer GeoShapeCircle(Func<GeoShapeCircleQueryDescriptor<T>, IGeoShapeCircleQuery> selector) =>
			new QueryContainerDescriptor<T>().GeoShapeCircle(selector);

		public static QueryContainer GeoShapeEnvelope(Func<GeoShapeEnvelopeQueryDescriptor<T>, IGeoShapeEnvelopeQuery> selector) =>
			new QueryContainerDescriptor<T>().GeoShapeEnvelope(selector);

		public static QueryContainer GeoShapeLineString(Func<GeoShapeLineStringQueryDescriptor<T>, IGeoShapeLineStringQuery> selector) =>
			new QueryContainerDescriptor<T>().GeoShapeLineString(selector);

		public static QueryContainer GeoShapeMultiLineString(Func<GeoShapeMultiLineStringQueryDescriptor<T>, IGeoShapeMultiLineStringQuery> selector) =>
			new QueryContainerDescriptor<T>().GeoShapeMultiLineString(selector);

		public static QueryContainer GeoShapeMultiPoint(Func<GeoShapeMultiPointQueryDescriptor<T>, IGeoShapeMultiPointQuery> selector) =>
			new QueryContainerDescriptor<T>().GeoShapeMultiPoint(selector);

		public static QueryContainer GeoShapeMultiPolygon(Func<GeoShapeMultiPolygonQueryDescriptor<T>, IGeoShapeMultiPolygonQuery> selector) =>
			new QueryContainerDescriptor<T>().GeoShapeMultiPolygon(selector);

		public static QueryContainer GeoShapePoint(Func<GeoShapePointQueryDescriptor<T>, IGeoShapePointQuery> selector) =>
			new QueryContainerDescriptor<T>().GeoShapePoint(selector);

		public static QueryContainer GeoShapePolygon(Func<GeoShapePolygonQueryDescriptor<T>, IGeoShapePolygonQuery> selector) =>
			new QueryContainerDescriptor<T>().GeoShapePolygon(selector);

		public static QueryContainer GeoShapeGeometryCollection(Func<GeoShapeGeometryCollectionQueryDescriptor<T>, IGeoShapeGeometryCollectionQuery> selector) =>
			new QueryContainerDescriptor<T>().GeoShapeGeometryCollection(selector);

		public static QueryContainer HasChild<TChild>(Func<HasChildQueryDescriptor<TChild>, IHasChildQuery> selector) where TChild : class =>
			new QueryContainerDescriptor<T>().HasChild<TChild>(selector);

		public static QueryContainer HasParent<TParent>(Func<HasParentQueryDescriptor<TParent>, IHasParentQuery> selector) where TParent : class =>
			new QueryContainerDescriptor<T>().HasParent<TParent>(selector);

		public static QueryContainer Ids(Func<IdsQueryDescriptor, IIdsQuery> selector) =>
			new QueryContainerDescriptor<T>().Ids(selector);

		[Obsolete("Deprecated. You can specify _index on the query to target specific indices")]
		public static QueryContainer Indices(Func<IndicesQueryDescriptor<T>, IIndicesQuery> selector) =>
			new QueryContainerDescriptor<T>().Indices(selector);

		public static QueryContainer Match(Func<MatchQueryDescriptor<T>, IMatchQuery> selector) =>
			new QueryContainerDescriptor<T>().Match(selector);

		public static QueryContainer MatchAll(Func<MatchAllQueryDescriptor, IMatchAllQuery> selector = null) =>
			new QueryContainerDescriptor<T>().MatchAll(selector);

		public static QueryContainer MatchNone(Func<MatchNoneQueryDescriptor, IMatchNoneQuery> selector = null) =>
			new QueryContainerDescriptor<T>().MatchNone(selector);

		public static QueryContainer MatchPhrase(Func<MatchPhraseQueryDescriptor<T>, IMatchPhraseQuery> selector) =>
			new QueryContainerDescriptor<T>().MatchPhrase(selector);

		public static QueryContainer MatchPhrasePrefix(Func<MatchPhrasePrefixQueryDescriptor<T>, IMatchPhrasePrefixQuery> selector) =>
			new QueryContainerDescriptor<T>().MatchPhrasePrefix(selector);

		public static QueryContainer MoreLikeThis(Func<MoreLikeThisQueryDescriptor<T>, IMoreLikeThisQuery> selector) =>
			new QueryContainerDescriptor<T>().MoreLikeThis(selector);

		public static QueryContainer MultiMatch(Func<MultiMatchQueryDescriptor<T>, IMultiMatchQuery> selector) =>
			new QueryContainerDescriptor<T>().MultiMatch(selector);

		public static QueryContainer Nested(Func<NestedQueryDescriptor<T>, INestedQuery> selector) =>
			new QueryContainerDescriptor<T>().Nested(selector);

		public static QueryContainer ParentId(Func<ParentIdQueryDescriptor<T>, IParentIdQuery> selector) =>
			new QueryContainerDescriptor<T>().ParentId(selector);

		public static QueryContainer Percolate(Func<PercolateQueryDescriptor<T>, IPercolateQuery> selector) =>
			new QueryContainerDescriptor<T>().Percolate(selector);

		public static QueryContainer Prefix(Expression<Func<T, object>> fieldDescriptor, string value, double? boost = null, MultiTermQueryRewrite rewrite = null, string name = null) =>
			new QueryContainerDescriptor<T>().Prefix(fieldDescriptor, value, boost, rewrite, name);

		public static QueryContainer Prefix(Field field, string value, double? boost = null, MultiTermQueryRewrite rewrite = null, string name = null) =>
			new QueryContainerDescriptor<T>().Prefix(field, value, boost, rewrite, name);

		public static QueryContainer Prefix(Func<PrefixQueryDescriptor<T>, IPrefixQuery> selector) =>
			new QueryContainerDescriptor<T>().Prefix(selector);

		public static QueryContainer QueryString(Func<QueryStringQueryDescriptor<T>, IQueryStringQuery> selector) =>
			new QueryContainerDescriptor<T>().QueryString(selector);

		public static QueryContainer Range(Func<NumericRangeQueryDescriptor<T>, INumericRangeQuery> selector) =>
			new QueryContainerDescriptor<T>().Range(selector);

		public static QueryContainer Regexp(Func<RegexpQueryDescriptor<T>, IRegexpQuery> selector) =>
			new QueryContainerDescriptor<T>().Regexp(selector);

		public static QueryContainer Script(Func<ScriptQueryDescriptor<T>, IScriptQuery> selector) =>
			new QueryContainerDescriptor<T>().Script(selector);

		public static QueryContainer SimpleQueryString(Func<SimpleQueryStringQueryDescriptor<T>, ISimpleQueryStringQuery> selector) =>
			new QueryContainerDescriptor<T>().SimpleQueryString(selector);

		public static QueryContainer SpanContaining(Func<SpanContainingQueryDescriptor<T>, ISpanContainingQuery> selector) =>
			new QueryContainerDescriptor<T>().SpanContaining(selector);

		public static QueryContainer SpanFirst(Func<SpanFirstQueryDescriptor<T>, ISpanFirstQuery> selector) =>
			new QueryContainerDescriptor<T>().SpanFirst(selector);

		public static QueryContainer SpanMultiTerm(Func<SpanMultiTermQueryDescriptor<T>, ISpanMultiTermQuery> selector) =>
			new QueryContainerDescriptor<T>().SpanMultiTerm(selector);

		public static QueryContainer SpanNear(Func<SpanNearQueryDescriptor<T>, ISpanNearQuery> selector) =>
			new QueryContainerDescriptor<T>().SpanNear(selector);

		public static QueryContainer SpanNot(Func<SpanNotQueryDescriptor<T>, ISpanNotQuery> selector) =>
			new QueryContainerDescriptor<T>().SpanNot(selector);

		public static QueryContainer SpanOr(Func<SpanOrQueryDescriptor<T>, ISpanOrQuery> selector) =>
			new QueryContainerDescriptor<T>().SpanOr(selector);

		public static QueryContainer SpanTerm(Func<SpanTermQueryDescriptor<T>, ISpanTermQuery> selector) =>
			new QueryContainerDescriptor<T>().SpanTerm(selector);

		public static QueryContainer SpanWithin(Func<SpanWithinQueryDescriptor<T>, ISpanWithinQuery> selector) =>
			new QueryContainerDescriptor<T>().SpanWithin(selector);

		public static QueryContainer SpanFieldMasking(Func<SpanFieldMaskingQueryDescriptor<T>, ISpanFieldMaskingQuery> selector) =>
			new QueryContainerDescriptor<T>().SpanFieldMasking(selector);

		[Obsolete("Deprecated in 5.0.0. Use Search Template API instead")]
		public static QueryContainer Template(Func<TemplateQueryDescriptor<T>, ITemplateQuery> selector) =>
			new QueryContainerDescriptor<T>().Template(selector);

		public static QueryContainer Term(Expression<Func<T, object>> fieldDescriptor, object value, double? boost = null, string name = null) =>
			new QueryContainerDescriptor<T>().Term(fieldDescriptor, value, boost, name);

		public static QueryContainer Term(Field field, object value, double? boost = null, string name = null) =>
			new QueryContainerDescriptor<T>().Term(field, value, boost, name);

		public static QueryContainer Term(Func<TermQueryDescriptor<T>, ITermQuery> selector) =>
			new QueryContainerDescriptor<T>().Term(selector);

		public static QueryContainer TermRange(Func<TermRangeQueryDescriptor<T>, ITermRangeQuery> selector) =>
			new QueryContainerDescriptor<T>().TermRange(selector);

		public static QueryContainer Terms(Func<TermsQueryDescriptor<T>, ITermsQuery> selector) =>
			new QueryContainerDescriptor<T>().Terms(selector);

		public static QueryContainer Type(Func<TypeQueryDescriptor, ITypeQuery> selector) =>
			new QueryContainerDescriptor<T>().Type(selector);

		public static QueryContainer Type<TOther>() => Type(q => q.Value<TOther>());

		public static QueryContainer Wildcard(Expression<Func<T, object>> fieldDescriptor, string value, double? boost = null, MultiTermQueryRewrite rewrite = null, string name = null) =>
			new QueryContainerDescriptor<T>().Wildcard(fieldDescriptor, value, boost, rewrite, name);

		public static QueryContainer Wildcard(Field field, string value, double? boost = null, MultiTermQueryRewrite rewrite = null, string name = null) =>
			new QueryContainerDescriptor<T>().Wildcard(field, value, boost, rewrite, name);

		public static QueryContainer Wildcard(Func<WildcardQueryDescriptor<T>, IWildcardQuery> selector) =>
			new QueryContainerDescriptor<T>().Wildcard(selector);
	}
}
