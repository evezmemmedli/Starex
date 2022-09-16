using AutoMapper;
public class AuthenticationMap:Profile
{
    public AuthenticationMap()
    {
        CreateMap<RegisterPostDto, AppUser>()
            .ForMember(x=>x.UserName,opt=>opt.MapFrom(src=>$"{src.Name}{src.Surname}"));
        CreateMap<AppUser, AuthenticationResultDto>();
       
    }
}

