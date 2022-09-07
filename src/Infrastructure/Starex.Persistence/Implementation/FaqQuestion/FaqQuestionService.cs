
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Starex.Domain.Entities;

public class FaqQuestionService : IFaqQuestionService
{
    readonly IUnitOfWork _unitOfWork;
    readonly IMapper _mapper;

    public FaqQuestionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task AddAsync(FaqQuestionPostDto dto)
    {
        if (_unitOfWork.FaqQuestionReadRepository.GetAll(false).Any(x => x.Question.ToLower() == dto.Question.ToLower()))
            throw new ItemExistException($"{dto.Question} alrady exsist");
        FaqQuestion faqQuestion = _mapper.Map<FaqQuestion>(dto);
        await _unitOfWork.FaqQuestionWriteRepository.AddAsync(faqQuestion);
        await _unitOfWork.FaqQuestionWriteRepository.CommitAsync();
    }

    public async Task<FaqQuestionListDto> GetAll()
    {
        var response = new FaqQuestionListDto();
        var data = await _unitOfWork.FaqQuestionReadRepository.GetAll(false).ToListAsync();
        var mappedData = _mapper.Map<List<FaqQuestionDto>>(data);
        response.FaqQuestionDtos = mappedData;
        return response;
    }

    public Task<FaqQuestionDto> GetByIdAsync(bool tracking, int id)
    {
        throw new NotImplementedException();
    }

    public void Remove(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(FaqQuestionPostDto dto, int id)
    {
        throw new NotImplementedException();
    }
}

