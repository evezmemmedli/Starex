public interface IBrandService
{
    public Task<BrandDto> AddAsync(BrandPostDto dto);
    public Task<BrandListDto> GetAll();
    public Task<BrandDto> GetByIdAsync(bool tracking, int id);
    public void Remove(int id);
    public void Update(BrandPostDto dto, int id);
}

