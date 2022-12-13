using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merca_Darius_Lab2.Models
{
    public class RoleEdit
    {
        public IdentityRole? Role { get; set; }
        public IEnumerable<IdentityUser>? Members { get; set; }
        public IEnumerable<IdentityUser>? NonMembers { get; set; }

    }
}
