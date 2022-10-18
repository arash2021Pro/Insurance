using CoreApplication.CoreManagementApplication;
using CoreBussiness.RepsPattern;
using Microsoft.AspNetCore.Components;

namespace HappyInsurance.BlazorCoreModules.CoreComponents;

public class SetNewPassComponent:ComponentBase
{
    [Inject] public ICoreManagerService CoreManagerService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public IUnitOfWork Work { get; set; }
    [Parameter]
    [SupplyParameterFromQuery]
    public string PhoneNumber { get; set; }
    public class PassModel
    {
        public string Password { get; set; }
    }
    public string Message { get; set; }

    public async Task SetNewPassAsync(PassModel passModel)
    {
        var user = await CoreManagerService.UserService.GetUserAsyncByPhone(PhoneNumber);
        if (!String.IsNullOrEmpty(passModel.Password))
        {
            user.Password = passModel.Password;
            var save = await Work.SaveChangesAsync();
            if (save > 0)
            {
                NavigationManager.NavigateTo("/Login");
            }
            else
            {
                Message = "Something went wrong";
            }
        }
    }
}