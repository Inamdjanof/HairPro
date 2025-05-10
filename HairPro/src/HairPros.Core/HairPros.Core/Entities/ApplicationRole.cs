using HairPros.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Core.Entities
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public int RoleType { get; set; }  

        public ApplicationRole() : base() { }

        public ApplicationRole(UserRole role) : base(role.ToString())
        {
            Id = Guid.NewGuid();
            RoleType =(int) role;
        }
    }
}
