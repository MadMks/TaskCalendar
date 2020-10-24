using Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
