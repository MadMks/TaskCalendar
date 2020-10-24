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

        [HttpPost]
        public ActionResult Delete(int id, DateTime dateTime)
        {
            try
            {
                taskRepository.Delete(id);

                return RedirectToAction($"ListTasksForDay",
                    new
                    {
                        y = dateTime.Year,
                        m = dateTime.Month,
                        d = dateTime.Day
                    });
            }
            catch
            {
                return View();
            }
        }
    }
}
