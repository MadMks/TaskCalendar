using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;
using Domain.Models;
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
                    SelectedDate = selectedDate,
                    Tasks = tasks,
                    DropDownTimes = taskRepository.GetTimesDay()
                };

            return View(dataViewList);
        }

        [HttpPost]
        public ActionResult Add(string time, string description, DateTime curDate)
        {
            try
            {
                TimeDTO timeDTO = new TimeDTO(time);
                DateTime date = new DateTime(
                    curDate.Year, curDate.Month, curDate.Day,
                    timeDTO.Hour, timeDTO.Minute, 0);
                TodoTask newTask = new TodoTask
                {
                    DateTime = date,
                    Description = description
                };
                taskRepository.Add(newTask);

                return RedirectToAction($"ListTasksForDay", 
                    new { 
                        y = curDate.Year,
                        m = curDate.Month,
                        d = curDate.Day
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
