namespace UnitOfWorkAndRepositoryPattern.DbContext
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using UnitOfWorkAndRepositoryPattern.Entities;

    public class SchoolContext : DbContext
    {
        public SchoolContext()
            : base("name=SchoolDB")
        {
        }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<School> Schools { get; set; }
    }
}