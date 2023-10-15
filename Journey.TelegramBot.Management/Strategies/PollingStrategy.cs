using Hangfire;
using Journey.Common.Settings;
using Journey.TelegramBot.Polling.Listeners;
using Journey.TelegramBot.Strategies;
using Microsoft.Extensions.Logging;

namespace Journey.TelegramBot.Management.Strategies
{
    public class PollingStrategy : IBotStrategy
    {
        private readonly ILogger<PollingStrategy> _logger;

        public PollingStrategy(ILogger<PollingStrategy> logger)
        {
            _logger = logger;
        }

        public void Init()
        {
            BackgroundJob.Enqueue<ITelegramPollingListener>(
                methodCall: u => u.StartPolling(),
                queue: RecurrentTasksConsts.PollingQueueName);

            _logger.LogInformation($"{nameof(PollingStrategy)} strategy init request sended");
        }

        public void Stop()
        {
            RecurringJob.RemoveIfExists(RecurrentTasksConsts.PollingTaskJobId);
            _logger.LogInformation($"{nameof(PollingStrategy)} strategy stop request sended");
        }
    }
}
