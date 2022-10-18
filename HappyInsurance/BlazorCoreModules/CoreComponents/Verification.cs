using System.ComponentModel.DataAnnotations;
using CoreApplication.CoreManagementApplication;
using CoreApplication.UserApplication;
using CoreBussiness.BussinessEntity.OneTimePassword;
using CoreBussiness.BussinessEntity.Users;
using CoreBussiness.RepsPattern;
using CoreInfraSructure.CoreEmailServices;
using Hangfire;
using HappyInsurance.BlazorCoreModules.CoreAuthenticationService;
using HappyInsurance.BlazorCoreModules.RandomeGenerator;
using HappyInsurance.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HappyInsurance.BlazorCoreModules.CoreComponents;

public class Verification:ComponentBase
{
    [Inject]private IUnitOfWork Work { get; set; }
    [Inject]private ICoreManagerService _coreManagerService { get; set; }
    [Inject]private IHttpContextAccessor _contextAccessor { get; set; }
    [Inject] private NavigationManager _navigationManager { get; set; }
    [Inject] private ICodeGeneratorService _codeGeneratorService { get; set; }
    [Inject]private IEmailService _emailService { get; set; }
    
    [Parameter]
    [SupplyParameterFromQuery]
    public string PhoneNumber { get; set; }
    public string Message { get; set; }
    public string ErrorMessage { get; set; }
    public bool IsGenerated{ get; set; } = false;
    public async Task VerifyAsync(VerificationModel verificationModel)
    {
      
        var otp =  await _coreManagerService.OtpService.GetOtpAsync(verificationModel.Code);
        
        var user = await _coreManagerService.UserService.GetUserAsyncByIdAsync(otp.UserId);
     
        if (otp.IsAuthentic) 
        {
          otp.IsUsed = true;
          user.UserStatus = UserStatus.Active;
          var change = await Work.SaveChangesAsync();
          if (change > 0)
          { 
              _navigationManager.NavigateTo("/Login");
          }
          ErrorMessage = "Something got wrong"; 
        } 
        ErrorMessage = "your otp code is not authentic";
    }
    
    public async Task GenerateNewCodeAsync()
    {
        var otp = new OTP();
        otp.UserId = _contextAccessor.HttpContext.User.GetCurrentUserId();
        otp.code = _codeGeneratorService.Generate(5);
        var user = await _coreManagerService.UserService.GetUserAsyncByIdAsync(otp.UserId);
        await _coreManagerService.OtpService.AddNewOtpCodeAsync(otp);
        var change =  await Work.SaveChangesAsync();
        if (change > 0)
        {
            Message = "New Message Sent";
            //BackgroundJob.Enqueue(() => _emailService.SendEmailAsync("arash","New Verification Code",null,user.Email,otp.code,null));
        }
        else
        {
            Message = "Something went wrong";
        }
    }
    

}