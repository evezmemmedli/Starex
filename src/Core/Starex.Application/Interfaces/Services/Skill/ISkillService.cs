
public interface ISkillService
{
    public Task AddAsync(SkillPostDto dto);
    public Task<SkillListDto> GetAll();
    public Task<SkillDto> GetByIdAsync(bool tracking, int id);
    public void Remove(int id);
    public void Update(SkillPostDto dto, int id);
}

