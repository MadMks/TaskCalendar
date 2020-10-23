using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Concrete
{
    public class FakeTodoTaskRepository : ITodoTaskRepository
    {
        public IEnumerable<TodoTask> Tasks => new List<TodoTask>
        {
            new TodoTask
            {
                DateTime = DateTime.Parse("23.10.2020 10:00:00"),
                Description = "Task 1"
            },
            new TodoTask
            {
                DateTime = DateTime.Parse("23.10.2020 10:00:00"),
                Description = "Task 2"
            },
            new TodoTask
            {
                DateTime = DateTime.Parse("24.10.2020 10:00:00"),
                Description = "Task 3"
            },
            new TodoTask
            {
                DateTime = DateTime.Parse("23.10.2020 10:00:00"),
                Description = "Task 4"
            },
        };
    }
}
