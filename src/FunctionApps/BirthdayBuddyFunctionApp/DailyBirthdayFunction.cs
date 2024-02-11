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

        
        /// <summary>
        /// This is a method recognized as a function - see https://learn.microsoft.com/en-us/azure/azure-functions/dotnet-isolated-process-guide?tabs=windows
        /// Defult name is Run, but the method name can be any valid C# method name. 
        /// This function runs every day at 1 AM PST, expression is NCRONTAB, server is in East US Time, hence 4 as the hour.
        /// </summary>
        /// <param name="timerInfo">Azure Default Param - Contains scheduling information</param>
        /// <param name="birthdayList"> Maps the JSON input to a BirthdayList object</param>
        /// <param name="context">Azure Default Param -Invocation context, information about your invocation and methods used for logging</param>
        [Function(nameof(DailyBirthdayFunction))]
        public void Run([TimerTrigger("0 * * * * *")] TimerInfo timerInfo, [BlobInput("birthdays/birthdays.json")] BirthdayList birthdayList, FunctionContext context)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            try
            {
                if (birthdayList == null) throw new Exception("birthdayList argument is null (blob input)");

                Birthday todaysBirthday = BirthdayUtil.GetTodaysBirthdays(birthdayList);
                if (todaysBirthday.People.Any())
                {
                    _logger.LogInformation($"Happy Birthday to \n{todaysBirthday.ToString()}");
                    EmailClient emailClient = new EmailClient(
                        Environment.GetEnvironmentVariable("APP_GMAIL_ACCOUNTNAME"),
                        Environment.GetEnvironmentVariable("APP_GMAIL_PASSWORD"),
                        Environment.GetEnvironmentVariable("RECEPIENT_GMAIL_ACCOUNTNAME"),
                        todaysBirthday
                    );
                    emailClient.SendBirthdayAlertEmail();
                }

            }
            catch (Exception exception)
            {
                _logger.LogError($"Exception thrown. Error message: '{exception.Message}'");
            }

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