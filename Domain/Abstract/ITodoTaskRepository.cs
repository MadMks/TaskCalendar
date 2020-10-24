using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Abstract
{
    public interface ITodoTaskRepository
    {
        //IEnumerable<TodoTask> Tasks { get; }

        List<IGrouping<DateTime, TodoTask>> GetTasksForEachDay(
            DateTime startDate,
            int countOfDays);

        List<TodoTask> GetTasksInADay(DateTime dateTime);

        List<DateTime> GetTimesDay(DateTime date);

        void Add(TodoTask task);
        void Delete(int id);
    }
}
