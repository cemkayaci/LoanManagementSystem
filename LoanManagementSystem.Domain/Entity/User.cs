using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Domain.Entity
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public Role Role { get; set; }

        public DateTime TokenExpires { get; set; }
    }
}
