
public interface IFaqService
{
    public Task AddAsync(FaqPostDto dto);
    public Task<FaqListDto> GetAll();
    public Task<FaqDto> GetByIdAsync(bool tracking, int id);
    public void Remove(int id);
    public void Update(FaqPostDto dto, int id);
}

