using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace birthday_buddy_functionapp
{
    public class daily_birthday_function
    {
        private readonly ILogger _logger;

        public daily_birthday_function(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<daily_birthday_function>();
        }

        [Function("daily_birthday_function")]
        public void Run([TimerTrigger("0 0 3 * * *")] MyInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        }
    }

    public class MyInfo
    {
        public MyScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MyScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}