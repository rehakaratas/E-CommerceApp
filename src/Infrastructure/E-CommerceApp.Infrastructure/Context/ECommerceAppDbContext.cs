using E_CommerceApp.Domain.Entities;
using E_CommerceApp.Infrastructure.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApp.Infrastructure.Context
{
    public class ECommerceAppDbContext : DbContext
    {
        public ECommerceAppDbContext(DbContextOptions<ECommerceAppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfig())
                .ApplyConfiguration(new MallConfig());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Mall> Malls { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
