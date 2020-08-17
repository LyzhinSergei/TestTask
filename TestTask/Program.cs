using Microsoft.Extensions.DependencyInjection;
using System;
using TestTask.constants;
using TestTask.Interface;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationManager.ConfigureServices(new ServiceCollection());
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
            logger.Info("Start program >>>");
            MyConsole.StartConsole();
            IRunner runner = new Runner(logger);
            runner.ConfigureTest();
            Console.WriteLine();
            Console.WriteLine("Execution complete!");
            logger.Info("End program <<<");
        }
    }
   
}
