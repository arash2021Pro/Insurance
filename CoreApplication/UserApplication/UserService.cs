using System.Security.Claims;
using CoreBussiness.BussinessEntity.Users;
using CoreBussiness.RepsPattern;
using CoreStorage.StorageContext;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace CoreApplication.UserApplication;

public class UserService:IUserService
{
    private ApplicationContext _context;
    private DbSet<User> _users;
    public UserService(IUnitOfWork work, ApplicationContext context)
    {
        _context = context;
        _users = work.Set<User>();
    }

    public async Task SignupUserAsync(User user) => await _users.AddAsync(user);

    public async Task<User?> LoginUserAsync(LoginModel model)=> await _users.AsTracking().Include(x => x.Role).FirstOrDefaultAsync(x => x.PhoneNumber ==model.Phonenumber && x.Password == model.Password);
    public async Task<bool> IsPhoneExistsAsync(string phone) => await _users.AnyAsync(x => x.PhoneNumber == phone);

    public async Task<User?> GetUserAsync(string phonenumber,string password) =>
        await _users.AsTracking().Include(x=>x.Role).FirstOrDefaultAsync(x => x.PhoneNumber == phonenumber && x.Password == password);

    public int GetUserAsyncByPhoneNumber(string phonenumber)=> _users.AsTracking().FirstOrDefault(x => x.PhoneNumber == phonenumber)!.RoleId;
    
    public async Task<User?> GetUserAsyncByIdAsync(int userId) => await _users.AsTracking().FirstOrDefaultAsync(x => x.Id == userId);
    public async Task<User?> GetUserAsync(string Code) => await _users.FirstOrDefaultAsync(x => x.UserCode == Code);

    public async Task<User?> GetUserAsyncByPhone(string PhoneNumber) =>
        await _users.AsTracking().FirstOrDefaultAsync(x => x.PhoneNumber == PhoneNumber);
    
  
}