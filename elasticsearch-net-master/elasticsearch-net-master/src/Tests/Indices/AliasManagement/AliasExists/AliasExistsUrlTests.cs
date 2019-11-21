﻿using System.Threading.Tasks;
using Nest;
using Tests.Framework;
using static Tests.Framework.UrlTester;

namespace Tests.Indices.AliasManagement.AliasExists
{
	public class AliasExistsUrlTests
	{
		[U] public async Task Urls()
		{
			Name name = "hardcoded";
			IndexName index = "index";
			await HEAD($"/_alias/hardcoded")
				.Fluent(c=>c.AliasExists(b=>b.Name(name)))
				.Request(c=>c.AliasExists(new AliasExistsRequest(name)))
				.FluentAsync(c=>c.AliasExistsAsync(b=>b.Name(name)))
				.RequestAsync(c=>c.AliasExistsAsync(new AliasExistsRequest(name)))
				;

			await HEAD($"/index/_alias/hardcoded")
				.Fluent(c=>c.AliasExists(b=>b.Index(index).Name(name)))
				.Request(c=>c.AliasExists(new AliasExistsRequest(index, name)))
				.FluentAsync(c=>c.AliasExistsAsync(b=>b.Index(index).Name(name)))
				.RequestAsync(c=>c.AliasExistsAsync(new AliasExistsRequest(index, name)))
				;

		}
	}
}
