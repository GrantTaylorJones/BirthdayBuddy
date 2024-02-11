using System.Net;
using System.Net.Mail;


namespace birthday_buddy_functionapp
{
    public class EmailClient
    {

        public string SenderEmailAddress { get; set; }
        public string RecepientEmailAddress { get; set; }
        public string RecepientName { get; set; }
        public string SenderPassword { get; set; }
        public IEnumerable<String> TodaysBirthdays { get; set; }

        public EmailClient(string senderEmailAddress, string recepientEmailAddress, string recepientName, string senderPassword, IEnumerable<string> todaysBirthdays)
        {
            SenderEmailAddress = senderEmailAddress;
            RecepientEmailAddress = recepientEmailAddress;
            RecepientName = recepientName;
            SenderPassword = senderPassword;
            TodaysBirthdays = todaysBirthdays;
        }



        //This is void because SmtpClient.Send() does not return any message or response.
        public void SendEmail()
        {
            if (!this.HasValidFields()) throw new ArgumentException($"Empty or null fields in EmailClient.cs: {this.ToString()}");
            MailAddress fromAddress = new MailAddress(this.SenderEmailAddress, "Birthday Buddy");
            MailAddress toAddress = new MailAddress(this.RecepientEmailAddress, "To Name");
            const string subject = "Birthday Alert!";
            const string body = "Happy Birthday: ";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, this.SenderPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

        private Boolean HasValidFields()
        {
            if (
                SenderEmailAddress == null || SenderEmailAddress.Equals("") ||
                RecepientEmailAddress == null || RecepientEmailAddress.Equals("") ||
                RecepientName == null || RecepientName.Equals("") ||
                SenderPassword == null || SenderPassword.Equals("")
            ) return false;
            else return true;
        }

    }
}