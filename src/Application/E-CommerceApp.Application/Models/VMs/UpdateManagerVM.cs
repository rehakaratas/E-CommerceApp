using E_CommerceApp.Application.Extensions;
using E_CommerceApp.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApp.Application.Models.VMs
{
    public class UpdateManagerVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? UpdatedDate => DateTime.Now;
        public Status Status => Status.Modified;
        public Roles Roles => Roles.Manager;
        public string? ImagePath { get; set; }        
        public IFormFile UploadPath { get; set; }
    }
}
