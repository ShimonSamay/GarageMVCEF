using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Garage.Models
{
    public partial class GarageDB_Context : DbContext
    {
        public GarageDB_Context(string stringConnection)
            : base("name=GarageDBContext")
        {
        }
        public virtual DbSet<Car> Cars { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
