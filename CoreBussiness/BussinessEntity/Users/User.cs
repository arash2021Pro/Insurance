using CoreBussiness.BussinessEntity.Logs;
using CoreBussiness.BussinessEntity.OneTimePassword;
using CoreBussiness.BussinessEntity.Orders;
using CoreBussiness.BussinessEntity.Refferals;
using CoreBussiness.BussinessEntity.Roles;
using CoreBussiness.BussinessEntity.Wallets;
using CoreBussiness.CoreEntity;

namespace CoreBussiness.BussinessEntity.Users;

public class User:Core
{

    private string GenerateUserCode() => Guid.NewGuid().ToString().Replace("-", "").Substring(1, 6);
    
    public User()
    {
        FullName = SetFullName();
        UserCode = GenerateUserCode();
    }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    private string? FullName { get; set; }
    public string?Email { get; set; }
    public string? UserCode { get; set; }
  
    public bool IsObedient { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
    private string SetFullName() => Name + " " + LastName;
    public UserStatus UserStatus { get; set; }
    public string NationalCode { get; set; }  
    public ICollection<OTP>Otps { get; set; }
    public ICollection<Log>Logs { get; set; }
    public Wallet Wallet { get; set; }
    public ICollection<Refferal>Refferals { get; set; }
    public ICollection<Order>Orders { get; set; }

}