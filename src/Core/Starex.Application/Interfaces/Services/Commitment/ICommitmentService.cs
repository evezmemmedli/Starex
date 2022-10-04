public interface ICommitmentService
{
    public Task AddAsync(CommitmentPostDto commitmentPostDto);
    public Task Remove(int id);
    public Task<CommitmentListDto> GetAll();
}

