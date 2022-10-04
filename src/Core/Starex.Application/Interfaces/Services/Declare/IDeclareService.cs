public interface IDeclareService
{
    public Task AddAsync(DeclarePostDto postDto);
    public Task<DeclareListDto> GetAll();
    public Task<DeclareGetDto> GetById(int id);
    public void Remove(int id);
}

