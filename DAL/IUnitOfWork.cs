namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
