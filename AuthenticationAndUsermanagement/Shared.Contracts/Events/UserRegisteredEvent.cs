

namespace Shared.Contracts.Events
{
    public record UserRegisteredEvent : BaseEmailMessage
    {
        public override string To { get; init; } /// send to who. To == Email
        public string UserName { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public override EmailType EmailType { get; init; }
    }
    public enum EmailType
    {
        Welcome,
        Message
    }
}
