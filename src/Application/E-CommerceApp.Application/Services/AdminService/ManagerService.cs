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
    public class ManagerService : IManagerService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepo _employeeRepo;

        public ManagerService(IMapper mapper, IEmployeeRepo employeeRepo)
        {
            _mapper = mapper;
            _employeeRepo = employeeRepo;
        }

        public async Task CreatePersonnel(AddPersonnelDTO addPersonnelDTO)
        {
            var addEmployee = _mapper.Map<Employee>(addPersonnelDTO);
            if (addEmployee.UploadPath != null)
            {
                var stream = addPersonnelDTO.UploadPath.OpenReadStream();
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

        public async Task<List<ListOfPersonnelVM>> GetPersonnels()
        {
            var personnels = await _employeeRepo.GetFilteredList(
                select: x => new ListOfPersonnelVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    Roles = x.Roles,
                    ImagePath = x.ImagePath
                },
                where: x => ((x.Status == Status.Active || x.Status == Status.Modified) && x.Roles == Roles.Personnel),
                orderBy: x => x.OrderBy(x => x.Name));

            return personnels;
        }

        public async Task<UpdatePersonnelDTO> GetPersonnel(Guid id)
        {
            var personnel = await _employeeRepo.GetFilteredFirstOrDefault(
                select: x => new UpdatePersonnelVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    ImagePath = x.ImagePath,
                },
                where: x => x.Id == id);
            var updatePersonnelDTO = _mapper.Map<UpdatePersonnelDTO>(personnel);
            return updatePersonnelDTO;
        }

        public async Task UpdatePersonnel(UpdatePersonnelDTO updatePersonnelDTO)
        {
            var model = await _employeeRepo.GetDefault(x => x.Id == updatePersonnelDTO.Id);
            model.Name = updatePersonnelDTO.Name;
            model.Surname = updatePersonnelDTO.Surname;
            model.UpdatedDate = updatePersonnelDTO.UpdatedDate;
            model.Status = updatePersonnelDTO.Status;
            using var image = Image.Load(updatePersonnelDTO.UploadPath.OpenReadStream());
            image.Mutate(x => x.Resize(600, 560));
            Guid guid = Guid.NewGuid();
            image.Save($"wwwroot/images/{guid}.jpg");
            model.ImagePath = ($"/images/{guid}.jpg");

            await _employeeRepo.Update(model);
        }

        public async Task DeletePersonnel(Guid id)
        {
            var model = await _employeeRepo.GetDefault(x => x.Id == id);
            model.DeletedDate = DateTime.Now;
            model.Status = Status.Passive;

            await _employeeRepo.Delete(model);
        }
    }
}
