using E_CommerceApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApp.Application.Models.VMs
{
    public class ListOfManagerVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Roles Roles { get; set; }
        public string ImagePath { get; set; }
    }
}
