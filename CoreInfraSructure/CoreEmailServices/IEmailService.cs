namespace CoreInfraSructure.CoreEmailServices;

public interface IEmailService
{
    Task SendEmailAsync(string sender,string subject,string?SenderName, string receptor, string message, string? receptorName);
}