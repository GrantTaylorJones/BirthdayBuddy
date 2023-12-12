using System;
using System.Linq;
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
        //every 3 AM8
        //public void Run([TimerTrigger("0 0 3 * *")] MyInfo myTimer)
        public void Run([TimerTrigger("* * * * *")] MyInfo myTimer,[BlobInput("birthdays/birthdays.json")] string myBlob,
            FunctionContext context)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            string birthdaysJsonFileAsText = File.ReadAllText(@"resources/local/birthdays.json");
            var birthdays = JsonSerializer.Deserialize<AllBirthdaysList>(birthdaysJsonFileAsText);
            List<string> todaysBirthdays = new List<string>();
            DateTime today = DateTime.Now;

            // foreach (var birthday in birthdays.Birthdays){
            //     //null
            //     if(birthday.Date == today) todaysBirthdays.Add(birthday.PeopleBornOnThisDate);
            //     //TODO: how to use IEnumerator;
            // }

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
