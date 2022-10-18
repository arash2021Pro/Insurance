using CoreInfraSructure.CoreMessageServices;

namespace HappyInsurance.BlazorCoreModules.BindCoreServices;

public static class BindService
{
    public static void SetBindService(this IServiceCollection services,IConfiguration configuration)
    {
        services.Configure<MessageOption>(x => configuration.GetSection("KaveNegar:ApiKey").Bind(x));
    }
}