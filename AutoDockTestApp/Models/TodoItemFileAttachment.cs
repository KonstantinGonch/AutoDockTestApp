using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDockTestApp.Models
{
    /// <summary>
    /// Файл, прикрепленный к задаче
    /// </summary>
    public class TodoItemFileAttachment
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Полное имя файла
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Короткое имя
        /// </summary>
        [Required(ErrorMessage = "Необходимо заполнить наименование файла")]
        public string DisplayName { get; set; }
        /// <summary>
        /// Id задачи
        /// </summary>
        public long TodoItemId { get; set; }
        /// <summary>
        /// Задача
        /// </summary>
        public TodoItem TodoItem { get; set; }
    }
}
