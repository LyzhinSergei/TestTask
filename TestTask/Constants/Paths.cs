using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestTask.constants
{
	public class Paths
	{
		public static string PathToConsole = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"vstest\\vstest.console.exe");
		public static string PathToTest = @"C:\";
	}
}
