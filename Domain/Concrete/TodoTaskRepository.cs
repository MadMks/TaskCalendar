using Domain.Abstract;
using Domain.Context;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Concrete
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
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

        public void Delete(int id)
        {
            TodoTask task = db.Tasks
                .Where(t => t.TodoTaskID == id)
                .FirstOrDefault();

            db.Tasks.Remove(task);
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
                times.Add(startTime);
                startTime = startTime.AddMinutes(30);
            }

            return times;
        }
    }
}
