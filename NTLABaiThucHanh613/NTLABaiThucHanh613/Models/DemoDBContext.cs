using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NTLABaiThucHanh613.Models
{
    public partial class DemoDBContext : DbContext
    {
        public DemoDBContext()
            : base("name=DemoDBContext2")
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
