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
    public interface ILoginService
    {
        Task<Employee> Login(LoginDTO loginDTO);
    }
}
