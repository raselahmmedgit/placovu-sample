﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Nest
{
	/// <summary>
	/// Allows inline, stored, and file scripts to be executed within ingest pipelines.
	/// </summary>
	[JsonObject(MemberSerialization.OptIn)]
	[JsonConverter(typeof(ProcessorJsonConverter<ScriptProcessor>))]
	public interface IScriptProcessor : IProcessor
	{
		/// <summary>
		/// The scripting language. Defaults to painless
		/// </summary>
		[JsonProperty("lang")]
		string Lang { get; set; }

		/// <summary>
		/// The script file to refer to
		/// </summary>
		[JsonProperty("file")]
		string File { get; set; }

		/// <summary>
		/// The stored script id to refer to
		/// </summary>
		[JsonProperty("id")]
		string Id { get; set; }

		/// <summary>
		/// An inline script to be executed
		/// </summary>
		[JsonProperty("inline")]
		string Inline { get; set; }

		/// <summary>
		/// Parameters for the script
		/// </summary>
		[JsonProperty("params")]
		[JsonConverter(typeof(VerbatimDictionaryKeysJsonConverter<string, object>))]
		Dictionary<string, object> Params { get; set; }
	}

	/// <summary>
	/// Allows inline, stored, and file scripts to be executed within ingest pipelines.
	/// </summary>
	public class ScriptProcessor : ProcessorBase, IScriptProcessor
	{
		protected override string Name => "script";

		/// <summary>
		/// The scripting language. Defaults to painless
		/// </summary>
		public string Lang { get; set; }

		/// <summary>
		/// The script file to refer to
		/// </summary>
		public string File { get; set; }

		/// <summary>
		/// The stored script id to refer to
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// An inline script to be executed
		/// </summary>
		public string Inline { get; set; }

		/// <summary>
		/// Parameters for the script
		/// </summary>
		public Dictionary<string, object> Params { get; set; }
	}

	/// <summary>
	/// Allows inline, stored, and file scripts to be executed within ingest pipelines.
	/// </summary>
	public class ScriptProcessorDescriptor
		: ProcessorDescriptorBase<ScriptProcessorDescriptor, IScriptProcessor>, IScriptProcessor
	{
		protected override string Name => "script";

		string IScriptProcessor.Lang { get; set; }
		string IScriptProcessor.File{ get; set; }
		string IScriptProcessor.Id{ get; set; }
		string IScriptProcessor.Inline { get; set; }
		Dictionary<string, object> IScriptProcessor.Params { get; set; }

		/// <summary>
		/// The scripting language. Defaults to painless
		/// </summary>
		public ScriptProcessorDescriptor Lang(string lang) => Assign(a => a.Lang = lang);

		/// <summary>
		/// The script file to refer to
		/// </summary>
		public ScriptProcessorDescriptor File(string file) => Assign(a => a.File = file);

		/// <summary>
		/// The stored script id to refer to
		/// </summary>
		public ScriptProcessorDescriptor Id(string id) => Assign(a => a.Id = id);

		/// <summary>
		/// An inline script to be executed
		/// </summary>
		public ScriptProcessorDescriptor Inline(string inline) => Assign(a => a.Inline = inline);

		/// <summary>
		/// Parameters for the script
		/// </summary>
		public ScriptProcessorDescriptor Params(Dictionary<string, object> scriptParams) => Assign(a => a.Params = scriptParams);

		/// <summary>
		/// Parameters for the script
		/// </summary>
		public ScriptProcessorDescriptor Params(Func<FluentDictionary<string, object>, FluentDictionary<string, object>> paramsSelector) =>
			Assign(a => a.Params = paramsSelector?.Invoke(new FluentDictionary<string, object>()));
	}
}
