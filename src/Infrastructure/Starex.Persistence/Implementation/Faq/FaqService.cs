using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Starex.Domain.Entities;
public class FaqService : IFaqService
{
    readonly IUnitOfWork _unitOfWork;
    readonly IMapper _mapper;
    public FaqService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task AddAsync(FaqPostDto dto)
    {
        if (_unitOfWork.FaqReadRepository.GetAll(false).Any(x => x.Title.ToLower() == dto.Title.ToLower()))
            throw new ItemExistException($"{dto.Title} alrady exsist");
        FAQ faq = _mapper.Map<FAQ>(dto);
        await _unitOfWork.FaqWriteRepository.AddAsync(faq);
        await _unitOfWork.FaqWriteRepository.CommitAsync();
    }
    public async Task<FaqListDto> GetAll()
    {
        var response = new FaqListDto();
        var data = await _unitOfWork.FaqReadRepository.GetAll(false, "FaqQuestions").ToListAsync();
        var mappedData = _mapper.Map<List<FaqDto>>(data);
        response.FaqDtos = mappedData;
        return response;
    }
    public async Task<FaqDto> GetByIdAsync(bool tracking, int id)
    {
        FAQ faq = _unitOfWork.FaqReadRepository.Get(tracking, x => x.Id == id).FirstOrDefault();
        if (faq == null)
            throw new ItemNotFoundException("Item not found");
        FaqDto faqDto = _mapper.Map<FaqDto>(faq);
        return faqDto;
    }
    public void Remove(int id)
    {
        FAQ faq = _unitOfWork.FaqReadRepository.Get(true, x => x.Id == id).FirstOrDefault();
        if (faq == null)
            throw new ItemNotFoundException("Item not found");
        _unitOfWork.FaqWriteRepository.Remove(faq);
        _unitOfWork.FaqWriteRepository.Commit();
    }
    public void Update(FaqPostDto dto, int id)
    {
        FAQ faq = _unitOfWork.FaqReadRepository.Get(true, x => x.Id == id).FirstOrDefault();
        if (faq == null)
            throw new ItemNotFoundException("Item not found");
        faq.Title = dto.Title;
        _unitOfWork.FaqWriteRepository.Update(faq);
        _unitOfWork.FaqWriteRepository.Commit();
    }
}

