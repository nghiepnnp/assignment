using Application.Common.Interfaces;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IPasswordUpdateService _passwordUpdateService;

        public Worker(ILogger<Worker> logger, IPasswordUpdateService passwordUpdateService)
        {
            _logger = logger;
            _passwordUpdateService = passwordUpdateService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await _passwordUpdateService.ProcessUsersAsync();
                }
                catch (Exception ex)
                {
                    // TODO: Send email to admin to report error
                    _logger.LogInformation($"An error occurred: {DateTimeOffset.Now} - {ex.Message}");
                }
                finally
                {
                    _logger.LogInformation($"Worker running at: {DateTimeOffset.Now}");
                    await Task.Delay(TimeSpan.FromHours(12), stoppingToken); // run once every half day
                    //await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken); // run every 5 seconds.
                }
            }   
        }
    }
}
