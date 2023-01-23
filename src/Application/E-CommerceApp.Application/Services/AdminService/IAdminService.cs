using E_CommerceApp.Application.Models.DTOs;
using E_CommerceApp.Application.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApp.Application.Services.AdminService
{
    public interface IAdminService
    {
        Task CreateManager(AddManagerDTO addManagerDTO);
        Task<List<ListOfManagerVM>> GetManagers();
        Task<UpdateManagerDTO> GetManager(Guid id);
        Task UpdateManager(UpdateManagerDTO updateManagerDTO);

        Task DeleteManager(Guid id);
    }
}
