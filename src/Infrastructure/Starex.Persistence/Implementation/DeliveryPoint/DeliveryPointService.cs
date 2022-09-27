using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Starex.Domain.Entities;
public class DeliveryPointService : IDeliveryPointService
{
    readonly IUnitOfWork _unitOfWork;
    readonly IMapper _mapper;
    public DeliveryPointService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task AddAsync(DeliveryPointPostDto dto)
    {
        if (_unitOfWork.DeliveryPointReadRepository.GetAll(false).Any(x => x.Adress.ToLower() == dto.Adress.ToLower()))
            throw new ItemExistException($"{dto.Adress} alrady exsist");
        DeliveryPoint deliveryPoint = _mapper.Map<DeliveryPoint>(dto);
        deliveryPoint.PoctAdresses = new List<PoctAdress>();
        foreach (PoctAdressPostDto pocadress in dto.poctAdressPostDtos)
        {
            PoctAdress poct = new PoctAdress { Adress=pocadress.Adress,DeliveryPoint=deliveryPoint};
            deliveryPoint.PoctAdresses.Add(poct);
        }
        await _unitOfWork.DeliveryPointWriteRepository.AddAsync(deliveryPoint);
        await _unitOfWork.DeliveryPointWriteRepository.CommitAsync();
    }

    public async Task<PoctAdressListDto> GetAll()
    {
        var response = new PoctAdressListDto();
        var data = await _unitOfWork.DeliveryPointReadRepository.GetAll(false).ToListAsync();
        var mappedData = _mapper.Map<List<DeliveryPointDto>>(data);
        response.DeliveryPoints = mappedData;
        return response;
    }

    public async Task<DeliveryPointDto> GetByIdAsync(bool tracking, int id)
    {
        DeliveryPoint deliveryPoint = _unitOfWork.DeliveryPointReadRepository.Get(tracking, x => x.Id == id).FirstOrDefault();
        if (deliveryPoint == null)
            throw new ItemNotFoundException("Item not found");
        DeliveryPointDto deliveryPointDto = _mapper.Map<DeliveryPointDto>(deliveryPoint);
        return deliveryPointDto;
    }

    public void Remove(int id)
    {
        DeliveryPoint deliveryPoint = _unitOfWork.DeliveryPointReadRepository.Get(true, x => x.Id == id).FirstOrDefault();
        if (deliveryPoint == null)
            throw new ItemNotFoundException("Item not found");
        _unitOfWork.DeliveryPointWriteRepository.Remove(deliveryPoint);
        _unitOfWork.DeliveryPointWriteRepository.Commit();
    }

    public DeliveryPointDto Update(DeliveryPointPostDto dto, int id)
    {
        DeliveryPoint deliveryPoint = _unitOfWork.DeliveryPointReadRepository.Get(true, x => x.Id == id).FirstOrDefault();
        if (deliveryPoint == null)
            throw new ItemNotFoundException("Item not found");
        if (_unitOfWork.DeliveryPointReadRepository.GetAll(false).Any(x => x.Id != id && x.Adress == dto.Adress))
            throw new ItemExistException("Qaqa bunu servisde yazmisan");
        //deliveryPoint = _mapper.Map<DeliveryPoint>(dto);
        deliveryPoint.Adress = dto.Adress;
        deliveryPoint.ActiveHour = dto.ActiveHour;
        try
        {
            _unitOfWork.DeliveryPointWriteRepository.Update(deliveryPoint);
        }
        catch (Exception)
        {

            throw;
        }
        _unitOfWork.DeliveryPointWriteRepository.Commit();
        DeliveryPointDto deliveryPointDto = _mapper.Map<DeliveryPointDto>(deliveryPoint);
        return deliveryPointDto;
    }


}

