using Microsoft.AspNetCore.Components.Forms;

namespace HappyInsurance.BlazorCoreModules.FileHandlerManager;

public interface IFileHandlerService
{
    Task UploadImageAsync(InputFileChangeEventArgs args,string parentFile,string childFile,int userId,string fileType);
}