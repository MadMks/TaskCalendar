using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace TaskCalendar.Models
{
    public class DataViewListTask
    {
        public List<TodoTask> Tasks { get; set; }
        public List<TimeDTO> DropDownTimes { get; set; }
        public DateTime SelectedDate { get; internal set; }
    }
}
