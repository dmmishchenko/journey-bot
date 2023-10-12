using Hangfire;
using Journey.Common.Settings;
using Journey.TelegramBot.Polling.Listeners;
using Journey.TelegramBot.Strategies;
using Microsoft.Extensions.Logging;

namespace Journey.TelegramBot.Polling.Strategy
{
    internal class PollingStrategy : IBotStrategy
    {
        private readonly ILogger<PollingStrategy> _logger;

        public PollingStrategy(ILogger<PollingStrategy> logger)
        {
            _logger = logger;
        }

        public void Init()
        {
            RecurringJob.AddOrUpdate<TelegramPollingListener>(recurringJobId: RecurrentTasksConsts.PollingTaskJobId, methodCall: u => u.StartPolling(), cronExpression: RecurrentTasksConsts.Every2SecondsCron, queue: RecurrentTasksConsts.PollingQueueName);
            _logger.LogInformation($"{nameof(PollingStrategy)} strategy init request sended");
        }

        public void Stop()
        {
            RecurringJob.RemoveIfExists(RecurrentTasksConsts.PollingTaskJobId);
            _logger.LogInformation($"{nameof(PollingStrategy)} strategy stop request sended");
        }
    }
}
