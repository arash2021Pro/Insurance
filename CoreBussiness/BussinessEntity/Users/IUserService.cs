using CoreApplication.UserApplication;

namespace CoreBussiness.BussinessEntity.Users;

public interface IUserService
{
    Task SignupUserAsync(User user);
    Task<User> LoginUserAsync(LoginModel model);
    Task<bool> IsPhoneExistsAsync(string phone);
    Task<User?> GetUserAsync(string phonenumber,string password);
    public int GetUserAsyncByPhoneNumber(string phonenumber);
    Task<User?> GetUserAsyncByIdAsync(int userId);
    Task<User?> GetUserAsync(string Code);
    Task<User?> GetUserAsyncByPhone(string PhoneNumber);
 
}