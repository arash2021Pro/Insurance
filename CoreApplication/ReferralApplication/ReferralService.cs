using CoreBussiness.BussinessEntity.Refferals;
using CoreBussiness.RepsPattern;
using Microsoft.EntityFrameworkCore;

namespace CoreApplication.ReferralApplication;

public class ReferralService:IReferralService
{
    private DbSet<Refferal> _refferals;
    public ReferralService(IUnitOfWork work)
    {
        _refferals = work.Set<Refferal>();
    }

    public async Task AddNewReferralAsync(Refferal refferal) => await _refferals.AddAsync(refferal);
    public async Task<bool> IsRefExistsAsync(int userId) => await _refferals.AnyAsync(x => x.UserId == userId);


}