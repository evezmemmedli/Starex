using AutoMapper;
public class AppealMap : Profile
{
    public AppealMap()
    {
        CreateMap<AppealPostDto,Appeal>();
    }
}

