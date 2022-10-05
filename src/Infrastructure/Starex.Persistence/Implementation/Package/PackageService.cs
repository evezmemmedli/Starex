using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Starex.Domain.Entities;
public class PackageService : IPackageService
{
    readonly IUnitOfWork _unitOfWork;
    readonly IMapper _mapper;
    public PackageService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
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
        package.Weight = order.Weight;
        await _unitOfWork.PackageWriteRepository.AddAsync(package);
        await _unitOfWork.PackageWriteRepository.CommitAsync();
    }

    public async Task<PackageListGetDto> GetAll()
    {
        var response = new PackageListGetDto();
        var data = await _unitOfWork.PackageReadRepository.GetAll(false, "AppUser")
            .ToListAsync();

        response.GetDtos = _mapper.Map<List<PackageGetDto>>(data);
        return response;
    }

    public async Task TakeIt(int id)
    {
        Package package =  await _unitOfWork.PackageReadRepository.Get(true,x=>x.Id == id).FirstOrDefaultAsync();
        package.Status = true;
        _unitOfWork.PackageWriteRepository.Update(package);
        _unitOfWork.PackageWriteRepository.Commit();
    }
}

