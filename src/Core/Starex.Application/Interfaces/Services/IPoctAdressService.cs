
public interface IPoctAdressService
{
    public Task AddAsync(PoctAdressPostDto dto);
    public Task<List<PoctAdressPostDto>> GetAll(bool tacking);
}
