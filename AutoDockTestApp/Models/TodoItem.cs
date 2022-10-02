using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Необходимо заполнить наименование задачи")]
        public string Title { get; set; }
        /// <summary>
        /// Дата
        /// </summary>
        [Required(ErrorMessage = "Необходимо предоставитт дату создания")]
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        [Required(ErrorMessage = "Необходимо присвоить статус задачи")]
        public TodoStatus Status { get; set; }
        /// <summary>
        /// Прикрепленные файлы
        /// </summary>
        public IEnumerable<TodoItemFileAttachment> Attachments { get; set; }
    }
}
