namespace JourneyBot.Common.Enum
{
    public enum SessionStates : byte
    {
        Created = 0,
        Started = 1,
        Paused = 2,
        Cancelled = 3,
        Error = 255
    }
}
