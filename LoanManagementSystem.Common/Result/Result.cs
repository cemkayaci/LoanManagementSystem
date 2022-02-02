using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Common.Response
{
    public class Result<T>  where T : class, new() 
    {
        public bool IsSuccess { get; set; } = false;
        public T response { get; set;} = new T();
    }
}
