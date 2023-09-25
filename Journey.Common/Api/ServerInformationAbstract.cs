using static Journey.Common.Enums.ServerTypes;

namespace Journey.Common.Api
{
    public abstract class ServerInformationAbstract
    {
        public string Message { get; init; }
        public ServerErrorCodes? Code { get; init; }
        public ServerMessageTypes? Type { get; init; }
    }
}
