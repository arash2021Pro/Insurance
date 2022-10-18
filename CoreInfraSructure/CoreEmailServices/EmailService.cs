using System.Net;
using System.Net.Mail;
using FluentEmail.Core;
using FluentEmail.Smtp;

namespace CoreInfraSructure.CoreEmailServices;

public class EmailService:IEmailService
{
    public async Task SendEmailAsync(string sender,string subject,string?SenderName, string receptor, string message, string? receptorName)
    {

   
        
        var user = new SmtpSender(() => new SmtpClient("smtp.gmail.com")
        {
            UseDefaultCredentials = false,
            Port = 587,
            Credentials = new NetworkCredential("", ""),
            EnableSsl = true,
        });

        Email.DefaultSender = user;
        var email = Email
            .From(sender, SenderName)
            .To(receptor, receptorName)
            .Subject(subject)
            .HighPriority()
            .Body(message);
        
        var response = await email.SendAsync();
    }
}