using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskCalendar.Models
{
    public class DateGrid
    {
        //public int Year { get; set; }
        //public int Month { get; set; }
        private int prevMonthDay;
        public DateTime SelectedViewDate { get; set; }
        public List<int> Days { get; set; }

        public DateGrid(DateTime dateTime)
        {
            SelectedViewDate = dateTime;
            Days = GetListShowingDays(dateTime);
        }

        private List<int> GetListShowingDays(DateTime dateTime)
        {
            prevMonthDay = (int)dateTime.DayOfWeek - 1;
            dateTime = dateTime.AddDays(-prevMonthDay);

            List<int> list = new List<int>();

            int gridDays = 7 * 6;
            for (int i = 0; i < gridDays; i++)
            {
                list.Add(dateTime.Day);
                dateTime = dateTime.AddDays(1);
            }

            return list;
        }
    }
}
