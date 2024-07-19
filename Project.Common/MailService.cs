using System.Net;
using System.Net.Mail;

namespace Project.Common
{
    public static class MailService
    {
        public static void Send(string subject, string body,string receiver,string password = "oktczfjzfohickzn", string sender = "yzlm3170@gmail.com")
        {
            MailAddress senderMail = new MailAddress(sender);
            MailAddress receiverMail = new MailAddress(receiver);

            SmtpClient smtp = new()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderMail.Address, password)

            };
            using (MailMessage message = new MailMessage(senderMail, receiverMail)
            {
                Body = body,
                Subject = subject
            })
            {
                smtp.Send(message);
            };
        }
    }
}
