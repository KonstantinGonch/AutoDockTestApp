﻿using System;
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
    }
}
