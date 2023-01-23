using AutoMapper;
using E_CommerceApp.Application.Models.DTOs;
using E_CommerceApp.Application.Models.VMs;
using E_CommerceApp.Domain.Entities;
using E_CommerceApp.Domain.Enums;
using E_CommerceApp.Domain.Repositories;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApp.Application.Services.AdminService
{
    public class AdminService : IAdminService
    {        
        private readonly IMapper _mapper;
        private readonly IEmployeeRepo _employeeRepo;

        public AdminService(IMapper mapper, IEmployeeRepo employeeRepo)
        {
            _mapper = mapper;
            _employeeRepo = employeeRepo;
        }

        public async Task CreateManager(AddManagerDTO addManagerDTO)
        {
            var addEmployee = _mapper.Map<Employee>(addManagerDTO);
            if (addEmployee.UploadPath != null)
            {
                var stream = addManagerDTO.UploadPath.OpenReadStream();
                using var image = Image.Load(stream);

                image.Mutate(x => x.Resize(600, 560));
                Guid guid = Guid.NewGuid();
                image.Save($"wwwroot/images/{guid}.jpg");

                addEmployee.ImagePath = ($"/images/{guid}.jpg");
                await _employeeRepo.Create(addEmployee);
            }
            else
            {
                addEmployee.ImagePath = ($"/images/default.jpg");
                await _employeeRepo.Create(addEmployee);
            }
        }

        public async Task<List<ListOfManagerVM>> GetManagers()
        {
            var managers = await _employeeRepo.GetFilteredList(
                select: x => new ListOfManagerVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    Roles = x.Roles,
                    ImagePath = x.ImagePath
                },
                where: x => ((x.Status == Status.Active || x.Status == Status.Modified) && x.Roles == Roles.Manager),
                orderBy: x => x.OrderBy(x => x.Name));

            return managers;
        }

        public async Task<UpdateManagerDTO> GetManager(Guid id)
        {
            var manager = await _employeeRepo.GetFilteredFirstOrDefault(
                select: x => new UpdateManagerVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    ImagePath = x.ImagePath,
                },
                where: x => x.Id == id);
            var updateManagerDTO = _mapper.Map<UpdateManagerDTO>(manager);
            return updateManagerDTO;
        }

        public async Task UpdateManager(UpdateManagerDTO updateManagerDTO)
        {
            var model = await _employeeRepo.GetDefault(x => x.Id == updateManagerDTO.Id);
            model.Name = updateManagerDTO.Name;
            model.Surname = updateManagerDTO.Surname;
            model.UpdatedDate = updateManagerDTO.UpdatedDate;
            model.Status = updateManagerDTO.Status;
            using var image = Image.Load(updateManagerDTO.UploadPath.OpenReadStream());
            image.Mutate(x => x.Resize(600, 560));
            Guid guid = Guid.NewGuid();
            image.Save($"wwwroot/images/{guid}.jpg");
            model.ImagePath = ($"/images/{guid}.jpg");

            await _employeeRepo.Update(model);
        }

        public async Task DeleteManager(Guid id)
        {
            var model = await _employeeRepo.GetDefault(x => x.Id == id);
            model.DeletedDate = DateTime.Now;
            model.Status = Status.Passive;

            await _employeeRepo.Delete(model);
        }
    }
}
