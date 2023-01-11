namespace POS_Accessories.Data.Repository.Interfaces
{
    public interface IRepository
    {
        Task<int> SaveChangesAsync();
        void Add<TEntity>(TEntity record) where TEntity : class;
        void Update<TEntity>(TEntity record) where TEntity : class;
        void Remove<TEntity>(TEntity record) where TEntity : class;
        IEnumerable<string> GetDirtyPropertyList<TEntity>(TEntity entity) where TEntity : class;
    }
}
