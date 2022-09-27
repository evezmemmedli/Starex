
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Starex.Domain.Entities;

public class DeclareService : IDeclareService
{
    readonly IUnitOfWork _unitOfWork;
    readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;
    public DeclareService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userManager = userManager;
    }
    public async Task AddAsync(DeclarePostDto postDto)
    {
        Declare declare = _mapper.Map<Declare>(postDto);
        AppUser appUser = await _userManager.FindByIdAsync(postDto.AppUserId);
        declare.AppUser = appUser;
        await _unitOfWork.DeclareWriteRepository.AddAsync(declare);
        await _unitOfWork.DeclareWriteRepository.CommitAsync();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<DeclareListDto> GetAll(DeclareListDto listDto)
    {
        throw new NotImplementedException();
    }

    public async Task<DeclareGetDto> GetById(int id)
    {
        Declare declare = await _unitOfWork.DeclareReadRepository.Get(false, x => x.Id == id, "AppUser").FirstOrDefaultAsync();
        if (declare is null) throw new ItemNotFoundException("Gelmir qaqa");
        return _mapper.Map<DeclareGetDto>(declare);
    }
}

