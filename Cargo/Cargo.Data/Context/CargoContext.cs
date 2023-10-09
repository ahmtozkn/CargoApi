using Cargo.Data.Entities;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Data.Context
{
   public  class CargoContext:DbContext
    {
       

        public CargoContext(DbContextOptions<CargoContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CargoConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CargoEntity> Cargos =>Set<CargoEntity>();

        public DbSet<EmployeeEntity> Employees =>Set<EmployeeEntity>();
       

    }
}
