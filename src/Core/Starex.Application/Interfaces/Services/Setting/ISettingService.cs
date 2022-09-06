
    public interface ISettingService
    {
    public Task AddAsync(SettingPostDto dto);
    public Task<SettingListDto> GetAll();
    public Task<SettingDto> GetByIdAsync(bool tracking, int id);
    public void Remove(int id);
    public void Update(SettingPostDto dto, int id);
}

