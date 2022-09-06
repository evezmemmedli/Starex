
public interface INewsService
{
    public Task<NewsDto> AddAsync(NewsPostDto dto);
    public Task<NewsListDto> GetAll();
    public Task<NewsDto> GetByIdAsync(bool tracking, int id);
    public void Remove(int id);
    public void Update(NewsPostDto dto,int id);

}

