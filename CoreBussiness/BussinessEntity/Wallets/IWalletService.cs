namespace CoreBussiness.BussinessEntity.Wallets;

public interface IWalletService
{
    Task AddNewWalletAsync(Wallet wallet);
}