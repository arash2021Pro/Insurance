using CoreBussiness.BussinessEntity.Roles;
using CoreBussiness.BussinessEntity.Users;
using CoreBussiness.RepsPattern;
using Microsoft.EntityFrameworkCore;

namespace HappyInsurance.BlazorCoreModules.CoreSqlserverInitialization;

public class DatabaseInitialService:IDatabaseInitialization
{
    private IUnitOfWork _work;
    public DatabaseInitialService(IUnitOfWork work)
    {
        _work = work;
    }
    
    public async Task SeedDataAsync()
    {
        var users = _work.Set<User>();
        var roles = _work.Set<Role>();
        if (!await users.AnyAsync())
        {
            var role = new Role() {RoleName = "admin"};

            var user = new User() {Role = role};
            await roles.AddAsync(role);
            await users.AddAsync(user);
            await _work.SaveChangesAsync();
        } 
    }
}