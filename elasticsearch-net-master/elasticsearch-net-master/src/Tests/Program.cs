﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Tests.Framework;
using Tests.Framework.Integration;
using Tests.Framework.ManagedElasticsearch;
using Tests.Framework.ManagedElasticsearch.Clusters;
using Tests.Framework.Profiling;
using Tests.Framework.Profiling.Memory;
using Tests.Framework.Profiling.Performance;
using Tests.Framework.Profiling.Timeline;

namespace Tests
{
	public class Program
	{
		static Program()
		{
			var currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
			if ((currentDirectory.Name == "Debug" || currentDirectory.Name == "Release") && currentDirectory.Parent.Name == "bin")
			{
				SdkPath = new DirectoryInfo(
					Path.Combine(
						Directory.GetCurrentDirectory(),
						$@".\..\..\..\..\build\tools\{SelfProfileSdkDirectory}")).FullName;

				OutputPath = new DirectoryInfo(
					Path.Combine(
						Directory.GetCurrentDirectory(),
						$@".\..\..\..\..\build\output\profiling")).FullName;
			}
			else
			{
				SdkPath = new DirectoryInfo(
					Path.Combine(
						Directory.GetCurrentDirectory(),
						$@".\build\tools\{SelfProfileSdkDirectory}")).FullName;

				OutputPath = new DirectoryInfo(
					Path.Combine(
						Directory.GetCurrentDirectory(),
						$@".\build\output\profiling")).FullName;
			}
		}

		public static string InputDirPath { get; }

		public static string OutputDirPath { get; }

		private const string SelfProfileSdkDirectory = "dottrace-selfprofile";

		private static  string SdkPath { get; }
		private static  string OutputPath { get; }

		// Rename to TestMain (instead of Main) if you'd like to run these tests within Visual Studio
		// (Relates to this issue: https://youtrack.jetbrains.com/issue/RSRP-464233)
		// (See also https://github.com/elastic/elasticsearch-net/pull/2793)
		public static void Main(string[] args)
		{
			if (args.Length == 0)
				Console.WriteLine("Must specify at least one argument: TestAssemblyPath, Profile or Benchmark ");

			var arguments = args.Skip(1).ToArray();

			if (args[0].Equals("Profile", StringComparison.OrdinalIgnoreCase))
			{
#if DOTNETCORE
				Console.Error.WriteLine("DotTrace Profiling is not currently supported on .NET Core");
				return;
#else
				var configuration = ProfileConfiguration.Parse(arguments);
				Console.WriteLine("Running Profiling with the following:");
				Console.WriteLine($"- SdkPath: {SdkPath}");
				Console.WriteLine($"- OutputPath: {OutputPath}");
				Console.WriteLine($"- Classes: [{(configuration.ClassNames.Any() ? string.Join(",", configuration.ClassNames) : "*All*")}]");

				using (var cluster = new ProfilingCluster())
				{
					foreach (var profilingFactory in CreateProfilingFactory(cluster))
					{
						profilingFactory.Run(configuration);
						profilingFactory.RunAsync(configuration).Wait();
					}
				}
#endif
			}
			else if (args[0].Equals("Benchmark", StringComparison.OrdinalIgnoreCase))
			{
				Console.WriteLine("Running Benchmarking.");
				if (args.Count() > 1 && args[1].Equals("non-interactive", StringComparison.OrdinalIgnoreCase))
				{
					Console.WriteLine("Running in Non-Interactive mode.");
					foreach (var benchmarkType in GetBenchmarkTypes())
					{
						BenchmarkRunner.Run(benchmarkType);
					}
					return;
				}

				Console.WriteLine("Running in Interactive mode.");
				var benchmarkSwitcher = new BenchmarkSwitcher(GetBenchmarkTypes());
				benchmarkSwitcher.Run(arguments);
			}
		}

#if !DOTNETCORE
		private static IEnumerable<IProfileFactory> CreateProfilingFactory(ClusterBase cluster)
		{
			yield return new PerformanceProfileFactory(SdkPath, OutputPath, cluster, Assembly.GetExecutingAssembly(), new ColoredConsoleWriter());
			yield return new TimelineProfileFactory(SdkPath, OutputPath, cluster, Assembly.GetExecutingAssembly(), new ColoredConsoleWriter());
			yield return new MemoryProfileFactory(SdkPath, OutputPath, cluster, Assembly.GetExecutingAssembly(), new ColoredConsoleWriter());
		}
#endif

		private static Type[] GetBenchmarkTypes()
		{
			IEnumerable<Type> types;

			try
			{
				types = typeof(Program).Assembly().GetTypes();
			}
			catch (ReflectionTypeLoadException e)
			{
				types = e.Types.Where(t => t != null);
			}

			return types
				.Where(t => t.GetMethods(BindingFlags.Instance | BindingFlags.Public)
							 .Any(m => m.GetCustomAttributes(typeof(BenchmarkAttribute), false).Any()))
				.OrderBy(t => t.Namespace)
				.ThenBy(t => t.Name)
				.ToArray();
		}
	}
}
