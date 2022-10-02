using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDockTestApp.Common
{
    public class PagedResponseModel<T>
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
