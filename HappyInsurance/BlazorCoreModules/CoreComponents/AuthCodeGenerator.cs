using CoreApplication.CoreManagementApplication;
using CoreBussiness.BussinessEntity.OneTimePassword;
using CoreBussiness.RepsPattern;
using HappyInsurance.BlazorCoreModules.CoreAuthenticationService;
using HappyInsurance.BlazorCoreModules.RandomeGenerator;
using Microsoft.AspNetCore.Components;

namespace HappyInsurance.BlazorCoreModules.CoreComponents;

public class AuthCodeGenerator:ComponentBase
{
    [Inject] private IUnitOfWork _work { get; set; }
    [Inject] private ICoreManagerService _coreManagerService { get; set; }
    [Inject] private IHttpContextAccessor _contextAccessor { get; set; }
    [Inject]private ICodeGeneratorService _codeGeneratorService { get; set; }
    
    [Parameter]
    public RenderFragment ChildContent { get; set; }
    [Parameter]
    public EventCallback GeneratorCallback{ get; set; }

    protected async Task GenerateChange()
    {
        await GeneratorCallback.InvokeAsync();
    }
    
}