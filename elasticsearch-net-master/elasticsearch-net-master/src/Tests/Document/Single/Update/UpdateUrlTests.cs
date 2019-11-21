﻿using System.Threading.Tasks;
using Nest;
using Tests.Framework;
using Tests.Framework.MockData;
using static Tests.Framework.UrlTester;

namespace Tests.Document.Single.Update
{
	public class UpdateUrlTests
	{

		[U]
		public async Task Urls()
		{
			var document = new Project { Name = "foo" };

			await POST($"/project/project/foo/_update")
				.Fluent(c => c.Update<Project>(document, u => u))
				.Request(c => c.Update(new UpdateRequest<Project, object>(document)))
				.FluentAsync(c => c.UpdateAsync<Project>(document, u => u))
				.RequestAsync(c => c.UpdateAsync(new UpdateRequest<Project, object>(document)))
				;

			var otherId = "other-id";

			await POST($"/project/project/{otherId}/_update")
				.Fluent(c => c.Update<Project>(otherId, u => u))
				.Request(c => c.Update(new UpdateRequest<Project, object>(typeof(Project), typeof(Project), otherId)))
				.FluentAsync(c => c.UpdateAsync<Project>(otherId, u => u))
				.RequestAsync(c => c.UpdateAsync(new UpdateRequest<Project, object>(typeof(Project), typeof(Project), otherId)))
				;

			var otherIndex = "other-index";

			await POST($"/{otherIndex}/project/{otherId}/_update")
				.Fluent(c => c.Update<Project>(otherId, u => u.Index(otherIndex)))
				.Request(c => c.Update(new UpdateRequest<Project, object>(otherIndex, typeof(Project), otherId)))
				.FluentAsync(c => c.UpdateAsync<Project>(otherId, u => u.Index(otherIndex)))
				.RequestAsync(c => c.UpdateAsync(new UpdateRequest<Project, object>(otherIndex, typeof(Project), otherId)))
				;

			var otherType = "other-type";

			await POST($"/{otherIndex}/{otherType}/{otherId}/_update")
				.Fluent(c => c.Update<Project>(otherId, u => u.Index(otherIndex).Type(otherType)))
				.Request(c => c.Update(new UpdateRequest<Project, object>(otherIndex, otherType, otherId)))
				.FluentAsync(c => c.UpdateAsync<Project>(otherId, u => u.Index(otherIndex).Type(otherType)))
				.RequestAsync(c => c.UpdateAsync(new UpdateRequest<Project, object>(otherIndex, otherType, otherId)))
				;
		}
	}
}
