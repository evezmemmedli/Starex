
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Starex.Domain.Entities;

public class OrderService : IOrderService
{
    readonly IUnitOfWork _unitOfWork;
    readonly IMapper _mapper;
    readonly IEmailService _emailservice;
    readonly IPackageService _packageService;
    readonly IPaymentService _paymentService;
    readonly UserManager<AppUser> _userManager;
    public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailservice, IPackageService packageService, UserManager<AppUser> userManager, IPaymentService paymentService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _emailservice = emailservice;
        _packageService = packageService;
        _userManager = userManager;
        _paymentService = paymentService;
    }
    public  async Task Create(int id, OrderPostDto postDto)
    {
        Declare declare=await _unitOfWork.DeclareReadRepository.Get(false,x=>x.Id==id,"AppUser").FirstOrDefaultAsync();
        if (declare == null)
            throw new ItemNotFoundException("Item not founf");
        Order order=new Order();
        Random rand=new Random();
        order.AppUserId=declare.AppUser.Id;
        order.OrderCode=rand.Next(1111111,99999999);
        order.Weight=postDto.Weight;
        order.OrderLink=postDto.OrderLink;
        if(order.Weight>0&&order.Weight<0.100)
              order.Total = order.Weight * 1;
        else if(order.Weight > 0.100 && order.Weight < 0.250)
            order.Total = order.Weight * 1.5;
        else if (order.Weight > 0.250 && order.Weight < 0.500)
            order.Total = order.Weight * 2.2;
        else
            order.Total=order.Weight*4.7;
        AppUser user=await _userManager.FindByIdAsync(order.AppUserId);
        if ((decimal)user.Balans >= (decimal)order.Total)
        {

            await _paymentService.Pay((decimal)order.Total, order.AppUserId);
            order.Payment = true;
        }
        await _unitOfWork.OrderWriteRepository.AddAsync(order);
       await _unitOfWork.OrderWriteRepository.CommitAsync();
    }

    public async Task<OrderListDto> GetAll()
    {
        var response = new OrderListDto();
        var data = await _unitOfWork.OrderReadRepository.GetAll(false).ToListAsync();
        var mappedData = _mapper.Map<List<OrderGetDto>>(data);
        response.OrderGetDtos = mappedData;
        return response;
    }

    public async Task<OrderGetDto> GetById(int id)
    {
        Order order = await _unitOfWork.OrderReadRepository.Get(false, x => x.Id == id, "AppUser").FirstOrDefaultAsync();
        if (order is null) throw new ItemNotFoundException("Item not Found");
        return _mapper.Map<OrderGetDto>(order);
    }

    public async Task InAirPort(int id)
    {
        Order order = await _unitOfWork.OrderReadRepository.Get(true, x => x.Id == id, "AppUser").FirstOrDefaultAsync();
        if (order == null)
            throw new ItemNotFoundException("Order item not found");
        order.IsInAirport = true;
        _unitOfWork.OrderWriteRepository.Update(order);
        _unitOfWork.OrderWriteRepository.Commit();
        await _emailservice.SendEmail(order.AppUser.Email, "Your Product is in Airport", "Information");
    }

    public async Task InforeignStock(int id)
    {
        Order order= await _unitOfWork.OrderReadRepository.Get(true,x=>x.Id==id,"AppUser").FirstOrDefaultAsync();
        if (order == null)
            throw new ItemNotFoundException("Order item not found");
        order.IsInForeignStock=true;
        _unitOfWork.OrderWriteRepository.Update(order);
        _unitOfWork.OrderWriteRepository.Commit();
      await  _emailservice.SendEmail(order.AppUser.Email, "Your Product is in foreign stock", "Information");

    }

    public async Task InInsideStock(int id)
    {
        Order order = await _unitOfWork.OrderReadRepository.Get(true, x => x.Id == id, "AppUser").FirstOrDefaultAsync();
        if (order == null)
            throw new ItemNotFoundException("Order item not found");
        order.isInInsideStock = true;
        _unitOfWork.OrderWriteRepository.Update(order);
        _unitOfWork.OrderWriteRepository.Commit();
        await _emailservice.SendEmail(order.AppUser.Email, "Your product is ready", "Information");
        await _packageService.AddAsync(order.Id);

    }
}

