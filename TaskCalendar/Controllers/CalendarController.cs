using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace TaskCalendar.Controllers
{
    public class CalendarController : Controller
    {
        private ITodoTaskRepository taskRepository;

        public CalendarController(ITodoTaskRepository _taskRepository)
        {
            taskRepository = _taskRepository;
        }
        public ViewResult List()
        {
            return View(taskRepository.Tasks);
        }
    }
}
