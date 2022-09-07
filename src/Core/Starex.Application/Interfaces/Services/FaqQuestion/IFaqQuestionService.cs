public interface IFaqQuestionService
{
    public Task AddAsync(FaqQuestionPostDto dto);
    public Task<FaqQuestionListDto> GetAll();
    public Task<FaqQuestionDto> GetByIdAsync(bool tracking, int id);
    public void Remove(int id);
    public void Update(FaqQuestionPostDto dto, int id);
}

