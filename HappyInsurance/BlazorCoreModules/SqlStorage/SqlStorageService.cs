using CoreStorage.StorageContext;
using Microsoft.EntityFrameworkCore;

namespace HappyInsurance.BlazorCoreModules.SqlStorage;

public static class SqlStorageService
{
    public static void SetSqlServerService(this IServiceCollection service, IConfiguration configuration)
    {
        var StorageConnection = configuration.GetConnectionString("DefaultConnection");
        service.AddDbContextPool<ApplicationContext>(option =>
        {
            option.UseSqlServer(StorageConnection, x =>
            {
                x.EnableRetryOnFailure(3);
                x.MinBatchSize(5).MaxBatchSize(50);
                x.UseNodaTime();
            }).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            option.AddInterceptors();
            option.LogTo(Console.WriteLine);
            option.EnableDetailedErrors();
            option.ConfigureWarnings(x =>
            {
                x.Throw();
            });
        });
    }
}