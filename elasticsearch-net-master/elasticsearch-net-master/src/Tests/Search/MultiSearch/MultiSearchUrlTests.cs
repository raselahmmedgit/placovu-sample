﻿using System.Threading.Tasks;
using Nest;
using Tests.Framework;
using Tests.Framework.MockData;
using static Tests.Framework.UrlTester;

namespace Tests.Search.MultiSearch
{
	public class MultiSearchUrlTests
	{
		[U] public async Task Urls()
		{
			var index = "indexx";
			await POST($"/_msearch")
				.Fluent(c=>c.MultiSearch(s=>s))
				.Request(c=>c.MultiSearch(new MultiSearchRequest()))
				.FluentAsync(c=>c.MultiSearchAsync(s=> s))
				.RequestAsync(c=>c.MultiSearchAsync(new MultiSearchRequest()))
				;

			await POST($"/{index}/_msearch")
				.Fluent(c=>c.MultiSearch(s=>s.Index(index)))
				.Request(c=>c.MultiSearch(new MultiSearchRequest(index)))
				.FluentAsync(c=>c.MultiSearchAsync(s=> s.Index(index)))
				.RequestAsync(c=>c.MultiSearchAsync(new MultiSearchRequest(index)))
				;

			await POST($"/{index}/commits/_msearch")
				.Fluent(c=>c.MultiSearch(s=>s.Index(index).Type<CommitActivity>()))
				.Request(c=>c.MultiSearch(new MultiSearchRequest(index, TypeName.From<CommitActivity>())))
				.FluentAsync(c=>c.MultiSearchAsync(s=> s.Index(index).Type(typeof(CommitActivity))))
				.RequestAsync(c=>c.MultiSearchAsync(new MultiSearchRequest(index, typeof(CommitActivity))))
				;
		}
	}
}
