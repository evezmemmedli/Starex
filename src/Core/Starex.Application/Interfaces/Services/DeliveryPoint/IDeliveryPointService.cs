using System.Linq.Expressions;

public interface IDeliveryPointService
{
    public Task AddAsync(DeliveryPointPostDto dto);
    public Task<PoctAdressListDto> GetAll();
    public Task<DeliveryPointDto> GetByIdAsync(bool tracking,int id);
    public void Remove(int id);
    public DeliveryPointDto Update(DeliveryPointPostDto dto,int id);

}
