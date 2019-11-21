﻿using System.Threading.Tasks;
using Nest;
using Tests.Framework;
using static Tests.Framework.UrlTester;

namespace Tests.XPack.Security.User.GetUserAccessToken
{
	public class GetUserAccessTokenUserUrlTests : IUrlTests
	{
		[U]
		public async Task Urls()
		{
			var u = ShieldInformation.Admin.Username;
			var p = ShieldInformation.Admin.Password;
			await POST("/_xpack/security/oauth2/token")
				.Fluent(c => c.GetUserAccessToken(u,p))
				.Request(c => c.GetUserAccessToken(new GetUserAccessTokenRequest(u,p)))
				.FluentAsync(c => c.GetUserAccessTokenAsync(u, p))
				.RequestAsync(c => c.GetUserAccessTokenAsync(new GetUserAccessTokenRequest(u, p)));
		}
	}
}
