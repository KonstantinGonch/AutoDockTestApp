using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDockTestApp.Models
{
    /// <summary>
    /// Задача
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public TodoStatus Status { get; set; }
        /// <summary>
        /// Прикрепленные файлы
        /// </summary>
        public IEnumerable<TodoItemFileAttachment> Attachments { get; set; }
    }
}
