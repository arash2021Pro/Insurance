using CoreBussiness.BussinessEntity.Wallets;
using CoreBussiness.RepsPattern;
using Microsoft.EntityFrameworkCore;

namespace CoreApplication.WalletApplication;

public class WalletService:IWalletService
{
    private DbSet<Wallet> _wallets;
    public WalletService(IUnitOfWork work)
    {
        _wallets = work.Set<Wallet>();
    }

    public async Task AddNewWalletAsync(Wallet wallet) => await _wallets.AddAsync(wallet);
}