using MailKit.Net.Smtp;
using MimeKit;

namespace birthday_buddy_functionapp
{
    public class EmailClient
    {

        public string SenderEmailAddress { get; set; }
        public string SenderPassword { get; set; }

        public EmailClient(string senderEmailAddress, string senderPassword)
        {
            SenderEmailAddress = senderEmailAddress;
            SenderPassword = senderPassword;

        }

        // This return type is void because SmtpClient.Send() does not return any message or response
        public void SendEmail(string recepientEmailAddress, string subject, string body)
        {
            if (!this.HasValidFields(this.SenderEmailAddress, this.SenderPassword, recepientEmailAddress)) throw new ArgumentException($"Empty or null fields in EmailClient.cs: {this.ToString()}");

            MimeMessage email = ConstructMimeEmail(SenderEmailAddress, recepientEmailAddress, subject, body);

            SendEmail(email);
        }

        private void SendEmail(MimeMessage email){
            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, false);

                // Note: only needed if the SMTP server requires authentication
                smtp.Authenticate(SenderEmailAddress, SenderPassword);

                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }

        private MimeMessage ConstructMimeEmail(string senderEmailAddress, string recepientEmailAddress, string subject, string body){
            MimeMessage email = new MimeMessage();

            email.From.Add(new MailboxAddress("Birthday Buddy", senderEmailAddress));
            email.To.Add(new MailboxAddress("Birthday Buddy User", recepientEmailAddress));

            email.Subject = subject;
            email.Body = new TextPart("plain")
            {
                Text = body
            };

            return email;
        }

        private Boolean HasValidFields(string senderEmailAddress, string senderPassword, string recepientEmailAddress)
        {
            if (
                senderEmailAddress == null || senderEmailAddress.Equals("") ||
                senderPassword == null || senderPassword.Equals("") ||
                recepientEmailAddress == null || recepientEmailAddress.Equals("")
            ) return false;
            else return true;
        }

    }
}