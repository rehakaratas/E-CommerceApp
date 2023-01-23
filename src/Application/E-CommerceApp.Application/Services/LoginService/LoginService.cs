using E_CommerceApp.Application.Models.DTOs;
using E_CommerceApp.Domain.Entities;
using E_CommerceApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApp.Application.Services.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly IEmployeeRepo _employeeRepo;

        public LoginService(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<Employee> Login(LoginDTO loginDTO)
        {
            var employee = await _employeeRepo.GetDefault(x => x.EmailAddress == loginDTO.EmailAddress && x.Password == loginDTO.Password);
            return employee;
        }
    }
}
