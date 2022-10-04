
public interface IAppealService
{
    public Task AddAsync(AppealPostDto postDto);
    public Task<AppealListDto> GetAll();
}

