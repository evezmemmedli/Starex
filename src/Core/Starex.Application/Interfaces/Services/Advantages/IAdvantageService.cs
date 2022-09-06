public interface IAdvantageService
{
    public Task<AdvantageDto> AddAsync(AdvantagePostDto dto);
    public Task<AdvantageListDto> GetAll();
    public Task<AdvantageDto> GetByIdAsync(bool tracking, int id);
    public void Remove(int id);
    public void Update(AdvantagePostDto dto, int id);
}

