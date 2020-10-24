using Domain.Abstract;
using Domain.Context;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Concrete
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        //public IEnumerable<TodoTask> Tasks => throw new NotImplementedException();
        private TaskContext db;

        public TodoTaskRepository(TaskContext taskContext)
        {
            db = taskContext;
        }

        public void Add(TodoTask task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();
        }

        public List<IGrouping<DateTime, TodoTask>> GetTasksForEachDay(DateTime startDate, int countOfDays)
        {
            List<IGrouping<DateTime, TodoTask>> result
                = db.Tasks
                .Where(dt => dt.DateTime.Date >= startDate.Date
                && dt.DateTime.Date <= startDate.AddDays(countOfDays))
                .AsEnumerable()
                .GroupBy(d => d.DateTime.Date)
                .ToList();

            return result;
        }

        public List<TodoTask> GetTasksInADay(DateTime dateTime)
        {
            List<TodoTask> tasks = db.Tasks
                .Where(dt => dt.DateTime.Date == dateTime.Date)
                .ToList();

            return tasks;
        }

        public List<DateTime> GetTimesDay(DateTime date)
        {
            DateTime startTime = new DateTime(
                date.Year, date.Month, date.Day, 8, 0, 0);

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
