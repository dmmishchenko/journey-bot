namespace Journey.Common.Settings
{
    public static class RecurrentTasksConsts
    {
        public const int MainAppWorkersCount = 10;
        public const string HangfireSchema = "hf_bot_main";

        public const string Every30SecondsCron = "*/30 * * * * *";
        public const string Every2SecondsCron = "*/2 * * * * *";

        public const string PollingTaskJobId = "polling_main";

        public const string PollingQueueName = "polling";
    }
}
