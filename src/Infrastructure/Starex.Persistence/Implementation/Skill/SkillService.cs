using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Starex.Domain.Entities;

public class SkillService : ISkillService
{
    readonly IUnitOfWork _unitOfWork;
    readonly IMapper _mapper;

    public SkillService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task AddAsync(SkillPostDto dto)
    {
        if (_unitOfWork.SkillReadRepository.GetAll(false).Any(x => x.Name.ToLower() == dto.Name.ToLower()))
            throw new ItemExistException($"{dto.Name} alrady exsist");
         Skill skill = _mapper.Map<Skill>(dto);
        await _unitOfWork.SkillWriteRepository.AddAsync(skill);
        await _unitOfWork.SkillWriteRepository.CommitAsync();
    }

    public async Task<SkillListDto> GetAll()
    {
        var response = new SkillListDto();
        var data = await _unitOfWork.SkillReadRepository.GetAll(false).ToListAsync();
        var mappedData = _mapper.Map<List<SkillDto>>(data);
        response.SkillDtos = mappedData;
        return response;
    }

    public async Task<SkillDto> GetByIdAsync(bool tracking, int id)
    {
        Skill skill = _unitOfWork.SkillReadRepository.Get(tracking, x => x.Id == id).FirstOrDefault();
        if (skill == null)
            throw new ItemNotFoundException("Item not found");
        SkillDto dto = _mapper.Map<SkillDto>(skill);
        return dto;
    }

    public void Remove(int id)
    {
        Skill skill = _unitOfWork.SkillReadRepository.Get(true, x => x.Id == id).FirstOrDefault();
        if (skill == null)
            throw new ItemNotFoundException("Item not found");
        _unitOfWork.SkillWriteRepository.Remove(skill);
        _unitOfWork.SkillWriteRepository.Commit();
    }

    public void Update(SkillPostDto dto, int id)
    {
        Skill skill = _unitOfWork.SkillReadRepository.Get(true, x => x.Id == id).FirstOrDefault();
        if (skill == null)
            throw new ItemNotFoundException("Item not found");
        skill.Name = dto.Name;
        skill.AboutSkillId = dto.AboutSkillId;
        _unitOfWork.SkillWriteRepository.Update(skill);
        _unitOfWork.SkillWriteRepository.Commit();
    }
}

