using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class AppealService : IAppealService
{
    readonly IUnitOfWork _unitOfWork;
    readonly IMapper _mapper;

    public AppealService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AddAsync(AppealPostDto postDto)
    {
        Appeal appeal = _mapper.Map<Appeal>(postDto);
       await _unitOfWork.AppealWriteRepository.AddAsync(appeal);
       await _unitOfWork.AppealWriteRepository.CommitAsync();
    }

    public  async Task<AppealListDto> GetAll()
    {
     var query =  _unitOfWork.AppealReadRepository.GetAll(false);
        AppealListDto listDto = new();
        listDto.AppealGetDtos = await query.Select(x=>new AppealGetDto { Message=x.Message,AppUSerId=x.AppUserId}).ToListAsync();
        return listDto;
    }
}

