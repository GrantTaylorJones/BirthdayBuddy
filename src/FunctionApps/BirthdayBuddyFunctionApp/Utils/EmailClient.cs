using System;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;


namespace birthday_buddy_functionapp
{
    public class EmailClient
    {

        public string SenderEmailAddress { get; set; }
        public string RecepientEmailAddress { get; set; }
        public string SenderPassword { get; set; }
        public Birthday TodaysBirthdays { get; set; }

        public EmailClient(string senderEmailAddress, string senderPassword, string recepientEmailAddress, Birthday todaysBirthdays)
        {
            SenderEmailAddress = senderEmailAddress;
            SenderPassword = senderPassword;
            RecepientEmailAddress = recepientEmailAddress;
            TodaysBirthdays = todaysBirthdays;
        }

        // This return type is void because SmtpClient.Send() does not return any message or response
        public void SendBirthdayAlertEmail()
        {
            if (!this.HasValidFields()) throw new ArgumentException($"Empty or null fields in EmailClient.cs: {this.ToString()}");
            
                MimeMessage email = new MimeMessage();

                email.From.Add(new MailboxAddress("Birthday Buddy", SenderEmailAddress));
                email.To.Add(new MailboxAddress("Birthday Buddy User", RecepientEmailAddress));

                email.Subject = "You have birthdays today!";
                email.Body = new TextPart("plain")
                {
                    Text = $"Happy birthday to:\n\n{TodaysBirthdays.ToString()}"
                };

                using (var smtp = new SmtpClient())
                {
                    smtp.Connect("smtp.gmail.com", 587, false);

                    // Note: only needed if the SMTP server requires authentication
                    smtp.Authenticate(SenderEmailAddress, SenderPassword);

                    smtp.Send(email);
                    smtp.Disconnect(true);
                }
            }

            private Boolean HasValidFields()
            {
                if (
                    SenderEmailAddress == null || SenderEmailAddress.Equals("") ||
                    RecepientEmailAddress == null || RecepientEmailAddress.Equals("") ||
                    SenderPassword == null || SenderPassword.Equals("")
                ) return false;
                else return true;
            }

        }
    }