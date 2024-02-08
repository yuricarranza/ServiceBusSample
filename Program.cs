using MassTransit;

namespace ServiceBusSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddMassTransit(x =>
                    {
                        // elided ...
                        x.UsingAzureServiceBus((context, cfg) =>
                        {
                            cfg.Host("xxxxx");
                            cfg.ConfigureEndpoints(context);
                        });
                    });
                    services.AddHostedService<Worker>();
                })
                .Build();

            host.Run();
        }
    }
}