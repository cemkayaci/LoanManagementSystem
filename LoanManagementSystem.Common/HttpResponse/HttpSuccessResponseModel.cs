using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Common.HttpResponse
{
    public class HttpSuccessResponseModel
    {
        public HttpResponseModel HttpResponseModel { get; set; }

        public bool Success { get; set; }
    }
}
