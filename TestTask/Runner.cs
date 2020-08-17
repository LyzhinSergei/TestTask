using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TestTask.constants;
using TestTask.Interface;

namespace TestTask
{
	class Runner : IRunner
	{
		private readonly NLog.Logger _logger;

		private string rowConsole { get; set; }

		public Runner(NLog.Logger logger)
		{
			_logger = logger;
		}

		public void ConfigureTest()
		{
			var listMethodNames = GetMethodNames();
			ProgressBar.WriteProgressBar(0);
			var stepProgress = 100 / listMethodNames.Count;
			int progress = 0;
			Parallel.ForEach(listMethodNames, new ParallelOptions { MaxDegreeOfParallelism = MyConsole.CountThreads }, 
			methodName =>
				{ 
					_logger.Info($"Thread ID: {Task.CurrentId} - Method name: {methodName}");
					rowConsole = $"{Paths.PathToTest} /Tests:{methodName}";
					StartTest();
					progress += stepProgress;
					ProgressBar.WriteProgressBar(progress, true);
				}
			);
		}

		public void StartTest()
		{
			Process cmd = new Process();
			cmd.StartInfo.FileName = Paths.PathToConsole;
			cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			cmd.StartInfo.Arguments = rowConsole;
			cmd.StartInfo.CreateNoWindow = true;
			cmd.Start();
		}

		public List<string> GetMethodNames()
		{
			Assembly assembly = Assembly.LoadFrom(Paths.PathToTest);
			Type[] types = assembly.GetExportedTypes();
			Regex regex = new Regex("(\\w*)test(\\w*)");
			var listMethodName = new List<string>();
			MethodInfo[] methods = null;
			foreach (Type t in types)
			{
				methods = t.GetMethods();
				foreach (MethodInfo method in methods)
				{
					if (regex.IsMatch(method.Name.ToLower()))
					{
						listMethodName.Add(method.Name);
					}
				}
			}
			return listMethodName;
		}
	}
}
