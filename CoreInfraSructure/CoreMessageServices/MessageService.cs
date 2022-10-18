using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace CoreInfraSructure.CoreMessageServices;

public class MessageService:IMessageService
{
    private MessageOption MessageOption;
    public MessageService(IOptionsSnapshot<MessageOption>messageOption)
    {
        MessageOption = messageOption.Value;
    }
    
    
    public async Task<MessageResult> SendMessageAsync(string sender, string receptor, string message)
    {
        var client = new RestClient("https://api.kavenegar.com/v1/");
        var request = new RestRequest("/sms/send.json",Method.Post);
        request.AddHeader("apikey", MessageOption.ApiKey);
        
        request.AddParameter("receptor", receptor);
        request.AddParameter("sender", sender);
        request.AddParameter("message", message);
        
        
        var response = await client.ExecuteAsync(request);
        
        
        var result = !String.IsNullOrEmpty(response.Content)
            ? JsonConvert.DeserializeObject<MessageResult>(response.Content)
            : new MessageResult(){message = "something went wrong",status = 500,statustext = "Server error"};
     
        return new MessageResult() {message = "error found in server", status = 500, statustext = "ServerError"};
    }
}