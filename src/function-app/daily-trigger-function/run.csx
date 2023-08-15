using System;

public static void Run(TimerInfo myTimer, ILogger log)
{
    log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

    //check database for todays date, get who evers names are there.
    //email me if birthday
}
