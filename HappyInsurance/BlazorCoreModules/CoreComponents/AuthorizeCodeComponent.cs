using CoreApplication.CoreManagementApplication;
using CoreBussiness.RepsPattern;
using Microsoft.AspNetCore.Components;

namespace HappyInsurance.BlazorCoreModules.CoreComponents;

public class AuthorizeCodeComponent:ComponentBase
{
    [Inject] private ICoreManagerService _coreManagerService { get; set; }
    [Inject]private IUnitOfWork _work { get; set; }
    [Inject]private NavigationManager _navigationManager { get; set; }
    public string Message { get; set; }
    [Parameter]
    [SupplyParameterFromQuery]
    public string PhoneNumber { get; set; }
    public class CodeModel
    {
        public string Code { get; set; }
    }
    public async Task CheckCodeAsync(CodeModel codeModel)
    {
 
        var otp = await _coreManagerService.OtpService.GetOtpAsync(codeModel.Code);
        var user = await _coreManagerService.UserService.GetUserAsyncByIdAsync(otp.UserId);
        if (otp.IsAuthentic)
        {
            otp.IsUsed = true;
            var save = await _work.SaveChangesAsync();
            if (save > 0)
            {
              _navigationManager.NavigateTo($"/SetNewPassword?PhoneNumber={user.PhoneNumber}");
            }
            else
            {
                Message = "Something went wrong";
            }
        }
        else
        {
            Message = "Code is not authentic";
        }
    }
}