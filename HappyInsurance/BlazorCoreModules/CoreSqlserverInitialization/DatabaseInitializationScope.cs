namespace HappyInsurance.BlazorCoreModules.CoreSqlserverInitialization;

public static class DatabaseInitializationScope
{
    public static void SetDatabaseInitialScopeService(this IApplicationBuilder app)
    {
        var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
        using (var scope=scopeFactory.CreateScope())
        {
            var databaseInitializer = scope.ServiceProvider.GetRequiredService<IDatabaseInitialization>();
            databaseInitializer.SeedDataAsync();
        }
    }
}