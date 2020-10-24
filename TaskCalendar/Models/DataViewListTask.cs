using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskCalendar.Models
{
    public class DataViewListTask
    {
        public List<TodoTask> Tasks { get; set; }
        //public List<DateTime> DropDownDateTimes { get; set; }
        public List<DateTime> DropDownTimes { get; set; }
    }
}
