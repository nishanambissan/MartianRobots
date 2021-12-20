using System.IO;
using MartianRobots.Services;
using MartianRobots.Services.Implementations;
using MartianRobots.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MartianRobots
{
    public class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                IInputDecoder processor = serviceProvider.GetService<IInputDecoder>();
                processor?.Decode(args);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IInstructionProcessor, BasicInstructionProcessor>();
            services.AddScoped<IInputDecoder, BasicInputDecoder>();

            services.AddLogging();
        }
    }
}
