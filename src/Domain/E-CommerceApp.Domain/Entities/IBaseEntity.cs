using E_CommerceApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApp.Domain.Entities
{
    public interface IBaseEntity
    {
        DateTime CreatedDate { get; set; }
        DateTime? DeletedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
        Status Status { get; set; }
    }
}
