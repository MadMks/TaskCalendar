using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using TaskCalendar.Models;

namespace TaskCalendar.Controllers
{
    public class CalendarController : Controller
    {
        private ITodoTaskRepository taskRepository;
        // Default for testing
        private const int CURRENT_YEAR = 2020;
        private const int CURRENT_MONTH = 10;

        public CalendarController(ITodoTaskRepository _taskRepository)
        {
            taskRepository = _taskRepository;
        }
        //public ViewResult List()
        //{
        //    return View(taskRepository.Tasks);
        //}

        public ViewResult Grid(int y = CURRENT_YEAR, int m = CURRENT_MONTH)
        {
            DateTime selectedDate = new DateTime(y, m, 1);

            List<IGrouping<DateTime, TodoTask>> groupDaysTasks
                = taskRepository.GetTasksForEachDay(
                    DateGrid.GetPrevMonthDateForGrid(selectedDate),
                    6 * 7);

            DateGrid dateGrid = new DateGrid
            {
                SelectedViewDate = selectedDate,
                Days = DateGrid.GetListShowingDays(
                    selectedDate,
                    groupDaysTasks)
            };

            return View(dateGrid);
        }

        public ViewResult ListTasksForDay(int y, int m, int d)
        {
            DateTime selectedDate = new DateTime(y, m, d);

            List<TodoTask> tasks = taskRepository
                .GetTasksInADay(selectedDate);

            DataViewListTask dataViewList
                = new DataViewListTask
                {
                    Tasks = tasks,
                    DropDownTimes = taskRepository.GetTimesDay(selectedDate)
                };

            return View(dataViewList);
        }

        [HttpPost]
        public ActionResult Add(DateTime DateTime, string Description)
        {
            try
            {
                TodoTask newTask = new TodoTask
                {
                    DateTime = DateTime,
                    Description = Description
                };
                taskRepository.Add(newTask);

                return RedirectToAction($"ListTasksForDay", 
                    new { 
                        y = DateTime.Year,
                        m = DateTime.Month,
                        d = DateTime.Day
                    } 
                    );
            }
            catch
            {
                return View();
            }
        }

        public string Test()
        {
            //List<IGrouping<DateTime, TodoTask>> result 
            //    = taskRepository.Tasks
            //    .Where(dt => dt.DateTime.Date >= new DateTime(2020, 10, 23) 
            //    && dt.DateTime.Date <= new DateTime(2020, 10, 23))
            //    .GroupBy(d => d.DateTime.Date)
            //    .ToList();

            //string str = "Count - " + result.Count.ToString() + "\n";

            //str = str + (result[0].Key.ToString() + " - " + result[0].Count());



            //foreach (var item in result)
            //{
            //    foreach (var item2 in item)
            //    {
            //        str = str + item2.
            //    }
            //}
            List<IGrouping<DateTime, TodoTask>> todoTasks
                = taskRepository.GetTasksForEachDay(
                    new DateTime(2020, 10, 23),
                    5);

            string str = todoTasks.Count.ToString();

            return str;
        }
    }
}
