﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiGenerator.Overrides.Allow404
{
	public static class ApiEndpointsThatAllow404
	{
		public static readonly IEnumerable<string> Endpoints = new List<string>
		{
			"DocumentExists",
			"IndexExists",
			"SearchExists",
			"AliasExists",
			"IndexTemplateExists",
			"TypeExists",
			"Exists",
			"Get",
			"Delete",
			"GetWatch",
			"DeleteWatch",
		};
	}
}
