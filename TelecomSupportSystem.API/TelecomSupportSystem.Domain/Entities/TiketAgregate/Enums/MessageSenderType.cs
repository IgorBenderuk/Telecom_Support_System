using System.Text.Json.Serialization;

namespace TelecomSupportSystem.Domain.Entities.TiketAgregate.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MessageSenderType
    {
        Unknown = 0,
        Customer = 1,
        Agent = 2,
        AI = 3
    }
}
