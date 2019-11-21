﻿using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch.Clusters;
using Xunit;

namespace Tests.QueryDsl
{
	public abstract class GeoShapeQueryUsageTestsBase : QueryDslUsageTestsBase
	{
		public GeoShapeQueryUsageTestsBase(ReadOnlyCluster i, EndpointUsage usage) : base(i, usage) { }

		protected override object QueryJson => new
		{
			geo_shape = new
			{
				location = new
				{
					_name="named_query",
					boost = 1.1,
					ignore_unmapped = false,
					relation = "intersects",
					shape = this.ShapeJson
				}
			}
		};

		protected abstract object ShapeJson { get; }
	}
}
