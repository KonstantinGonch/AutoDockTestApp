using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDockTestApp.Util
{
    /// <summary>
    /// Утилита для работы с прикрепленными файлами
    /// </summary>
    public interface IAttachmentManager
    {
        /// <summary>
        /// Сохранить файл в памяти
        /// </summary>
        /// <param name="fileData"></param>
        /// <returns></returns>
        Task<string> SaveAttachmentAsync(IFormFile fileData);
        /// <summary>
        /// Удалить файл из памяти
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        Task DeleteAttachmentAsync(string fileName);
    }
}
