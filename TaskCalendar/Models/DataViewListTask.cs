using Domain.Entities;
using System;
using System.Collections.Generic;

namespace TaskCalendar.Models
{
    public class DataViewListTask
    {
        public List<TodoTask> Tasks { get; set; }
        public List<DateTime> DropDownTimes { get; set; }
    }
}
