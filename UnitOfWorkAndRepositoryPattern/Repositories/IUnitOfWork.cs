using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkAndRepositoryPattern.Entities;

namespace UnitOfWorkAndRepositoryPattern.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        IRepository<School> School { get; }
        IRepository<Student> Student { get; }
    }
}
