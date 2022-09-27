public interface IOrderService
{
    public Task Create(int id,OrderPostDto postDto);
    public Task InforeignStock(int id);
    public Task InAirPort(int id);
    public Task InInsideStock(int id);

    public Task<OrderGetDto> GetById (int id);
    public Task<OrderListDto> GetAll();
}

