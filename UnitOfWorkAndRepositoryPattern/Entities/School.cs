using System.Collections.Generic;

namespace UnitOfWorkAndRepositoryPattern.Entities
{
    public class School : ModelBase
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public ICollection<Student> Student { get; set; }
    }
}