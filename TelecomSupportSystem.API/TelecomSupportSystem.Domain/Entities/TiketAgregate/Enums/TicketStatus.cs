using System.Text.Json.Serialization;

namespace TelecomSupportSystem.Domain.Entities.TiketAgregate.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TicketStatus
    {
        Open,
        AiHandling,
        WaitingAgent,
        OnAgentModeration,
        Resolved,
        Closed
    }
}
