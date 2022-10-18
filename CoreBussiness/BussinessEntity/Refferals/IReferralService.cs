namespace CoreBussiness.BussinessEntity.Refferals;

public interface IReferralService
{
    Task AddNewReferralAsync(Refferal refferal);
    Task<bool> IsRefExistsAsync(int userId);
}