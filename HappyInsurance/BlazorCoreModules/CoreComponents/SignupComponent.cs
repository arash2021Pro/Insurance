using System.Runtime.CompilerServices;
using System.Text.Json;
using CoreApplication.CoreManagementApplication;
using CoreBussiness.BussinessEntity.OneTimePassword;
using CoreBussiness.BussinessEntity.Refferals;
using CoreBussiness.BussinessEntity.Users;
using CoreBussiness.BussinessEntity.Wallets;
using CoreBussiness.RepsPattern;
using CoreInfraSructure.CoreEmailServices;
using Hangfire;
using HappyInsurance.BlazorCoreModules.RandomeGenerator;
using Microsoft.AspNetCore.Components;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;


namespace HappyInsurance.BlazorCoreModules.CoreComponents;

public class SignupComponent:ComponentBase
{
    [Inject] private ICoreManagerService _coreManagerService { get; set; }
    [Inject]private  IUnitOfWork _work { get; set; }
    [Inject]private NavigationManager _navigationManager { get; set; }
    [Inject] private ICodeGeneratorService _codeGeneratorService { get; set; }
    [Inject]private IEmailService _emailService { get; set; }
 
    public string Message { get; set; }
 
    
    public async Task SignupAsync(SignupModel signupModel)
    {
        var IsCompleted = true;
        var result = await _coreManagerService.UserService.IsPhoneExistsAsync(signupModel.PhoneNumber);
        if (result)
        {
            Message = "User already exists";
            IsCompleted = false;
        }
        if (IsCompleted)
        {
            if (!String.IsNullOrEmpty(signupModel.Code))
            {
                var userOwner = await _coreManagerService.UserService.GetUserAsync(signupModel.Code);
                var Referral = new Refferal();
                
                
                Referral.ReferralCount += 1;
                Referral.UserId = userOwner.Id;

                await _coreManagerService.ReferralService.AddNewReferralAsync(Referral);
                
                
                await _work.SaveChangesAsync();
            }
            var User = new User()
            {
                PhoneNumber = signupModel.PhoneNumber,NationalCode = signupModel.NationalCode, Password = signupModel.Password, Name = signupModel.Name,
                LastName = signupModel.LastName,IsObedient = signupModel.IsRuleAccepted,
                RoleId = 3
            };
            var Otp = new OTP() {code = _codeGeneratorService.Generate(5), User = User};
            await _coreManagerService.OtpService.AddNewOtpCodeAsync(Otp);
            await _coreManagerService.UserService.SignupUserAsync(User);
            var save = await _work.SaveChangesAsync();
            if (save > 0)
            {
                 //BackgroundJob.Enqueue(() => _emailService.SendEmailAsync("arash","New Verification Code",null,User.Email,Otp.code,null));
                 _navigationManager.NavigateTo($"/Verification/Account?PhoneNumber={User.PhoneNumber}");
            }
            Message = "Something went wrong";
        }
    }
    
}