using Microsoft.EntityFrameworkCore;
using Starex.Domain.Entities;
public class PackageService : IPackageService
{
    readonly IUnitOfWork _unitOfWork;
    public PackageService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task AddAsync(int id)
    {
        Order order = await _unitOfWork.OrderReadRepository.Get(false, x => x.Id == id, "AppUser").FirstOrDefaultAsync();
        if (order == null)
            throw new ItemNotFoundException("Item doesnt exist");
        Package package = new Package();
        package.AppUserId = order.AppUserId;
        package.Status = false;
        package.Payment = order.Payment;
        await _unitOfWork.PackageWriteRepository.AddAsync(package);
        await _unitOfWork.PackageWriteRepository.CommitAsync();
    }

}

