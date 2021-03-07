using EventTriggers.DataPersistence;
using EventTriggers.Models.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EventTriggers.Web.Service
{
    public class Worker : BackgroundService
    {
        public Worker(IEventTriggersRepository repository, ILogger<Worker> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var doesNotProcessedTriggers = await GetDoesNotProcessedTriggers();
                if (doesNotProcessedTriggers.Any())
                {
                    ProcessTriggers(doesNotProcessedTriggers);
                }

                await Task.Delay(1000, stoppingToken);
            }
        }

        private void ProcessTriggers(IEnumerable<Event> events)
        {
        }

        private async Task<IList<Event>> GetDoesNotProcessedTriggers()
        {
            return (await _repository.GetAll()).ToList();
        }

        private readonly ILogger<Worker> _logger;
        private readonly IEventTriggersRepository _repository;
    }
}