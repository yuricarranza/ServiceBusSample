using MassTransit;

namespace ServiceBusSample
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IBus _bus;
        public Worker(ILogger<Worker> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Yield();
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var message = Console.ReadLine();
                var dateTime = DateTimeOffset.Now;
                await _bus.Publish(new MessageBody() { Name = message, DateTime = dateTime }, stoppingToken);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }

    
}