using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MovieManagement.DataAccess.Context;
using MovieManagementDomain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MovieManagementDbContext _dbContext;
        private IDbContextTransaction currentTransaction;
        public GenericRepository(MovieManagementDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        //public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        //{
        //    return _dbContext.Set<T>().Where(predicate);
        //}

        //public IEnumerable<T> GetAll()
        //{
        //    return _dbContext.Set<T>().ToList();
        //}


        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().UpdateRange(entities);
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> Find(Expression<Func<T, bool>> filter)
        {
            return _dbContext.Set<T>().AsNoTracking().Where(filter);
        }

        public void UseTransaction(IDbContextTransaction tranasaction)
        {
            _dbContext.Database.UseTransaction(tranasaction.GetDbTransaction());
        }
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (currentTransaction != null) return null;
            currentTransaction = await _dbContext.Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadUncommitted);
            return currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            try
            {

                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                _dbContext.Database.RollbackTransactionAsync();
                throw;

            }
            finally
            {
                if (currentTransaction != null)
                {
                    currentTransaction.Dispose();
                    currentTransaction = null;
                }
            }

        }

        public void RollbackTransactionAsync()
        {
            _dbContext.Database.RollbackTransactionAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        public void RollbackTransaction()
        {
            _dbContext.Database.RollbackTransaction();
        }

        public void CommitTransaction()
        {
            _dbContext.Database.CommitTransaction();
        }
    }
}
