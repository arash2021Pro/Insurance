using CoreApplication.CoreManagementApplication;
using CoreBussiness.BussinessEntity.OneTimePassword;
using CoreBussiness.RepsPattern;
using CoreInfraSructure.CoreMessageServices;
using Hangfire;
using HappyInsurance.BlazorCoreModules.RandomeGenerator;
using Microsoft.AspNetCore.Components;

namespace HappyInsurance.BlazorCoreModules.CoreComponents;

public class ForgetPassComponent:ComponentBase
{
    [Inject] private ICoreManagerService _coreManagerService { get; set; }
    [Inject]private NavigationManager _navigationManager { get; set; }
    [Inject]private IMessageService _messageService { get; set; }
    [Inject] private ICodeGeneratorService _codeGeneratorService { get; set; }
    [Inject] private IUnitOfWork _work { get; set; }
    public string Message { get; set; }
    public class ForgetPassModel { public string PhoneNumber { get; set; } }
    
    public async Task CheckUserPhoneAsync(ForgetPassModel passModel)
    {
        
        if (!String.IsNullOrEmpty(passModel.PhoneNumber))
        {
            var isCompleted = true;
            var user = await _coreManagerService.UserService.GetUserAsyncByPhone(passModel.PhoneNumber);
            if (user == null)
            {
                Message = "User not found";
                isCompleted = false;
            }
            if (isCompleted)
            {
                var code = _codeGeneratorService.Generate(5);
                var otp = new OTP() {code = code,UserId = user.Id};
                await _coreManagerService.OtpService.AddNewOtpCodeAsync(otp);
                var save = await _work.SaveChangesAsync();
                if (save > 0)
                {
                    // BackgroundJob.Enqueue(() => _messageService.SendMessageAsync("HappyInsurance", passModel.PhoneNumber, code));
                    _navigationManager.NavigateTo($"/AuthorizeCode/User?PhoneNumber={passModel.PhoneNumber}");
                }
                else
                {
                    Message = "Something went wrong";
                }
            }
        }
        else
        {
            Message = "PhoneNumber is required";
        }
       
    }
}