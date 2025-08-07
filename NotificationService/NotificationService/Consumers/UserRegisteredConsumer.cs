using MassTransit;
using NotificationService.Interfaces;
using NotificationService.Models.Email;
using Shared.Contracts.Events;

namespace NotificationService.Consumers
{
    public class UserRegisteredConsumer : IConsumer<UserRegisteredEvent>
    {

        private readonly ILogger<UserRegisteredConsumer> _logger;
        private readonly IEmailSenderService _emailSender;

        public UserRegisteredConsumer(ILogger<UserRegisteredConsumer> logger, IEmailSenderService emailSender)
        {
            _logger = logger;
            _emailSender = emailSender;
        }

        public async Task Consume(ConsumeContext<UserRegisteredEvent> context)
        {
            _logger.LogInformation("Consuming message: {@Message}", context.Message);

            var message = context.Message;


            var reContent = new Content
            {
                Subject = "🎉 Welcome to Our Platform!",
                Body = $"Hi {message.FirstName} {message.LastName},\n\nThank you for registering on our website. We're excited to have you!"
            };


            try
            {
                await _emailSender.SendAsync(message, reContent);

                _logger.LogInformation($"Email sent to: {message.To}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while sending welcome email to {Email}", message.To);
                throw;
            }
        }
    }
}
