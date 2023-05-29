using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementDomain.Interface.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> filter);
        //IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        public void UseTransaction(IDbContextTransaction tranasaction);
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitTransactionAsync(IDbContextTransaction transaction);
        void RollbackTransactionAsync();
        IDbContextTransaction BeginTransaction();
        void RollbackTransaction();
        void CommitTransaction();
        


    }
}