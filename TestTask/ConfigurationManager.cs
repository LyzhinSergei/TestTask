using Microsoft.Extensions.DependencyInjection;
using TestTask.Interface;

namespace TestTask
{
	public class ConfigurationManager
	{
        public static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddTransient<IRunner, Runner>()
                .BuildServiceProvider();
        }
    }
}
