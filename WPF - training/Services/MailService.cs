using System.Net;
using System.Net.Mail;

namespace WPF___training.Services
{
    internal static class MailService
    {
        public static void Send(string sender, string password, string receiver, string subject, string content)
        {
            using (var message = new MailMessage(sender, receiver, subject, content))
            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.Credentials = new NetworkCredential(sender, password);
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
        }
    }
}
