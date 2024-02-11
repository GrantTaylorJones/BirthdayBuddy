# Birthday Buddy v1.0
Birthday Buddy v1.0 is a serverless daily function, that will email me the list of my family and friends' birthdays that fall on the current day. 

 > After discussing with some friends, it seems the opinion on the best way to be alerted (if at all) is mixed. The long term goal for 2.0, is a tool that others can use as well. With that said, I would eventually lke to create customizable alerts for a mobile app, that can either email, SMS, or send a push notification.


## 1.0 Design
Storing Birthday Data
- The data set is relatively small, and not often changed. I am opting just to use blob storage within the Azure Function App's Storage Account. The list of birthdays is represented as an object in a JSON file. If I am adding birthdays more often, I would like to find a different way to add data, other than editing the JSON manually.

Core Functionality / Service
- At the core of this will be a timer trigger Azure Function that will running the show. The function will run everyday at 01:00 PST, and take in blob storage as an input binding to get the birthday data. It will check if there are any items for the current day, and if results are returned, it will send those emails via SMTP. Note that this function is running as the isolated worker model, as opposed to in-process. For reference, see the [Microsoft Documentation](https://learn.microsoft.com/en-us/azure/azure-functions/dotnet-isolated-in-process-differences) on the trade offs.

![Architecture Image File](resources/images/birthday-buddy-architecture.png)

## Note about sending emails
Originally, I thought I would have to use some specific product API, and set up a client to use Gmail, Outlook, or another email service. However, this lead me to learning about SMTP servers, which made everything much simpler.  

### Common SMTP server providers and settings
| SMTP Provider | URL | SMTP Settings |
| ----------- | ----------- | ----------- |
| AOL | aol.com | smtp.aol.com |
| AT&T | att.net | smtp.mail.att.net |
| Comcast | comcast.net | smtp.comcast.net |
| iCloud | icloud.com/mail | smtp.mail.me.com |
| Gmail | gmail.com | smtp.gmail.com |
| Outlook | outlook.com | smtp-mail.outlook.com |
| Yahoo! | mail.yahoo.com | smtp.mail.yahoo.com |

### Useful links
[Creating azure function app via CLI](https://learn.microsoft.com/en-us/azure/azure-functions/create-first-function-cli-csharp?tabs=windows%2Cazure-cli)

[Sending Email via SMTP in .NET](https://developers.google.com/api-client-library/dotnet/apis/gmail/v1)

[Microsoft Official SMTP Reference](https://learn.microsoft.com/en-us/dotnet/api/system.net.mail.smtpclient?view=net-6.0#:~:text=Important,used%20on%20GitHub)