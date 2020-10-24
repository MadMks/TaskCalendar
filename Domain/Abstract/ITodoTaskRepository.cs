using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Abstract
{
    public interface ITodoTaskRepository
    {
        //IEnumerable<TodoTask> Tasks { get; }

        // TODO : get days and quantity tasks
        //IEnumerable<TodoTask> GetNumberOfTasksForEachDay(
        //    DateTime startDate,
        //    int countDay);

        List<IGrouping<DateTime, TodoTask>> GetTasksForEachDay(
            DateTime startDate,
            int countOfDays);

        // TODO : get tasks in day

        List<TodoTask> GetTasksInADay(DateTime dateTime);

        List<DateTime> GetTimesDay(DateTime date);

        void Add(TodoTask task);
    }
}
