using CoreBussiness.BussinessEntity.Users;
using CoreBussiness.BussinessEntity.Wallets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreStorage.EntityConfiguration;

public class WalletConfiguration:IEntityTypeConfiguration<Wallet>
{
    public void Configure(EntityTypeBuilder<Wallet> builder)
    {
        builder.HasKey(x => x.UserId);
        builder.Property(x => x.Bonus).HasDefaultValue(0);
        builder.Property(x => x.BtcAmount).HasDefaultValue(0);
        builder.Property(x => x.EthAmount).HasDefaultValue(0);
        builder.Property(x => x.UsdAmount).HasDefaultValue(0);
        builder.HasOne<User>(x => x.User).WithOne(x => x.Wallet).HasForeignKey<Wallet>(x => x.UserId);
        
    }
}