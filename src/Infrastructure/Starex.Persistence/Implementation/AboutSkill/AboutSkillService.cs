using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Starex.Domain.Entities;
public class AboutSkillService : IAboutSkillService
{
    readonly IUnitOfWork _unitOfWork;
    readonly IMapper _mapper;
    public AboutSkillService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<AboutSkillDto> AddAsync(AboutSkillPostDto dto)
    {
        if (_unitOfWork.AboutSkillReadRepository.GetAll(false).Any(x => x.Name.ToLower() == dto.Name.ToLower()))
            throw new ItemExistException($"{dto.Name} alrady exsist");
        AboutSkill aboutSkill = _mapper.Map<AboutSkill>(dto);
        await _unitOfWork.AboutSkillWriteRepository.AddAsync(aboutSkill);
        await _unitOfWork.AboutSkillWriteRepository.CommitAsync();
        AboutSkillDto aboutSkilldto = _mapper.Map<AboutSkillDto>(aboutSkill);
        return aboutSkilldto;
    }
    public async Task<AboutSkillListDto> GetAll()
    {
        var response = new AboutSkillListDto();
        var data = await _unitOfWork.AboutSkillReadRepository.GetAll(false, "Skills").ToListAsync();
        var mappedData = _mapper.Map<List<AboutSkillDto>>(data);
        response.AboutSkillDtos = mappedData;
        return response;
    }
    public async Task<AboutSkillGetDto> GetByIdAsync(bool tracking, int id)
    {
        var response = new AboutSkillGetDto();
        AboutSkill aboutSkill = _unitOfWork.AboutSkillReadRepository.Get(tracking, x => x.Id == id, "Skills").FirstOrDefault();
        if (aboutSkill == null)
            throw new ItemNotFoundException("Item not found");
        AboutSkillDto dto = _mapper.Map<AboutSkillDto>(aboutSkill);
        response.AboutSkillDto = dto;
        return response;
    }
    public void Remove(int id)
    {
        AboutSkill aboutSkill = _unitOfWork.AboutSkillReadRepository.Get(true, x => x.Id == id).FirstOrDefault();
        if (aboutSkill == null)
            throw new ItemNotFoundException("Item not found");
        _unitOfWork.AboutSkillWriteRepository.Remove(aboutSkill);
        _unitOfWork.AboutSkillWriteRepository.Commit();
    }
    public void Update(AboutSkillPostDto dto, int id)
    {
        AboutSkill aboutSkill = _unitOfWork.AboutSkillReadRepository.Get(true, x => x.Id == id).FirstOrDefault();
        if (aboutSkill == null)
            throw new ItemNotFoundException("Item not found");
        aboutSkill.Name = dto.Name;
        _unitOfWork.AboutSkillWriteRepository.Update(aboutSkill);
        _unitOfWork.AboutSkillWriteRepository.Commit();
    }
}

