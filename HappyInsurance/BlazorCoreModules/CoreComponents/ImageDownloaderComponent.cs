using Microsoft.AspNetCore.Components;

namespace HappyInsurance.BlazorCoreModules.CoreComponents;

public class ImageDownloaderComponent:ComponentBase
{
 
    [Parameter]
    public int UserId { get; set; }
    public string ImageUrl { get; set; }
    protected override async Task OnInitializedAsync()
    {
        await DownloadImageAsync();
    }
    private async Task DownloadImageAsync()
    {
        ImageUrl = $"Images/Users/{UserId}.png";
    }
}