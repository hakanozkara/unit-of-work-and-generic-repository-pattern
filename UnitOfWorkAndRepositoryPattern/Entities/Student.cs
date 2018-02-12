using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkAndRepositoryPattern.Entities
{
    public class Student : ModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int No { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}
