
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Starex.Domain.Entities;

public class OrderService : IOrderService
{
    readonly IUnitOfWork _unitOfWork;
    readonly IMapper _mapper;
    readonly IEmailService _emailservice;
    readonly IPackageService _packageService;
    public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailservice, IPackageService packageService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _emailservice = emailservice;
        _packageService = packageService;
    }
    public  async Task Create(int id, OrderPostDto postDto)
    {
        Declare declare=await _unitOfWork.DeclareReadRepository.Get(false,x=>x.Id==id,"AppUser").FirstOrDefaultAsync();

        if (declare == null)
            throw new ItemNotFoundException("Declare yoxdu");

        Order order=new Order();
        Random rand=new Random();
        order.AppUserId=declare.AppUser.Id;
        order.OrderCode=rand.Next(1111111,99999999);
        order.Weight=postDto.Weight;
        order.OrderLink=postDto.OrderLink;
        order.Total = order.Weight * 1.50;
       await _unitOfWork.OrderWriteRepository.AddAsync(order);
       await _unitOfWork.OrderWriteRepository.CommitAsync();
    }

    public Task<OrderListDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<OrderGetDto> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task InAirPort(int id)
    {
        Order order = await _unitOfWork.OrderReadRepository.Get(true, x => x.Id == id, "AppUser").FirstOrDefaultAsync();

        if (order == null)
            throw new ItemNotFoundException("Order item not found");

        order.IsInAirport = true;
        _unitOfWork.OrderWriteRepository.Update(order);
        _unitOfWork.OrderWriteRepository.Commit();
        await _emailservice.SendEmail(order.AppUser.Email, "Mehsulunuz Gomrukdedir", "Melumat");
    }

    public async Task InforeignStock(int id)
    {
        Order order= await _unitOfWork.OrderReadRepository.Get(true,x=>x.Id==id,"AppUser").FirstOrDefaultAsync();

        if (order == null)
            throw new ItemNotFoundException("Order item not found");

        order.IsInForeignStock=true;
        _unitOfWork.OrderWriteRepository.Update(order);
        _unitOfWork.OrderWriteRepository.Commit();
      await  _emailservice.SendEmail(order.AppUser.Email, "Mehsulunuz xarici anbardadir", "Melumat");

    }

    public async Task InInsideStock(int id)
    {
        Order order = await _unitOfWork.OrderReadRepository.Get(true, x => x.Id == id, "AppUser").FirstOrDefaultAsync();

        if (order == null)
            throw new ItemNotFoundException("Order item not found");

        order.isInInsideStock = true;
        _unitOfWork.OrderWriteRepository.Update(order);
        _unitOfWork.OrderWriteRepository.Commit();
        await _emailservice.SendEmail(order.AppUser.Email, "Mehsulunuz Goturulmeye hazirdir", "Melumat");

        await _packageService.AddAsync(order.Id);

    }
}

