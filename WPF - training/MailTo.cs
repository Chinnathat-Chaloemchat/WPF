using System;
using System.Net;
using System.Net.Mail;

namespace WPF___training
{
    internal class MailTo
    {
        public static void SendMail(string sender, string password, string receiver, string subject, string content)
        {
            if (string.IsNullOrWhiteSpace(sender) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(receiver))
                throw new ArgumentException("Expéditeur, mot de passe et destinataire sont obligatoires.");

            try
            {
                MailMessage message = new MailMessage(sender, receiver, subject, content);

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(sender, password);
                    smtp.EnableSsl = true;
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur lors de l'envoi : {ex.Message}", ex);
            }
        }
    }
}
