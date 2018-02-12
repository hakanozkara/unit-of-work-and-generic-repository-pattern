using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkAndRepositoryPattern.Entities
{
    public class ModelBase : IModelBase
    {
        public int Id { get; set; }
    }
}
