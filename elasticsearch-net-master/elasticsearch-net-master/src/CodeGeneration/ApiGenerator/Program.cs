﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ApiGenerator
{
	public static class Program
	{
		private static readonly string DownloadBranch = "master";

		static void Main(string[] args)
		{
			bool redownloadCoreSpecification = false;
			string downloadBranch = DownloadBranch;

			var answer = "invalid";
			while (answer != "y" && answer != "n" && answer != "")
			{
				Console.Write("Download online rest specifications? [Y/N] (default N): ");
				answer = Console.ReadLine()?.Trim().ToLowerInvariant();
				redownloadCoreSpecification = answer == "y";
			}

			if (redownloadCoreSpecification)
			{
				Console.Write("Branch to download specification from (default master): ");
				var readBranch = Console.ReadLine()?.Trim();
				if (!string.IsNullOrEmpty(readBranch)) downloadBranch = readBranch;
			}
			else
			{
				// read last downloaded branch from file.
				if (File.Exists(CodeConfiguration.LastDownloadedVersionFile))
				{
					downloadBranch = File.ReadAllText(CodeConfiguration.LastDownloadedVersionFile);
				}
			}

			if (string.IsNullOrEmpty(downloadBranch))
				downloadBranch = DownloadBranch;

			if (redownloadCoreSpecification)
				RestSpecDownloader.Download(downloadBranch);

			ApiGenerator.Generate(downloadBranch, "Core", "Graph", "License", "Security", "Watcher", "Info");

			//ApiGenerator.Generate(); //generates everything under ApiSpecification
		}

	}
}
