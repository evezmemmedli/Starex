public interface IPackageService
{

    public Task AddAsync(int id);
    public Task<PackageListGetDto> GetAll();
    public Task TakeIt(int id);

}

