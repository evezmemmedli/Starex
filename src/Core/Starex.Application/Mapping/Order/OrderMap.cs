using AutoMapper;
using Starex.Domain.Entities;
public class OrderMap : Profile
{
    public OrderMap()
    {
        CreateMap<Order, OrderGetDto>();
    }
}

