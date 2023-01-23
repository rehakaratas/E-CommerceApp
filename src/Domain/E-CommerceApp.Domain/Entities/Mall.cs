using E_CommerceApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApp.Domain.Entities
{
    public class Mall : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Status Status { get; set; }
        public Mall()
        {
            Employees= new List<Employee>();
        }
    }
}
