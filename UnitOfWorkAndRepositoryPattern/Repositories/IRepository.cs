using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkAndRepositoryPattern.Entities;

namespace UnitOfWorkAndRepositoryPattern.Repositories
{
    public interface IRepository<T> where T : IModelBase
    {
        IEnumerable<T> GetAll();
        T GetByID(int entityId);
        void Insert(T entity);
        void Delete(int entityId);
        void Update(T entity);
        //void Save();
        void Insert(List<T> entities);
        IEnumerable<T> GetBy(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = ""
            );
    }
}
