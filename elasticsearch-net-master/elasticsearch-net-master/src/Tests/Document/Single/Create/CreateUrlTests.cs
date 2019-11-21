﻿using System.Threading.Tasks;
using Nest;
using Tests.Framework;
using Tests.Framework.MockData;
using static Tests.Framework.UrlTester;

namespace Tests.Document.Single.Create
{
	public class CreateUrlTests
	{
		[U] public async Task Urls()
		{
			var project = new Project { Name = "NEST" };

			await PUT("/project/project/1/_create")
				.Fluent(c => c.Create<object>(new { }, i => i.Index(typeof(Project)).Type(typeof(Project)).Id(1)))
				.Request(c => c.Create(new CreateRequest<object>("project", "project", 1) { Document = new { } }))
				.FluentAsync(c => c.CreateAsync<object>(new {}, i => i.Index(typeof(Project)).Type(typeof(Project)).Id(1)))
				.RequestAsync(c => c.CreateAsync(new CreateRequest<object>(IndexName.From<Project>(), TypeName.From<Project>(), 1)
                {
					Document = new { }
				}))
				;

			await PUT("/project/project/NEST/_create")
				.Fluent(c => c.Create(project))
				.Request(c => c.Create(new CreateRequest<Project>(project)))
				.Request(c => c.Create(new CreateRequest<Project>(project, "project", "project", "NEST") { Document = project }))			
				.FluentAsync(c => c.CreateAsync(project))
				.RequestAsync(c => c.CreateAsync(new CreateRequest<Project>(project)))
				.RequestAsync(c => c.CreateAsync(new CreateRequest<Project>(project, "project", "project", "NEST") { Document = project }))
				;

			await PUT("/different-projects/project/elasticsearch/_create")
				.Request(c => c.Create(new CreateRequest<Project>("different-projects", "project", "elasticsearch") { Document = project }))
				.Request(c => c.Create(new CreateRequest<Project>(project, "different-projects", "project", "elasticsearch")))
				.RequestAsync(c => c.CreateAsync(new CreateRequest<Project>(project, "different-projects", "project", "elasticsearch")))
				.RequestAsync(c => c.CreateAsync(new CreateRequest<Project>("different-projects", "project", "elasticsearch") { Document = project }))
				;
		}
	}
}
