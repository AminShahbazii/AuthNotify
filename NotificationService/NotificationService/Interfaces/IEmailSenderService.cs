using NotificationService.Models.Email;
using Shared.Contracts;


namespace NotificationService.Interfaces
{
    public interface IEmailSenderService
    {
        Task SendAsync<T>(T msg, Content content) where T : BaseEmailMessage;
    }
}
