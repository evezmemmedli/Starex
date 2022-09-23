using Microsoft.EntityFrameworkCore;
using Starex.Domain.Entities;
public class PoctAdressService : IPoctAdressService
{
    private readonly IUnitOfWork _unitOfWork;
    public PoctAdressService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task AddAsync(PoctAdressPostDto dto)
    {
        PoctAdress poctAdress = new PoctAdress();

        poctAdress.Adress = "hvj";

     await _unitOfWork.PoctAdressWriteRepository.AddAsync(poctAdress);
     await   _unitOfWork.PoctAdressWriteRepository.CommitAsync();
    }
    public async  Task<PoctAdressListDto> GetAll()
    {
        //var query =   _unitOfWork.PoctAdressReadRepository.GetAll(false,"DeliveryPoint");
        PoctAdressListDto poctAdressListDto = new PoctAdressListDto();
        //poctAdressListDto.PoctAdressDtos = query.Select(x => new PoctAdressDto { Adress=x.Adress,DeliveryPoints });

        return poctAdressListDto;
    }
}
