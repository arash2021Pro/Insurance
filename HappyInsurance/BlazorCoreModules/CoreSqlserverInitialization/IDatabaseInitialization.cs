namespace HappyInsurance.BlazorCoreModules.CoreSqlserverInitialization;

public interface IDatabaseInitialization
{
    Task SeedDataAsync();
}