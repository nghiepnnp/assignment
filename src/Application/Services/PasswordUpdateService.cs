using Application.Common.Interfaces;
using Domain;
using Domain.Constants;
using Domain.Exercise1;

namespace Application.Services
{
    /// <summary>
    /// Password Update Service
    /// </summary>
    public class PasswordUpdateService : IPasswordUpdateService
    {
        private readonly MockDataService _dataService;
        private readonly IEmailService _emailService;
        private readonly ILogger<IPasswordUpdateService> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataService"></param>
        /// <param name="emailService"></param>
        /// <param name="logger"></param>
        public PasswordUpdateService(MockDataService dataService, IEmailService emailService, ILogger<IPasswordUpdateService> logger)
        {
            _dataService = dataService;
            _emailService = emailService;
            _logger = logger;
        }

        /// <summary>
        /// Process Users Async
        /// </summary>
        /// <returns></returns>
        public async Task ProcessUsersAsync()
        {
            var users = _dataService.GetUsers()
                                 .Where(u => u.LastUpdatePwd <= DateTime.Now.AddMonths(-6)
                                        && u.Status != UserStatus.REQUIRE_CHANGE_PASSWORD)
                                 .ToList();

            foreach (var user in users)
            {
                try
                {
                    user.Status = UserStatus.REQUIRE_CHANGE_PASSWORD;
                    _dataService.UpdateUser(user);

                    await _emailService.SendAsync(user.Email, "Password Update Required", "Please update your password.");
                    _logger.LogInformation($"Notified user {user.Email} to update password.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Failed to process user {user.Email}");
                }
            }
        }
    }
}
