namespace CoreInfraSructure.CoreMessageServices;

public interface IMessageService
{
    Task<MessageResult> SendMessageAsync(string sender, string recptor, string message);
}