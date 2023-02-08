using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;

namespace POS_Accessories.Data.Repository.Repositories
{
    public class Repository : IRepository
    {
        protected readonly AccessoriesDbContext _context;

        public Repository(AccessoriesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> ExecuteStoredProcedureAsync<TEntity>(string storedProcedure) where TEntity : class
        {
            var list = await _context
                .Set<TEntity>()
                .FromSqlRaw(storedProcedure)
                .ToListAsync();

            return list;
        }

        public async Task<IEnumerable<TEntity>> ExecuteStoredProcedureAsync<TEntity>(string storedProcedure, params SqlParameter[] sqlParameters) where TEntity : class
        {
            var list = await _context
                .Set<TEntity>()
                .FromSqlRaw(storedProcedure, sqlParameters)
                .ToListAsync();

            return list;
        }

        public async Task<int> ExecuteStoredProcedureAsync(string storedProcedure)
        {
            int result = await _context.Database.ExecuteSqlRawAsync(storedProcedure);
            return result;
        }

        public async Task<int> ExecuteStoredProcedureAsync(string storedProcedure, params SqlParameter[] sqlParameters)
        {
            int result = await _context.Database.ExecuteSqlRawAsync(storedProcedure, sqlParameters);
            return result;
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public void Add<TEntity>(TEntity record) where TEntity : class
        {
            _context.Set<TEntity>().Add(record);
        }

        public void Update<TEntity>(TEntity record) where TEntity : class
        {
            _context.Set<TEntity>().Update(record);
        }

        public void Remove<TEntity>(TEntity record) where TEntity : class
        {
            _context.Set<TEntity>().Remove(record);
        }

        public IEnumerable<string> GetDirtyPropertyList<TEntity>(TEntity entity) where TEntity : class
        {
            var modifiedPropertyList = new List<string>();
            var entityEntry = _context.Entry(entity);

            foreach (var property in entityEntry.CurrentValues.Properties)
            {
                var propertyEntry = entityEntry.Property(property.Name);
                if (!propertyEntry.IsModified)
                    continue;

                if (IsSame(propertyEntry.OriginalValue, propertyEntry.CurrentValue))
                    continue;

                modifiedPropertyList.Add(property.Name);
            }

            return modifiedPropertyList;
        }        

        private bool IsSame(object? a, object? b)
        {
            if (a == null && b == null)
                return true;

            if (a == null && b != null)
                return false;

            if (a != null && b == null)
                return false;

            return a.Equals(b);
        }
    }
}
