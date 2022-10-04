using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

    public void Remove(int id)
    {
        Declare declare = _unitOfWork.DeclareReadRepository.Get(true, x => x.Id == id).FirstOrDefault();
        if (declare == null)
            throw new ItemNotFoundException("Item not found");
        _unitOfWork.DeclareWriteRepository.Remove(declare);
        _unitOfWork.DeclareWriteRepository.Commit();
    }

    public async Task<DeclareListDto> GetAll()
    {
        var response = new DeclareListDto();
        var data = await _unitOfWork.DeclareReadRepository.GetAll(false,"AppUser").ToListAsync();
        var mappedData = _mapper.Map<List<DeclareGetDto>>(data);
        response.DeclareListDtos = mappedData;
        return response;
    }

    public async Task<DeclareGetDto> GetById(int id)
    {
        Declare declare = await _unitOfWork.DeclareReadRepository.Get(false, x => x.Id == id, "AppUser").FirstOrDefaultAsync();
        if (declare is null) throw new ItemNotFoundException("Item not Found");
        return _mapper.Map<DeclareGetDto>(declare);
    }
}

