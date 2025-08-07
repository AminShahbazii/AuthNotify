using Shared.Contracts.Enums;

namespace Shared.Contracts
{
    public abstract record BaseEmailMessage
    {
        public abstract string To { get; init; }
        public abstract EmailType EmailType { get; init; }
    }
}
