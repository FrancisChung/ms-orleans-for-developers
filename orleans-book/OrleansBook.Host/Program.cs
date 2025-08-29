using System;
using System.Threading.Tasks;
using Orleans;
using Orleans.Hosting;
using OrleansBook.GrainClasses;

namespace OrleansBook.Host
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = new HostBuilder().UserOrleans(
                builder =>
                {
                    builder.ConfigureApplicationParts(parts =>
                            parts.AddApplicationPart(typeof(RobotGrain).Assembly).WithReferences())
                        .UseLocalhostClustering();
                })
                .Build();

            await host.StartAsync();

            Console.WriterLine("Press Enter to stop the Silo ...");
            Console.ReadLine();

            await host.StopAsync();
        }
    }
}