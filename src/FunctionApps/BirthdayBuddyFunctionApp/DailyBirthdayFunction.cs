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
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="timerInfo"></param>
        /// <param name="birthdayList"></param>
        /// <param name="context"></param>
        [Function(nameof(DailyBirthdayFunction))]
        public void Run([TimerTrigger("0 0 4 * * *")] TimerInfo timerInfo, [BlobInput("birthdays/birthdays.json")]  BirthdayList birthdayList, FunctionContext context)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            try{
                if(birthdayList == null) throw new Exception("birthdayList argument is null (blob input)");

                string todaysDate = DateTime.Now.ToString("MM/dd");
                Birthday todaysBirthday = GetBirthdays(todaysDate, birthdayList);
                if(todaysBirthday.People.Count() > 0){
                    //sendEmailWithTodaysBirthdayNames(todaysBirthdays.People);
                }
                
            }
            catch(Exception exception){
                _logger.LogError($"Exception thrown. Error message: '{exception.Message}'");
            }

            _logger.LogInformation($"Next timer schedule at: {timerInfo.ScheduleStatus.Next}");        
        }

        public Birthday GetBirthdays(string dateAsMonthSlashYear, BirthdayList birthdayList){
            foreach (Birthday birthday in birthdayList.Birthdays){
                if (birthday.Date == dateAsMonthSlashYear) return birthday;
            }
            return new Birthday();
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