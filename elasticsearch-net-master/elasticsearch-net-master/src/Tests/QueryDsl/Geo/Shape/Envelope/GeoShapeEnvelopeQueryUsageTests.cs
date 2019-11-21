﻿using System.Collections.Generic;
using Nest;
using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch.Clusters;
using Tests.Framework.MockData;
using static Nest.Infer;

namespace Tests.QueryDsl.Geo.Shape.Envelope
{
	public class GeoShapeEnvelopeQueryUsageTests : GeoShapeQueryUsageTestsBase
	{
		public GeoShapeEnvelopeQueryUsageTests(ReadOnlyCluster i, EndpointUsage usage) : base(i, usage) { }

		private readonly IEnumerable<GeoCoordinate> _coordinates = new GeoCoordinate[]
		{
			new [] { -45.0, 45.0 },
			new [] { 45.0, -45.0 }
		};

		protected override object ShapeJson => new
		{
			type ="envelope",
			coordinates = this._coordinates
		};

		protected override QueryContainer QueryInitializer => new GeoShapeEnvelopeQuery
		{
			Name = "named_query",
			Boost = 1.1,
			Field = Field<Project>(p=>p.Location),
			Shape = new EnvelopeGeoShape(this._coordinates),
			Relation = GeoShapeRelation.Intersects,
			IgnoreUnmapped = false
		};

		protected override QueryContainer QueryFluent(QueryContainerDescriptor<Project> q) => q
			.GeoShapeEnvelope(c => c
				.Name("named_query")
				.Boost(1.1)
				.Field(p=>p.Location)
				.IgnoreUnmapped()
				.Coordinates(this._coordinates)
				.Relation(GeoShapeRelation.Intersects)
			);

		protected override ConditionlessWhen ConditionlessWhen => new ConditionlessWhen<IGeoShapeEnvelopeQuery>(a => a.GeoShape as IGeoShapeEnvelopeQuery)
		{
			q =>  q.Field = null,
			q =>  q.Shape = null,
			q =>  q.Shape.Coordinates = null,
		};
	}
}
