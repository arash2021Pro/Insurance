using Microsoft.AspNetCore.Components.Forms;

namespace HappyInsurance.BlazorCoreModules.FileHandlerManager;

public class FileManagerService:IFileHandlerService
{
    private IWebHostEnvironment _webHostEnvironment;
    public FileManagerService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task UploadImageAsync(InputFileChangeEventArgs args,string parentFile, string childFile, int userId, string fileType)
    {
        var filename = userId + Path.GetExtension(args.File.Name);
        var filepath = Path.Combine(_webHostEnvironment.WebRootPath,"Images","Users",filename);
        await using var filestream = new FileStream(filepath,FileMode.Create);
        await args.File.OpenReadStream().CopyToAsync(filestream);
    }
}