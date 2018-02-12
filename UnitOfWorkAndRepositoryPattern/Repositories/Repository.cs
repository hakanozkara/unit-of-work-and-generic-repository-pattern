using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkAndRepositoryPattern.DbContext;
using UnitOfWorkAndRepositoryPattern.Entities;

namespace UnitOfWorkAndRepositoryPattern.Repositories
{
    public class Repository<T> : IRepository<T> where T : ModelBase, new()
    {
        private readonly SchoolContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(SchoolContext _context)
        {
            _dbContext = _context;
            _dbSet = _context.Set<T>();
        }
        
        public void Delete(int entityId)
        {
            T entity = GetByID(entityId);
            DbEntityEntry dbEntityEntry = _dbContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetByID(int entityId)
        {
            return _dbSet.FirstOrDefault(p => p.Id == entityId);
        }
        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Insert(List<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        //public List<T> GetBy(Expression<Func<T, bool>> predicate)
        //{
        //    return _dbSet.Where(predicate).ToList();
        //}

        public virtual IEnumerable<T> GetBy(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
    }
}
