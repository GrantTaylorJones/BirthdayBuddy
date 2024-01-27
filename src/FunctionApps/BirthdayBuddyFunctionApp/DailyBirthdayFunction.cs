using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
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

        //Runs every day at 1 AM PST, expression is NCRONTAB, server is in East US

        //CHANGE BACK TO 0 0 4 * * * WHEN DONE !!!!!!!!!!!!!!!!!!!!!!!//
        [Function(nameof(DailyBirthdayFunction))]
        public void Run([TimerTrigger("0 * * * * *")] TimerInfo timerInfo, [BlobInput("birthdays/birthdaytest.json")]  BirthdayList birthdayList, FunctionContext context)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            _logger.LogInformation($"Retreived birthday list json file: {birthdayList}");

            //Date todaysDate = getTodaysDate()
            //checkBirthdays(todaysDate)
            //sendBirthdayEmail()
            
            _logger.LogInformation($"Next timer schedule at: {timerInfo.ScheduleStatus.Next}");
        
        }

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

