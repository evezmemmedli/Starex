
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Starex.Domain.Entities;

public class SettingService : ISettingService
{
    readonly IUnitOfWork _unitOfWork;
    readonly IMapper _mapper;

    public SettingService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task AddAsync(SettingPostDto dto)
    {
        if (_unitOfWork.SettingReadRepository.GetAll(false).Any(x => x.Contact.ToLower() == dto.Contact.ToLower()))
            throw new ItemExistException($"{dto.Contact} alrady exsist");
        Setting setting = _mapper.Map<Setting>(dto);
        await _unitOfWork.SettingWriteRepository.AddAsync(setting);
        await _unitOfWork.SettingWriteRepository.CommitAsync();
    }

    public async Task<SettingListDto> GetAll()
    {
        var response = new SettingListDto();
        var data = await _unitOfWork.SettingReadRepository.GetAll(false).ToListAsync();

        var mappedData = _mapper.Map<List<SettingDto>>(data);

        response.SettingDtos = mappedData;

        return response;
    }

    public async Task<SettingDto> GetByIdAsync(bool tracking, int id)
    {
        Setting setting = _unitOfWork.SettingReadRepository.Get(tracking, x => x.Id == id).FirstOrDefault();

        if (setting == null)
            throw new ItemNotFoundException("Item not found");

        SettingDto settingDto = _mapper.Map<SettingDto>(setting);

        return settingDto;
    }

    public void Remove(int id)
    {
        Setting setting = _unitOfWork.SettingReadRepository.Get(true, x => x.Id == id).FirstOrDefault();
        if (setting == null)
            throw new ItemNotFoundException("Item not found");
        _unitOfWork.SettingWriteRepository.Remove(setting);
        _unitOfWork.SettingWriteRepository.Commit();
    }

    public void Update(SettingPostDto dto, int id)
    {
        Setting setting = _unitOfWork.SettingReadRepository.Get(true, x => x.Id == id).FirstOrDefault();
        if (setting == null)
            throw new ItemNotFoundException("Item not found");
        setting.Icon = dto.Icon;
        setting.SocialMedia=dto.SocialMedia;
        setting.Contact=dto.Contact;
        _unitOfWork.SettingWriteRepository.Update(setting);
        _unitOfWork.SettingWriteRepository.Commit();
    }
}

