using Domain.Entities;
using System;
using System.Linq;

namespace Domain.Context
{
    public static class DbInitializer
    {
        public static void Initialize(TaskContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Tasks.Any())
            {
                return;   // DB has been seeded
            }

            var tasks = new TodoTask[]
            {
                new TodoTask
                {
                    DateTime = DateTime.Parse("23.10.2020 10:00:00"),
                    Description = "Task 1"
                },
                new TodoTask
                {
                    DateTime = DateTime.Parse("23.10.2020 11:00:00"),
                    Description = "Task 2"
                },
                new TodoTask
                {
                    DateTime = DateTime.Parse("24.10.2020 10:00:00"),
                    Description = "Task 3"
                },
                new TodoTask
                {
                    DateTime = DateTime.Parse("23.10.2020 12:00:00"),
                    Description = "Task 4"
                },

                new TodoTask
                {
                    DateTime = DateTime.Parse("28.9.2020 10:00:00"),
                    Description = "Task 5"
                },
                new TodoTask
                {
                    DateTime = DateTime.Parse("8.11.2020 12:00:00"),
                    Description = "Task 6"
                }
            };
            foreach (TodoTask task in tasks)
            {
                context.Tasks.Add(task);
            }
            context.SaveChanges();
        }
    }
}
