using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Starex.Domain.Entities;

public class CommitmentService : ICommitmentService
{
    readonly IUnitOfWork _unitOfWork;
    readonly IMapper _mapper;
    readonly UserManager<AppUser> _userManager;
    public CommitmentService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userManager = userManager;
    }
    public async Task AddAsync(CommitmentPostDto commitmentPostDto)
    {
        Commitment commitment = _mapper.Map<Commitment>(commitmentPostDto);
        AppUser appUser = await _userManager.FindByIdAsync(commitmentPostDto.AppUserId);
        if (appUser == null)
            throw new ItemNotFoundException("User not found");
        await _unitOfWork.CommitmentWriteRepository.AddAsync(commitment);
        await _unitOfWork.CommitmentWriteRepository.CommitAsync();
    }

    public async Task<CommitmentListDto> GetAll()
    {
        var query = _unitOfWork.CommitmentReadRepository.GetAll(false);
        CommitmentListDto listDto = new();
        listDto.CommitmentGetDtos = await query.Select(x => new CommitmentGetDto { Fullname = x.Fullname, AppUserId = x.AppUserId, IdentityNumber = x.IdentityNumber }).ToListAsync();
        return listDto;
    }

    public async Task Remove(int id)
    {
        Commitment commitment = await _unitOfWork.CommitmentReadRepository.Get(false, x => x.Id == id).FirstOrDefaultAsync();
        if (commitment == null) throw new ItemNotFoundException("This commitment doest exist");
        _unitOfWork.CommitmentWriteRepository.Remove(commitment);
        await _unitOfWork.CommitmentWriteRepository.CommitAsync();
    }
}

