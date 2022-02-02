using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Common.Token
{
    public class TokenModel
    {
        public string Token { get; set; }

        public DateTime ExpireTime { get; set; }
    }
}
