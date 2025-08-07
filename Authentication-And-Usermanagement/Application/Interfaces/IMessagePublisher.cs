
namespace Application.Interfaces
{
    public interface IMessagePublisher
    {
        Task PublishUserRegisterAsync(string email, string userName, string firstName, string lastName);
    }
}
