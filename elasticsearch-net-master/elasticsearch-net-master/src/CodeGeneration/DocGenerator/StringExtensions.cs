﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Newtonsoft.Json;

namespace DocGenerator
{
	public static class StringExtensions
	{
        private static readonly Regex LeadingSpacesAndAsterisk = new Regex(@"^(?<value>[ \t]*\*\s?).*", RegexOptions.Compiled);
        private static readonly Regex LeadingMultiLineComment = new Regex(@"^(?<value>[ \t]*\/\*)", RegexOptions.Compiled);
        private static readonly Regex TrailingMultiLineComment = new Regex(@"(?<value>\*\/[ \t]*)$", RegexOptions.Compiled);

		public static string PascalToHyphen(this string input)
		{
			if (string.IsNullOrEmpty(input)) return string.Empty;

			return Regex.Replace(
				Regex.Replace(
					Regex.Replace(input, @"([A-Z]+)([A-Z][a-z])", "$1-$2"), @"([a-z\d])([A-Z])", "$1-$2")
				, @"[-\s]+", "-", RegexOptions.Compiled).TrimEnd('-').ToLower();
		}

		public static string LowercaseHyphenToPascal(this string lowercaseHyphenatedInput)
		{
			return Regex.Replace(
                lowercaseHyphenatedInput.Replace("-", " "), 
                @"\b([a-z])", 
                m => m.Captures[0].Value.ToUpper());
		}

		public static string TrimEnd(this string input, string trim)
		{
			if (string.IsNullOrEmpty(input)) return string.Empty;

			return input.EndsWith(trim, StringComparison.OrdinalIgnoreCase)
				? input.Substring(0, input.Length - trim.Length)
				: input;
		}

		public static string RemoveLeadingAndTrailingMultiLineComments(this string input)
		{
			var match = LeadingMultiLineComment.Match(input);

			if (match.Success)
			{
				input = input.Substring(match.Groups["value"].Value.Length);
			}

			match = TrailingMultiLineComment.Match(input);

			if (match.Success)
			{
				input = input.Substring(0, input.Length - match.Groups["value"].Value.Length);
			}

			return input;
		}

		public static string RemoveLeadingSpacesAndAsterisk(this string input)
		{
			var match = LeadingSpacesAndAsterisk.Match(input);
			if (match.Success)
			{
				input = input.Substring(match.Groups["value"].Value.Length);
			}

			return input;
		}

        ///<summary>
        /// Removes the specified number of tabs (or spaces, assuming 4 spaces = 1 tab) 
        /// from each line of the input
        /// </summary>
        public static string RemoveNumberOfLeadingTabsOrSpacesAfterNewline(this string input, int numberOfTabs)
        {
            var leadingCharacterIndex = input.IndexOf("\t", StringComparison.OrdinalIgnoreCase);

            if (leadingCharacterIndex == -1)
            {
                leadingCharacterIndex = input.IndexOf(" ", StringComparison.OrdinalIgnoreCase);

                if (leadingCharacterIndex == -1)
                {
                    return input;
                }
            }

            int count = 0;
            char firstNonTabCharacter = char.MinValue;

            for (int i = leadingCharacterIndex; i < input.Length; i++)
            {
                if (input[i] != '\t' && input[i] != ' ')
                {
                    firstNonTabCharacter = input[i];
                    count = i - leadingCharacterIndex;
                    break;
                }
            }

            if (firstNonTabCharacter == '{' && numberOfTabs != count)
            {
                numberOfTabs = count;
            }

            return Regex.Replace(
                Regex.Replace(
                    input,
                    $"(?<tabs>[\n|\r\n]+\t{{{numberOfTabs}}})",
                    m => m.Value.Replace("\t", string.Empty)
                    ),
                $"(?<spaces>[\n|\r\n]+\\s{{{numberOfTabs * 4}}})",
                m => m.Value.Replace(" ", string.Empty)
                );
        }

        public static string[] SplitOnNewLines(this string input, StringSplitOptions options)
		{
			return input.Split(new[] { "\r\n", "\n" }, options);
		}

