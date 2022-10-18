using CoreBussiness.BussinessEntity.Users;
using CoreBussiness.CoreEntity;

namespace CoreBussiness.BussinessEntity.Refferals;

public class Refferal:Core
{
    public int UserId { get; set; }
    public User User { get; set; }
    public int ReferralCount { get; set; }
    public string? PhoneNumber { get; set; }
    
}