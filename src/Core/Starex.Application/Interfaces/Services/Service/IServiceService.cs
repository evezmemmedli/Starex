public interface IServiceService
{
    public Task<ServiceDto> AddAsync(ServicePostDto dto);
    public Task<ServiceListDto> GetAll();
    public Task<ServiceDto> GetByIdAsync(bool tracking, int id);
    public void Remove(int id);
    public void Update(ServicePostDto dto, int id);
}

