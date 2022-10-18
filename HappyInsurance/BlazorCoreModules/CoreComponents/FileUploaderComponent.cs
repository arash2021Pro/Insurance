using CoreApplication.CoreManagementApplication;
using HappyInsurance.BlazorCoreModules.FileHandlerManager;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace HappyInsurance.BlazorCoreModules.CoreComponents;

public class FileUploaderComponent:ComponentBase
{
    [Inject] private NavigationManager _navigationManager { get; set; }
    [Inject] public IFileHandlerService _fileHandlerService { get; set; }
    [Parameter]
    public int UserId { get; set; }

    public async Task HandleUploadImageAsync(InputFileChangeEventArgs args)
    {
        await _fileHandlerService.UploadImageAsync(args,"Images","Users",UserId,".png");
        _navigationManager.NavigateTo("/",true);
    }
}