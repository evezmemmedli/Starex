public interface IDeclareService
{
    public Task AddAsync(DeclarePostDto postDto);
    public Task<DeclareListDto> GetAll(DeclareListDto listDto);
    public Task<DeclareGetDto> GetById(int id);
    public Task Delete(int id);
}

