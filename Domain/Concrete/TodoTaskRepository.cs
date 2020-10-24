using Domain.Abstract;
using Domain.Context;
using Domain.Entities;
using Domain.Models;
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

        public List<TimeDTO> GetTimesDay()
        {
            DateTime startTime = new DateTime(
                1, 1, 1, 8, 0, 0);

            List<TimeDTO> times = new List<TimeDTO>();

            for (int i = 0; i < 24; i++)
            {
                times.Add(new TimeDTO 
                {
                    Hour = startTime.Hour,
                    Minute = startTime.Minute
                });
                startTime = startTime.AddMinutes(30);
            }

            return times;
        }
    }
}
