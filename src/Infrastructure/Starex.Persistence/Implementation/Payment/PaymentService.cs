using Microsoft.AspNetCore.Identity;

public class PaymentService : IPaymentService
{
    private readonly UserManager<AppUser> _userManager;

    public PaymentService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task IncreaeBalance(decimal amount, string userid)
    {
       AppUser appUser= await _userManager.FindByIdAsync(userid);

        if (appUser == null)
            throw new ItemNotFoundException("User not found");

        appUser.Balans = amount;
        await _userManager.UpdateAsync(appUser);
    }

    public async Task Pay(decimal amount, string userid)
    {
        AppUser appUser = await _userManager.FindByIdAsync(userid);

        if (appUser == null)
            throw new ItemNotFoundException("User not found");

        if (appUser.Balans >= amount)
           appUser.Balans= appUser.Balans - amount;
       
        await _userManager.UpdateAsync(appUser);
    }
}
