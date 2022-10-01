using AutoDockTestApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AutoDockTestApp.Context
{
    public interface IApplicationContext
    {
        DbSet<TodoItemFileAttachment> FileAttachments { get; set; }
        DbSet<TodoItem> Tasks { get; set; }

        public Task<int> SaveChanges();
    }
}