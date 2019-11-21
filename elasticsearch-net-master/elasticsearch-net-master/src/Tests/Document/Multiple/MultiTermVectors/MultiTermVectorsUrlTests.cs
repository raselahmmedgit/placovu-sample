﻿using System.Threading.Tasks;
using Nest;
using Tests.Framework;
using Tests.Framework.MockData;
using static Tests.Framework.UrlTester;

namespace Tests.Document.Multiple.MultiTermVectors
{
	public class MultiTermVectorsUrlTests : IUrlTests
	{
		[U] public async Task Urls()
		{
			await POST("/_mtermvectors")
				.Fluent(c => c.MultiTermVectors())
				.Request(c => c.MultiTermVectors(new MultiTermVectorsRequest()))
				.FluentAsync(c => c.MultiTermVectorsAsync())
				.RequestAsync(c => c.MultiTermVectorsAsync(new MultiTermVectorsRequest()))
				;

			await POST("/project/_mtermvectors")
				.Fluent(c => c.MultiTermVectors(m => m.Index<Project>()))
				.Request(c => c.MultiTermVectors(new MultiTermVectorsRequest(typeof(Project))))
				.FluentAsync(c => c.MultiTermVectorsAsync(m => m.Index<Project>()))
				.RequestAsync(c => c.MultiTermVectorsAsync(new MultiTermVectorsRequest(typeof(Project))))
				;

			await POST("/project/project/_mtermvectors")
				.Fluent(c => c.MultiTermVectors(m => m.Index<Project>().Type<Project>()))
				.Request(c => c.MultiTermVectors(new MultiTermVectorsRequest(typeof(Project), typeof(Project))))
				.FluentAsync(c => c.MultiTermVectorsAsync(m => m.Index<Project>().Type<Project>()))
				.RequestAsync(c => c.MultiTermVectorsAsync(new MultiTermVectorsRequest(typeof(Project), typeof(Project))))
				;
		}
	}
}
