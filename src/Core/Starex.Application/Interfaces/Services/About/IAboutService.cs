public interface IAboutService
{
    public Task<AboutDto> AddAsync(AboutPostDto dto);
    public Task<AboutListDto> GetAll();
    public Task<AboutDto> GetByIdAsync(bool tracking, int id);
    public void Remove(int id);
    public void Update(AboutPostDto dto, int id);
}

