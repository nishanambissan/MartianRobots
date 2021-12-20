using System;
using System.Collections.Generic;
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

            Console.WriteLine("Instruction guideline...3 lines per robot. First line - upper coords of grid, Second line - start position(co-ords and orientation), like 11E. Third line - instruction list like 'FRLFRRFL'");
            Console.WriteLine("Press enter to start and Press Q to quit or stop");

            var programArgs = new List<string>();


            while (true)
            {
                var input = Console.ReadLine();
                if (!DetectExitCode(input))
                {
                    programArgs.Add(input);
                }
                else
                {
                    break;
                }
            }
            
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                IInputDecoder processor = serviceProvider.GetService<IInputDecoder>();
                processor?.Decode(programArgs.ToArray());
            }
        }

        private static bool DetectExitCode(string input)
        {
            if (input.Equals("q", StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
            return false;
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IInstructionProcessor, BasicInstructionProcessor>();
            services.AddScoped<IInputDecoder, BasicInputDecoder>();

            services.AddLogging();
        }
    }
}
