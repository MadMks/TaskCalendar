using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Add(TodoTask task)
        {
            throw new NotImplementedException();
        }

        public List<IGrouping<DateTime, TodoTask>> GetTasksForEachDay(DateTime startDate, int countOfDays)
        {
            List<IGrouping<DateTime, TodoTask>> result
                = Tasks
                .Where(dt => dt.DateTime.Date >= startDate.Date
                && dt.DateTime.Date <= startDate.AddDays(countOfDays))
                .GroupBy(d => d.DateTime.Date)
                .ToList();

            return result;
        }

        public List<TodoTask> GetTasksInADay(DateTime dateTime)
        {
            List<TodoTask> tasks = Tasks
                .Where(dt => dt.DateTime.Date == dateTime.Date)
                .ToList();

            return tasks;
        }


        public List<DateTime> GetTimesDay(DateTime date)
        {
            DateTime startTime = new DateTime(1, 1, 1, 8, 0, 0);
            List<DateTime> times = new List<DateTime>();

            for (int i = 0; i < 24; i++)
            {
                times.Add(startTime/*.ToString("H:mm")*/);
                startTime = startTime.AddMinutes(30);
            }

            return times;
        }
    }
}
