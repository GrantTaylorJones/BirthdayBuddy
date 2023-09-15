using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace birthday_buddy_function_app
{
    public class daily_birthdaycheck_function
    {
        private readonly ILogger _logger;

        public daily_birthdaycheck_function(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<daily_birthdaycheck_function>();
        }

        [Function("daily_birthdaycheck_function")]
        //Runs at 10:00 UTC = 03:00 PDT
        public void Run([TimerTrigger("0 0 10 * * *")] MyInfo myTimer)
        
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
