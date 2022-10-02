using AutoDockTestApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDockTestApp.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<TodoItem> Tasks { get; set; }
        public DbSet<TodoItemFileAttachment> FileAttachments { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem
                {
                    Id = 2,
                    Title = "Составить и отправить СЗВ-М",
                    Status = TodoStatus.InProgress,
                    CreationDate = DateTime.Now
                }
            );
        }
    }
}
