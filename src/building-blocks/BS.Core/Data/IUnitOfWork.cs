namespace BS.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
