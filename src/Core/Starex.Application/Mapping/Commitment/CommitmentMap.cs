using AutoMapper;
using Starex.Domain.Entities;

public class CommitmentMap : Profile
{
    public CommitmentMap()
    {
        CreateMap<CommitmentPostDto, Commitment>();
        CreateMap<Commitment, CommitmentGetDto>();
    }
}

