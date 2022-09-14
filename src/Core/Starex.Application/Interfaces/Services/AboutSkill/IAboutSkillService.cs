
public interface IAboutSkillService
{
    public Task<AboutSkillDto> AddAsync(AboutSkillPostDto dto);
    public Task<AboutSkillListDto> GetAll();
    public Task<AboutSkillGetDto> GetByIdAsync(bool tracking, int id);
    public void Remove(int id);
    public void Update(AboutSkillPostDto dto, int id);
}

