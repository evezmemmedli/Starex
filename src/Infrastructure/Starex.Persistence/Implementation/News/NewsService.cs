using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Starex.Domain.Entities;
using Starex.Persistence.Helpers;
////using Microsoft.AspNetCore.Hosting;

public class NewsService : INewsService
{
    readonly IUnitOfWork _unitOfWork;
    readonly IMapper _mapper;
    readonly IWebHostEnvironment _env;
    readonly FileUrlGenerate _fileUrlGenerate;
    public NewsService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env, FileUrlGenerate fileUrlGenerate)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _env = env;
        _fileUrlGenerate = fileUrlGenerate;
    }
    public async Task<NewsDto> AddAsync(NewsPostDto dto)
    {
        News news = _mapper.Map<News>(dto);
        if (!dto.Image.IsImageOkay(2)) return null;
        news.Image = await dto.Image.FileCreate(_env.WebRootPath, "images");
        await _unitOfWork.NewsWriteRepository.AddAsync(news);
        await _unitOfWork.NewsWriteRepository.CommitAsync();
        NewsDto newsDto = _mapper.Map<NewsDto>(news);
        return newsDto;
    }

    public async Task<NewsListDto> GetAll()
    {
        var response = new NewsListDto();
        var data = await _unitOfWork.NewsReadRepository.GetAll(false).ToListAsync();
        var mappedData = _mapper.Map<List<NewsDto>>(data);
        mappedData.ForEach(data => data.ImageUrl = _fileUrlGenerate.PhotoUrlGenerate(data.Image));
        response.NewsDtos = mappedData;
        return response;
    }
    public async Task<NewsDto> GetByIdAsync(bool tracking, int id)
    {
        News news = _unitOfWork.NewsReadRepository.Get(tracking, x => x.Id == id).FirstOrDefault();
        if (news == null)
            throw new ItemNotFoundException("Item not found");
        NewsDto dto = _mapper.Map<NewsDto>(news);
        dto.ImageUrl = _fileUrlGenerate.PhotoUrlGenerate(dto.Image);
        return dto;
    }

    public void Remove(int id)
    {
        News news = _unitOfWork.NewsReadRepository.Get(true, x => x.Id == id).FirstOrDefault();
        if (news == null)
            throw new ItemNotFoundException("Item not found");
        _unitOfWork.NewsWriteRepository.Remove(news);
        _unitOfWork.NewsWriteRepository.Commit();
    }

    public void Update(NewsPostDto dto, int id)
    {
        News news = _unitOfWork.NewsReadRepository.Get(true, x => x.Id == id).FirstOrDefault();
        if (news == null)
            throw new ItemNotFoundException("Item not found");
        news.Title = dto.Title;
        news.Desc = dto.Desc;
        
        if (dto.Image != null)
        {
            FileHelpers.FileDelete(_env.WebRootPath,"images",news.Image);
            news.Image = dto.Image.FileCreate(_env.WebRootPath, "images").Result;
        }
        _unitOfWork.NewsWriteRepository.Update(news);
        _unitOfWork.NewsWriteRepository.Commit();

    }
}

