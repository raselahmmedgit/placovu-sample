using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Elasticsearch.Net
{
	internal class ElasticsearchNetJsonStrategy : PocoJsonSerializerStrategy
	{
		public static readonly ElasticsearchNetJsonStrategy Instance = new ElasticsearchNetJsonStrategy();


		public override bool TrySerializeNonPrimitiveObject(object input, out object output)
		{
			if (input is Exception)
			{
				var e = input as Exception;
				var exceptionsJson = this.FlattenExceptions(e).ToList();
				var array = new JsonArray(exceptionsJson.Count);
				array.AddRange(exceptionsJson);
				output = array;
				return true;

			}
			return base.TrySerializeNonPrimitiveObject(input, out output);
		}


		private IEnumerable<JsonObject> FlattenExceptions(Exception e)
		{
			int depth = 0;
			int maxExceptions = 20;
			do
			{
				JsonObject o = ToExceptionJsonObject(e, depth);
				depth++;
				yield return o;
				e = e.InnerException;

			}
			while (depth < maxExceptions && e != null);
		}




		private JsonObject ToExceptionJsonObject(Exception e, int depth)
		{
			var o = new JsonObject();
#if !DOTNETCORE
			var si = new SerializationInfo(e.GetType(), new FormatterConverter());
			var sc = new StreamingContext();
			e.GetObjectData(si, sc);
			//TODO Loop over ISerializable data

			var helpUrl = si.GetString("HelpURL");
			var stackTrace = si.GetString("StackTraceString");
			var remoteStackTrace = si.GetString("RemoteStackTraceString");
			var remoteStackIndex = si.GetInt32("RemoteStackIndex");
			var exceptionMethod = si.GetString("ExceptionMethod");
			var hresult = si.GetInt32("HResult");
			var source = si.GetString("Source");
			var className = si.GetString("ClassName");
#else
			var helpUrl = e.HelpLink;
			var stackTrace = e.StackTrace;
			var remoteStackTrace = string.Empty;
			var remoteStackIndex = string.Empty;
			var exceptionMethod = string.Empty;
			var hresult = e.HResult;
			var source = e.Source;
			var className = string.Empty;
#endif

			o.Add("Depth", depth);
			o.Add("ClassName", className);
			o.Add("Message", e.Message);
			o.Add("Source", source);
			o.Add("StackTraceString", stackTrace);
			o.Add("RemoteStackTraceString", remoteStackTrace);
			o.Add("RemoteStackIndex", remoteStackIndex);
			o.Add("HResult", hresult);
			o.Add("HelpURL", helpUrl);
#if !DOTNETCORE
			this.WriteStructuredExceptionMethod(o, exceptionMethod);
#endif
			return o;
		}

		private void WriteStructuredExceptionMethod(JsonObject o, string exceptionMethodString)
		{
			if (string.IsNullOrWhiteSpace(exceptionMethodString)) return;

			var args = exceptionMethodString.Split('\0', '\n');

			if (args.Length != 5) return;

			var memberType = Int32.Parse(args[0], CultureInfo.InvariantCulture);
			var name = args[1];
			var assemblyName = args[2];
			var className = args[3];
			var signature = args[4];
			var an = new AssemblyName(assemblyName);
			var exceptionMethod = new JsonObject();

			exceptionMethod.Add("Name", name);
			exceptionMethod.Add("AssemblyName", an.Name);
			exceptionMethod.Add("AssemblyVersion", an.Version.ToString());
			exceptionMethod.Add("AssemblyCulture", an.CultureName);
			exceptionMethod.Add("ClassName", className);
			exceptionMethod.Add("Signature", signature);
			exceptionMethod.Add("MemberType", memberType);
			o.Add("ExceptionMethod", exceptionMethod);
		}


		public override object DeserializeObject(object value, Type type)
		{
			if (type == typeof(DynamicResponse))
			{
				var dict = base.DeserializeObject(value, typeof(IDictionary<string, object>)) as IDictionary<string, object>;
				return dict == null ? null : DynamicResponse.Create(dict);
			}
			if (type == typeof(ServerError))
			{
				var dict = base.DeserializeObject(value, typeof(IDictionary<string, object>)) as IDictionary<string, object>;
				return ServerError.Create(dict, this);
			}
			if (type == typeof(Error))
			{
				var dict = base.DeserializeObject(value, typeof(IDictionary<string, object>)) as IDictionary<string, object>;
				return Error.Create(dict, this);
			}
			if (type == typeof(RootCause))
			{
				var dict = base.DeserializeObject(value, typeof(IDictionary<string, object>)) as IDictionary<string, object>;
				return RootCause.Create(dict, this);
			}
			if (type == typeof(CausedBy))
			{
				var dict = base.DeserializeObject(value, typeof(IDictionary<string, object>)) as IDictionary<string, object>;
				return CausedBy.Create(dict, this);
			}
			return base.DeserializeObject(value, type);
		}
	}
}
