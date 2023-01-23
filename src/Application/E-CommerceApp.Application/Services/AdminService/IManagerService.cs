using E_CommerceApp.Application.Models.DTOs;
using E_CommerceApp.Application.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApp.Application.Services.AdminService
{
    public interface IManagerService
    {
        Task CreatePersonnel(AddPersonnelDTO addPersonnelDTO);
        Task<List<ListOfPersonnelVM>> GetPersonnels();
        Task<UpdatePersonnelDTO> GetPersonnel(Guid id);
        Task UpdatePersonnel(UpdatePersonnelDTO updatePersonnelDTO);

        Task DeletePersonnel(Guid id);
    }
}
