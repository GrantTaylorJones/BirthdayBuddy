using System;
<<<<<<< HEAD
=======
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using birthdayBuddyFunctionApp;
>>>>>>> main
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace birthday_buddy_functionapp
{
<<<<<<< HEAD
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
=======
    public class DailyBirthdayFunction
    {
        private readonly ILogger _logger;

        public DailyBirthdayFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<DailyBirthdayFunction>();
        }

        //every 3 AM8
        //public void Run([TimerTrigger("0 0 3 * * *")] MyInfo myTimer)
        //<docsnippet_fixed_delay_retry_example>
        [Function(nameof(DailyBirthdayFunction))]
        [FixedDelayRetry(5, "00:00:10")]
        public static void Run([TimerTrigger("0 0 3 * * *")] TimerInfo timerInfo,
        FunctionContext context)
        {
            var logger = context.GetLogger(nameof(DailyBirthdayFunction));
            // string birthdaysJsonFileAsText = File.ReadAllText(@"resources/local/birthdays.json");
            // var birthdays = JsonSerializer.Deserialize<AllBirthdaysList>(birthdaysJsonFileAsText);
            // List<string> todaysBirthdays = new List<string>();
            // DateTime today = DateTime.Now;

            // foreach (var birthday in birthdays.Birthdays){
            //     //null
            //     if(birthday.Date == today) todaysBirthdays.Add(birthday.PeopleBornOnThisDate);
            //     //TODO: how to use IEnumerator;
            // }
>>>>>>> main
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
