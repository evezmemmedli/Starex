
public interface ICountryService
{
    public Task<CountryDto> AddAsync(CountryPostDto dto);
    public Task<CountryListDto> GetAll();
    public Task<CountryDto> GetByIdAsync(bool tracking, int id);
    public void Remove(int id);
    public void Update(CountryPostDto dto, int id);
}

