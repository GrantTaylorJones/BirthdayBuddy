using System.Net;
using System.Net.Mail;


namespace birthday_buddy_functionapp
{
    public class EmailClient
    {
        public void SendEmail()
        {

            MailAddress fromAddress = new MailAddress("from@gmail.com", "From Name");
            MailAddress toAddress = new MailAddress("to@example.com", "To Name");
            const string fromPassword = "your_gmail_password";
            const string subject = "Subject";
            const string body = "Body";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
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
    }
}