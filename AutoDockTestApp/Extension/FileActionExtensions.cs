using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDockTestApp.Extension
{
    public static class FileActionExtensions
    {
        public static Task DeleteAsync(this FileInfo fi)
        {
            return Task.Factory.StartNew(() => fi.Delete());
        }
    }
}
