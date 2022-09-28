using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDockTestApp.Models
{
    /// <summary>
    /// Статус задачи
    /// </summary>
    public enum TodoStatus
    {
        /// <summary>
        /// Статус не определен
        /// </summary>
        Undefined = 0,
        /// <summary>
        /// Создана
        /// </summary>
        Created,
        /// <summary>
        /// В процессе
        /// </summary>
        InProgress,
        /// <summary>
        /// Выполнена
        /// </summary>
        Done
    }
}
