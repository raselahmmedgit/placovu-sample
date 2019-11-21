﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiGenerator.Domain
{
	public class ApiQueryParameters
	{
		public string OriginalQueryStringParamName { get; set; }
		public string DeprecatedInFavorOf { get; set; }
		public string Type { get; set; }
		public string Description { get; set; }
		public string Obsolete { get; set; }
		public IEnumerable<string> Options { get; set; }

		public ApiQueryParameters()
		{
			FluentGenerator = (queryStringParamName, mm, original, setter) =>
				$"public {queryStringParamName} {mm.ToPascalCase()}({CsharpType(mm)} {mm}) => this.AddQueryString(\"{original}\", {setter});";
		}

		public string CsharpType(string paramName)
		{
			switch (this.Type)
			{
				case "boolean":
					return "bool";
				case "list":
					return "params string[]";
				case "integer":
					return "int";
				case "number":
					return new [] {"boost", "percen", "score"}.Any(s=>paramName.ToLowerInvariant().Contains(s))
						? "double"
						: "long";
				case "duration":
				case "time":
					return "TimeSpan";
				case "text":
				case "":
				case null:
					return "string";
				case "enum":
					return paramName.ToPascalCase();
				default:
					return this.Type;
			}
		}

		public string HighLevelType(string paramName)
		{
			var csharpType = this.CsharpType(paramName);
			switch (csharpType)
			{
				case "TimeSpan":
					return "Time";
				default:
					return csharpType;
			}
		}

		public Func<string, string, string, string, string> Generator { get; set; } =
			(fieldType, mm, original, setter) =>
				$"public {fieldType} {mm} {{ get {{ return Q<{fieldType}>(\"{original}\"); }} set {{ Q(\"{original}\", {setter}); }} }}";

		public Func<string, string, string, string, string> FluentGenerator { get; set; }
	}
}
