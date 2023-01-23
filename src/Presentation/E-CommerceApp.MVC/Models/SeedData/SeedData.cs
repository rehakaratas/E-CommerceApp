using E_CommerceApp.Domain.Entities;
using E_CommerceApp.Domain.Enums;
using E_CommerceApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceApp.MVC.Models.SeedData
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<ECommerceAppDbContext>();
            dbContext.Database.Migrate();

            if (dbContext.Categories.Count() == 0)
            {
                dbContext.Categories.Add(new Category()
                {
                    Id= Guid.NewGuid(),
                    Name = "Home Appliances",
                    CreatedDate= DateTime.Now,
                    Status = Status.Active
                });
                dbContext.Categories.Add(new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Electronics",
                    CreatedDate = DateTime.Now,
                    Status = Status.Active
                });
                dbContext.Categories.Add(new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Textile",
                    CreatedDate = DateTime.Now,
                    Status = Status.Active
                });
            }
            if (dbContext.Employees.Count() == 0)
            {
                dbContext.Employees.Add(new Employee()
                {
                    Id = Guid.NewGuid(),
                    Name = "Reha",
                    Surname = "Karataş",
                    EmailAddress = "reha.karatas@bilgeadamboost.com",
                    Status = Status.Active,
                    Password = "1234",
                    CreatedDate = DateTime.Now,
                    Roles = Roles.Admin,
                    BirthDate= new DateTime(1988,2,11)
                    
                });
            }
            dbContext.SaveChanges();
        }
    }
}
