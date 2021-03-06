﻿using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Core.Server
{
	static class Program
	{
		private const string AppSettingsFileName = "appsettings.json";

		static void Main(string[] arguments)
		{
			try
			{
				var config = new ConfigurationBuilder()
					.SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile(AppSettingsFileName)
					.Build();

				var server = new Server(config, arguments);
				server.Run();
			}
			catch (Exception exception)
			{
				Console.WriteLine($"Message: {exception.Message}; Inner Exception: {exception.InnerException}");
				Console.ReadLine();
			}
		}
	}
}
