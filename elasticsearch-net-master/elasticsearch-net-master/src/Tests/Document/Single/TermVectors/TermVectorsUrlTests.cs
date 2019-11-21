﻿using System.Threading.Tasks;
using Nest;
using Tests.Framework;
using Tests.Framework.MockData;
using static Tests.Framework.UrlTester;

namespace Tests.Document.Single.TermVectors
{
	public class TermVectorsUrlTests
	{

		[U]
		public async Task Urls()
		{
			var id = "name-of-doc";
			var index = "myindex";

			await GET($"/{index}/project/{id}/_termvectors")
				.Fluent(c=>c.TermVectors<Project>(t => t.Index(index).Id(id)))
				.Request(c=>c.TermVectors(new TermVectorsRequest<Project>(index, typeof(Project), id)))
				.FluentAsync(c=>c.TermVectorsAsync<Project>(t => t.Index(index).Id(id)))
				.RequestAsync(c=>c.TermVectorsAsync(new TermVectorsRequest<Project>(index, typeof(Project), id)))
				;

			await GET($"/project/project/{id}/_termvectors")
				.Fluent(c=>c.TermVectors<Project>(t => t.Id(id)))
				.Request(c=>c.TermVectors(new TermVectorsRequest<Project>(id)))
				.FluentAsync(c=>c.TermVectorsAsync<Project>(t => t.Id(id)))
				.RequestAsync(c=>c.TermVectorsAsync(new TermVectorsRequest<Project>(id)))
				;

			await GET($"/{index}/project/{id}/_termvectors")
				.Fluent(c=>c.TermVectors<Project>(t => t.Index(index).Id(id)))
				.Request(c=>c.TermVectors(new TermVectorsRequest<Project>(index, typeof(Project), id)))
				.FluentAsync(c=>c.TermVectorsAsync<Project>(t => t.Index(index).Id(id)))
				.RequestAsync(c=>c.TermVectorsAsync(new TermVectorsRequest<Project>(index, typeof(Project), id)))
				;
		
			var document = new Project { Name = "foo" };

			await POST($"/{index}/project/_termvectors")
				.Fluent(c => c.TermVectors<Project>(t => t.Index(index).Document(document)))
				.Request(c => c.TermVectors(new TermVectorsRequest<Project>(new DocumentPath<Project>(document).Index(index))))
				.FluentAsync(c => c.TermVectorsAsync<Project>(t => t.Index(index).Document(document)))
				.RequestAsync(c => c.TermVectorsAsync(new TermVectorsRequest<Project>(new DocumentPath<Project>(document).Index(index))))
				;

			await POST($"/project/project/_termvectors")
				.Fluent(c=>c.TermVectors<Project>(t => t.Document(document)))
				.Request(c=>c.TermVectors(new TermVectorsRequest<Project>(document)))
				.FluentAsync(c=>c.TermVectorsAsync<Project>(t => t.Document(document)))
				.RequestAsync(c=>c.TermVectorsAsync(new TermVectorsRequest<Project>(document)))
				;
		}
	}
}
