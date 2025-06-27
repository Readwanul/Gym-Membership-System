using System;
using System.Net;
using System.Net.Mail;

public class EmailService
{
    private string _smtpServer = "smtp.gmail.com";
    private int _smtpPort = 587;
    private string _smtpUsername = "readwanul@gmail.com"; // Your email address
    private string _smtpPassword = "CODE123@"; // Use App Password if 2-step verification is enabled
    private string _fromEmail = "readwanul@gmail.com"; // From email address

    public void SendEmail(string toEmail, string subject, string body)
    {
        try
        {
            var smtpClient = new SmtpClient(_smtpServer)
            {
                Port = _smtpPort,
                Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
                EnableSsl = true // Enable SSL for security
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_fromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true, // Allow HTML in email body
            };

            mailMessage.To.Add(toEmail); // Add the recipient's email address

            smtpClient.Send(mailMessage); // Send email synchronously
            Console.WriteLine("Email sent successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending email: {ex.Message}");
            
        }
    }
}
