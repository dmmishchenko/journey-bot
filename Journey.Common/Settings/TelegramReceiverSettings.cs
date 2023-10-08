namespace Journey.Common.Settings
{
    public class TelegramReceiverSettings
    {
        public string[] AllowedUpdates { get; set; }
        public bool ThrowPendingUpdates { get; set; }
    }
}
