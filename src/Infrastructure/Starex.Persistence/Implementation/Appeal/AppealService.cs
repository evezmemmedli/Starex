using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class AppealService : IAppealService
{
    readonly IUnitOfWork _unitOfWork;
    readonly IMapper _mapper;
    readonly UserManager<AppUser> _userManager;

    public AppealService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task AddAsync(AppealPostDto postDto)
    {
        Appeal appeal = _mapper.Map<Appeal>(postDto);
        AppUser appUser = await _userManager.FindByIdAsync(postDto.AppUserId);
        if (appUser == null)
            throw new ItemNotFoundException("User not found");
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

