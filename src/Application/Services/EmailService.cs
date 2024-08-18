using Application.Common.Interfaces;

namespace Application.Services
{
    /// <summary>
    /// Email Service
    /// </summary>
    public class EmailService : BaseService<EmailService>, IEmailService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        public EmailService(ILogger<EmailService> logger) : base(logger)
        { }

        /// <summary>
        /// SendAsync
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendAsync(string email, string subject, string message)
        {
            // Logic sent email

            Logger.LogInformation($"Email sent to {email} success.");
        }
    }
}
