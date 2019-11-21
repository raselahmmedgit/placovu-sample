﻿using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Nest;
using Tests.Framework;
using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch.Clusters;
using Xunit;

namespace Tests.Indices.IndexSettings.IndexTemplates
{
	public class IndexTemplateCrudTests
		: CrudTestBase<IPutIndexTemplateResponse, IGetIndexTemplateResponse, IPutIndexTemplateResponse, IDeleteIndexTemplateResponse>
	{
		public IndexTemplateCrudTests(WritableCluster cluster, EndpointUsage usage) : base(cluster, usage) { }

		protected override LazyResponses Create() => Calls<PutIndexTemplateDescriptor, PutIndexTemplateRequest, IPutIndexTemplateRequest, IPutIndexTemplateResponse>(
			CreateInitializer,
			CreateFluent,
			fluent: (s, c, f) => c.PutIndexTemplate(s, f),
			fluentAsync: (s, c, f) => c.PutIndexTemplateAsync(s, f),
			request: (s, c, r) => c.PutIndexTemplate(r),
			requestAsync: (s, c, r) => c.PutIndexTemplateAsync(r)
		);

		protected PutIndexTemplateRequest CreateInitializer(string name) => new PutIndexTemplateRequest(name)
		{
			IndexPatterns = new[] { "startingwiththis-*" },
			Settings = new Nest.IndexSettings
			{
				NumberOfShards = 2
			}
		};

		protected IPutIndexTemplateRequest CreateFluent(string name, PutIndexTemplateDescriptor d) => d
			.IndexPatterns("startingwiththis-*")
			.Settings(s => s
				.NumberOfShards(2)
			);

		protected override LazyResponses Read() => Calls<GetIndexTemplateDescriptor, GetIndexTemplateRequest, IGetIndexTemplateRequest, IGetIndexTemplateResponse>(
			ReadInitializer,
			ReadFluent,
			fluent: (s, c, f) => c.GetIndexTemplate(f),
			fluentAsync: (s, c, f) => c.GetIndexTemplateAsync(f),
			request: (s, c, r) => c.GetIndexTemplate(r),
			requestAsync: (s, c, r) => c.GetIndexTemplateAsync(r)
		);

		protected GetIndexTemplateRequest ReadInitializer(string name) => new GetIndexTemplateRequest(name);
		protected IGetIndexTemplateRequest ReadFluent(string name, GetIndexTemplateDescriptor d) => d.Name(name);

		protected override void ExpectAfterCreate(IGetIndexTemplateResponse response)
		{
			response.TemplateMappings.Should().NotBeNull().And.HaveCount(1);
			var templateMapping = response.TemplateMappings.First().Value;
			templateMapping.IndexPatterns.Should().NotBeNullOrEmpty().And.Contain(t => t.StartsWith("startingwith"));
			templateMapping.Settings.Should().NotBeNull().And.NotBeEmpty();
			templateMapping.Settings.NumberOfShards.Should().Be(2);
		}

		protected override LazyResponses Update() => Calls<PutIndexTemplateDescriptor, PutIndexTemplateRequest, IPutIndexTemplateRequest, IPutIndexTemplateResponse>(
			PutInitializer,
			PutFluent,
			fluent: (s, c, f) => c.PutIndexTemplate(s, f),
			fluentAsync: (s, c, f) => c.PutIndexTemplateAsync(s, f),
			request: (s, c, r) => c.PutIndexTemplate(r),
			requestAsync: (s, c, r) => c.PutIndexTemplateAsync(r)
		);
		protected PutIndexTemplateRequest PutInitializer(string name) => new PutIndexTemplateRequest(name)
		{
			IndexPatterns = new[] { "startingwiththis-*" },
			Settings = new Nest.IndexSettings
			{
				NumberOfShards = 1
			}
		};
		protected IPutIndexTemplateRequest PutFluent(string name, PutIndexTemplateDescriptor d) => d
			.IndexPatterns("startingwiththis-*")
			.Settings(s=>s
				.NumberOfShards(1)
			);

		protected override void ExpectAfterUpdate(IGetIndexTemplateResponse response)
		{
			response.TemplateMappings.Should().NotBeNull().And.HaveCount(1);
			var templateMapping = response.TemplateMappings.First().Value;
			templateMapping.IndexPatterns.Should().NotBeNullOrEmpty().And.Contain(t => t.StartsWith("startingwith"));
			templateMapping.Settings.Should().NotBeNull().And.NotBeEmpty();
			templateMapping.Settings.NumberOfShards.Should().Be(1);
		}

		protected override LazyResponses Delete() => Calls<DeleteIndexTemplateDescriptor, DeleteIndexTemplateRequest, IDeleteIndexTemplateRequest, IDeleteIndexTemplateResponse>(
			DeleteInitializer,
			DeleteFluent,
			fluent: (s, c, f) => c.DeleteIndexTemplate(s, f),
			fluentAsync: (s, c, f) => c.DeleteIndexTemplateAsync(s, f),
			request: (s, c, r) => c.DeleteIndexTemplate(r),
			requestAsync: (s, c, r) => c.DeleteIndexTemplateAsync(r)
		);

		protected DeleteIndexTemplateRequest DeleteInitializer(string name) => new DeleteIndexTemplateRequest(name);
		protected IDeleteIndexTemplateRequest DeleteFluent(string name, DeleteIndexTemplateDescriptor d) => d;

		protected override async Task GetAfterDeleteIsValid() => await this.AssertOnGetAfterDelete(r => r.ShouldNotBeValid());

	}
}
