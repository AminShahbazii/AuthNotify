using Application.Interfaces;
using MassTransit;
using Shared.Contracts.Events;


namespace Infrastructure.MassTransit
{
    public class Publisher : IMessagePublisher
    {
        private readonly IPublishEndpoint _publishEndpoint; 

        public Publisher(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        public async Task PublishUserRegisterAsync( string email, string userName, string firstName, string lastName)
        {
            var message = new UserRegisteredEvent
            {
                To = email,
                UserName = userName,
                FirstName = firstName,
                LastName = lastName
            };

            await _publishEndpoint.Publish(message);
        }
    }
}
