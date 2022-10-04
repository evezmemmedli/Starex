    public interface IPaymentService
    {
       public Task IncreaeBalance(decimal amount,string userid);
       public Task Pay(decimal amount,string userid);
     
    }
