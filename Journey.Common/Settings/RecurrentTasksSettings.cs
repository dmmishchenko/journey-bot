namespace Journey.Common.Settings
{
    public static class RecurrentTasksSettings
    {
        public const string Every30SecondsCron = "*/30 * * * * *";

        public const string PollingTaskJobId = "polling_main";

        public const string PollingQueueName = "polling";
    }
}
