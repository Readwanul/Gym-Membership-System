using System;
using System.Net;
using System.Net.Mail;

public class EmailService
{
    private string _smtpServer = "smtp.gmail.com";
    private int _smtpPort = 587;
    private string _smtpUsername = "readwanulh@gmail.com"; 
    private string _smtpPassword = ""; 
    private string _fromEmail = "readwanulh@gmail.com"; 

    public void SendEmail(string toEmail, string subject, string body)
    {
        try
        {
            var smtpClient = new SmtpClient(_smtpServer)
            {
                Port = _smtpPort,
                Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
                EnableSsl = true 
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_fromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true, 
            };

            mailMessage.To.Add(toEmail); 

            smtpClient.Send(mailMessage); 
            Console.WriteLine("Email sent successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending email: {ex.Message}");

        }
    }
}
