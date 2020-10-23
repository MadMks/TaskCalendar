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
        private const int CURRENT_YEAR = 2020;
        private const int CURRENT_MONTH = 10;

        public CalendarController(ITodoTaskRepository _taskRepository)
        {
            taskRepository = _taskRepository;
        }
        public ViewResult List()
        {
            return View(taskRepository.Tasks);
        }

        public ViewResult Grid(int y = CURRENT_YEAR, int m = CURRENT_MONTH)
        {
            DateTime selectedDate = new DateTime(y, m, 1);

            DateGrid dateGrid = new DateGrid(selectedDate);

            return View(dateGrid);
        }
    }
}
