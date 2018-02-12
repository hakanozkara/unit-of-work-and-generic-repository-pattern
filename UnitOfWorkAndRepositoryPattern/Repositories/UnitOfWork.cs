using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkAndRepositoryPattern.DbContext;
using UnitOfWorkAndRepositoryPattern.Entities;

namespace UnitOfWorkAndRepositoryPattern.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private SchoolContext _context = new SchoolContext();

        private IRepository<Student> _studentRepo;
        private IRepository<School> _schoolRepo;
        private bool _disposed = false;
              

        public IRepository<Student> Student
        {
            get
            {
                return _studentRepo ?? new Repository<Student>(_context);
            }
        }

        public IRepository<School> School
        {
            get
            {
                return _schoolRepo ?? new Repository<School>(_context);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose (bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
