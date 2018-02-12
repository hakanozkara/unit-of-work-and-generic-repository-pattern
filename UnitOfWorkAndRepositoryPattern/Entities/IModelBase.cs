using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkAndRepositoryPattern.Entities
{
    public interface IModelBase
    {
        int Id { get; set; }
    }
}
