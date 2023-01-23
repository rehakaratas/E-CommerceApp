using AutoMapper;
using E_CommerceApp.Application.Models.DTOs;
using E_CommerceApp.Application.Models.VMs;
using E_CommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApp.Application.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Employee,AddManagerDTO>().ReverseMap();
            CreateMap<Employee,AddPersonnelDTO>().ReverseMap();

            CreateMap<Employee,ListOfManagerVM>().ReverseMap();
            CreateMap<Employee,ListOfPersonnelVM>().ReverseMap();

            CreateMap<UpdateManagerVM,UpdateManagerDTO>().ReverseMap();
            CreateMap<UpdatePersonnelVM,UpdatePersonnelDTO>().ReverseMap();

            CreateMap<UpdateManagerDTO,Employee>().ReverseMap();
            CreateMap<UpdatePersonnelDTO,Employee>().ReverseMap();
        }
    }
}