		// TODO: Total Hack of replacements in anonymous types that represent json. This can be resolved by referencing tests assembly when building the dynamic assembly,
		// but might want to put doc generation at same directory level as Tests to reference project directly.
		private static Dictionary<string, string> Substitutions = new Dictionary<string, string>
		{
			{ "FixedDate", "new DateTime(2015, 06, 06, 12, 01, 02, 123)" },
			{ "FirstNameToFind", "\"pierce\"" },
			{ "Project.First.Suggest.Context.Values.SelectMany(v => v).First()", "\"red\"" },
			{ "Project.First.Suggest.Contexts.Values.SelectMany(v => v).First()", "\"red\"" },
			{ "Project.Instance.Name", "\"Durgan LLC\"" },
			{ "Project.InstanceAnonymous", "new {name = \"Koch, Collier and Mohr\", state = \"BellyUp\",startedOn = " +
			                               "\"2015-01-01T00:00:00\",lastActivity = \"0001-01-01T00:00:00\",leadDeveloper = " +
			                               "new { gender = \"Male\", id = 0, firstName = \"Martijn\", lastName = \"Laarman\" }," +
										   "location = new { lat = 42.1523, lon = -80.321 }}" },
			{ "_templateString", "\"{ \\\"match\\\": { \\\"text\\\": \\\"{{query_string}}\\\" } }\"" },
			{ "base.QueryJson", "new{ @bool = new { must = new[] { new { match_all = new { } } }, must_not = new[] { new { match_all = new { } } }, should = new[] { new { match_all = new { } } }, filter = new[] { new { match_all = new { } } }, minimum_should_match = 1, boost = 2.0, } }" },
			{ "ExpectedTerms", "new [] { \"term1\", \"term2\" }" },
			{ "_ctxNumberofCommits", "\"_source.numberOfCommits > 0\"" },
			{ "Project.First.Name", "\"Lesch Group\"" },
			{ "Project.First.NumberOfCommits", "775" },
			{ "LastNameSearch", "\"Stokes\"" }
		};

		public static bool TryGetJsonForAnonymousType(this string anonymousTypeString, out string json)
		{
			json = null;

			foreach (var substitution in Substitutions)
			{
				anonymousTypeString = anonymousTypeString.Replace(substitution.Key, substitution.Value);
			}

			var text =
				$@"
					using System;
                    using System.Collections.Generic;
					using System.ComponentModel;
					using Newtonsoft.Json;
					using Newtonsoft.Json.Linq;

					namespace Temporary
					{{
						public class Json
						{{
							public string Write()
							{{
								var o = {anonymousTypeString};
								var json = JsonConvert.SerializeObject(o, Formatting.Indented);
								return json;
							}}
						}}
					}}";

			var syntaxTree = CSharpSyntaxTree.ParseText(text);
			var assemblyName = Path.GetRandomFileName();
			var references = new MetadataReference[]
			{
				MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location),
				MetadataReference.CreateFromFile(typeof(Enumerable).GetTypeInfo().Assembly.Location),
				MetadataReference.CreateFromFile(typeof(JsonConvert).GetTypeInfo().Assembly.Location),
				MetadataReference.CreateFromFile(typeof(ITypedList).GetTypeInfo().Assembly.Location),
			};

			var compilation =
				CSharpCompilation.Create(
					assemblyName,
					new[] { syntaxTree },
					references,
					new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

			using (var ms = new MemoryStream())
			{
				var result = compilation.Emit(ms);

				if (!result.Success)
				{
					var failures = result.Diagnostics.Where(diagnostic =>
						diagnostic.IsWarningAsError ||
						diagnostic.Severity == DiagnosticSeverity.Error);

					var builder = new StringBuilder($"Unable to serialize the following C# anonymous type string to json: {anonymousTypeString}");
					foreach (var diagnostic in failures)
					{
						builder.AppendLine($"{diagnostic.Id}: {diagnostic.GetMessage()}");
					}
					builder.AppendLine(new string('-', 30));

					Console.Error.WriteLine(builder.ToString());
					return false;
				}

				ms.Seek(0, SeekOrigin.Begin);

				var assembly = Assembly.Load(ms.ToArray());
				var type = assembly.GetType("Temporary.Json");
				var obj = Activator.CreateInstance(type);

				var output = type.InvokeMember("Write",
					BindingFlags.Default | BindingFlags.InvokeMethod,
					null,
					obj,
					new object[] { });

				json = output.ToString();
				return true;
			}
		}

	    public static string ReplaceArityWithGenericSignature(this string value)
	    {
            var indexOfBackTick = value.IndexOf("`");

            if (indexOfBackTick == -1)
                return value;

            var arity = value[indexOfBackTick + 1];
            value = value.Substring(0, indexOfBackTick);

            return Enumerable.Range(1, int.Parse(arity.ToString()))
                .Aggregate(value + "<", (l, i) => l = l + (i == 1 ? "T" : $"T{i}")) + ">";
	    }
	}
}
