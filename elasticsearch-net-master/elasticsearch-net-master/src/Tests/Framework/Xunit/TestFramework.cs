﻿using System;
using System.Reflection;
using Bogus;
using Tests.Framework;
using Tests.Framework.Configuration;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit
{
	class TestFramework : XunitTestFramework
	{
		public TestFramework(IMessageSink messageSink)
			: base(messageSink)
		{ }

		protected override ITestFrameworkExecutor CreateExecutor(AssemblyName assemblyName)
		{
			var config = TestClient.Configuration;

		    Randomizer.Seed = new Random(1337);

            Console.WriteLine("Starting tests using config:");
			Console.WriteLine($" - {nameof(config.TestAgainstAlreadyRunningElasticsearch)}: {config.TestAgainstAlreadyRunningElasticsearch}");
			Console.WriteLine($" - {nameof(config.ElasticsearchVersion)}: {config.ElasticsearchVersion}");
			Console.WriteLine($" - {nameof(config.ForceReseed)}: {config.ForceReseed}");
			Console.WriteLine($" - {nameof(config.Mode)}: {config.Mode.ToString()}");
			if (config.Mode == TestMode.Integration)
			{
				Console.WriteLine($" - {nameof(config.ClusterFilter)}: {config.ClusterFilter}");
				Console.WriteLine($" - {nameof(config.TestFilter)}: {config.TestFilter}");

			}
			Console.WriteLine($" - {nameof(config.RunIntegrationTests)}: {config.RunIntegrationTests}");
			Console.WriteLine($" - {nameof(config.RunUnitTests)}: {config.RunUnitTests}");

			return new TestFrameworkExecutor(assemblyName, SourceInformationProvider, DiagnosticMessageSink);
		}
	}
}
