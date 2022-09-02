
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
        poctAdress.DeliveryPointId = dto.DeliveryPointId;

     await _unitOfWork.PoctAdressWriteRepository.AddAsync(poctAdress);
     await   _unitOfWork.PoctAdressWriteRepository.CommitAsync();

    }

    public async Task<List<PoctAdressPostDto>> GetAll(bool tacking)
    {
       var query =  _unitOfWork.PoctAdressReadRepository.GetAll(tacking);

        List<PoctAdressPostDto> dto=new List<PoctAdressPostDto>();
        dto = query.Select(x => new PoctAdressPostDto { DeliveryPointId = x.DeliveryPointId, Adress = x.Adress }).ToList();

        return dto;
    }
      
}
