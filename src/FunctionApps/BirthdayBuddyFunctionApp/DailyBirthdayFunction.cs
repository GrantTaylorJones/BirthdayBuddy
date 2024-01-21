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
        [Function(nameof(DailyBirthdayFunction))]
        public void Run([TimerTrigger("0 0 4 * * *")] TimerInfo timerInfo, FunctionContext context)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            //get todays birthdays

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

