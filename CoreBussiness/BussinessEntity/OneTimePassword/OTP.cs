using CoreBussiness.BussinessEntity.Users;
using CoreBussiness.CoreEntity;

namespace CoreBussiness.BussinessEntity.OneTimePassword;

public class OTP:Core
{
    private const int ExpireLimit = 15;

    public OTP()
    {
        ExpireTime = DateTimeOffset.Now.AddMinutes(ExpireLimit);
    }
    public int UserId { get; set; }
    public User User { get; set; }
    public string code { get; set; }
    public bool IsUsed { get; set; }
    public DateTimeOffset ExpireTime { get; set; }
    public bool IsAuthentic => !IsUsed && DateTimeOffset.Now < ExpireTime;
}