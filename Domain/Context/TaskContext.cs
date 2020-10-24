using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Context
{
    public class TaskContext : DbContext
    {
        public DbSet<TodoTask> Tasks { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
    }
}
