using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Starex.Domain.Entities;
////using Microsoft.AspNetCore.Hosting;

public class NewsService : INewsService
{

    readonly IUnitOfWork _unitOfWork;
    readonly IMapper _mapper;
    readonly IWebHostEnvironment _env;

    public NewsService(IUnitOfWork unitOfWork, IMapper mapper,IWebHostEnvironment env)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _env = env;
    }
    public async Task<NewsDto> AddAsync(NewsPostDto dto)
    {
        News news = _mapper.Map<News>(dto);
        if (!dto.Image.IsImageOkay(2)) return null;
        news.Image = await dto.Image.FileCreate(_env.WebRootPath,"images");
        await _unitOfWork.NewsWriteRepository.AddAsync(news);
        await _unitOfWork.DeliveryPointWriteRepository.CommitAsync();
        NewsDto newsDto = _mapper.Map<NewsDto>(news);
        return newsDto;
    }
}

