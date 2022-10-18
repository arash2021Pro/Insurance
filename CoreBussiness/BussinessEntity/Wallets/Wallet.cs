using CoreBussiness.BussinessEntity.Users;
using CoreBussiness.CoreEntity;

namespace CoreBussiness.BussinessEntity.Wallets;

public class Wallet
{
    public Wallet()
    {
        CreationTime = DateTime.Now;
    }
    public int UserId { get; set; }
    public User User { get; set; }
    
    public float UsdAmount { get; set; }
    public float BtcAmount { get; set; }
    
    public float EthAmount { get; set; }
    public int Bonus { get; set; }
    public WalletStatus WalletStatus { get; set; }
    public bool IsDeleted { get; set; }
   public DateTime CreationTime { get; set; }
}