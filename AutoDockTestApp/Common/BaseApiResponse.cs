using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDockTestApp.Common
{
    public class BaseApiResponse<T>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public T Response { get; set; }
    }
}
