using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using birthdayBuddyFunctionApp;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace birthday_buddy_functionapp
{
    public class DailyBirthdayFunction
    {
        private readonly ILogger _logger;

        public DailyBirthdayFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<DailyBirthdayFunction>();
        }

        [Function("DailyBirthdayFunction")]
        public void Run([TimerTrigger("0 0 3 * * *")] MyInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            string birthdaysJsonFileAsText = File.ReadAllText(@"resources/local/birthdays.json");
            var birthdays = JsonSerializer.Deserialize<AllBirthdaysList>(birthdaysJsonFileAsText);



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
