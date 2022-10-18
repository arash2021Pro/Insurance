using CoreBussiness.BussinessEntity.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreStorage.EntityConfiguration;

public class UserConfiguration:IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.ModificationTime).IsRequired(false);
        builder.Property(x => x.NationalCode).IsRequired().HasMaxLength(10);
        builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(11);
        builder.Property(x => x.Email).IsRequired(false);
        builder.HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.RoleId);
    }
}