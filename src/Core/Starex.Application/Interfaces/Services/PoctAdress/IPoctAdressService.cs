
public interface IPoctAdressService
{
    public Task AddAsync(PoctAdressPostDto dto);
    public Task<PoctAdressListDto> GetAll();
}
