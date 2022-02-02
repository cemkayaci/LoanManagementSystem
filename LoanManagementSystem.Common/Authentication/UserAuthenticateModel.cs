using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Common.Authentication
{
    public  class UserAuthenticateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
