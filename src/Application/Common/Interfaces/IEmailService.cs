namespace Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(string email, string subject, string message);
    }
}