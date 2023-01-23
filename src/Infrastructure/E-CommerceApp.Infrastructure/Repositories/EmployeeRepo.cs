using E_CommerceApp.Domain.Entities;
using E_CommerceApp.Domain.Repositories;
using E_CommerceApp.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApp.Infrastructure.Repositories
{
    public class EmployeeRepo : BaseRepo<Employee>, IEmployeeRepo
    {
        public EmployeeRepo(ECommerceAppDbContext eCommerceAppDbContext) : base(eCommerceAppDbContext)
        {
        }
    }
}
