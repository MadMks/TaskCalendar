using Domain.Entities;
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
        //private int prevMonthDay;
        public DateTime SelectedViewDate { get; set; }
        public List<DayCol> Days { get; set; }

        //public DateGrid(DateTime dateTime, List<IGrouping<DateTime, TodoTask>> groupDaysTasks)
        //{
        //    SelectedViewDate = dateTime;
        //    Days = GetListShowingDays(dateTime, groupDaysTasks);
        //}

        //public DateGrid(DateTime dateTime, List<IGrouping<DateTime, TodoTask>> groupDaysTasks)
        //{
        //    SelectedViewDate = dateTime;
        //    Days = GetListShowingDays(dateTime, groupDaysTasks);
        //}

        public static List<DayCol> GetListShowingDays(
            DateTime dateTime, List<IGrouping<DateTime, TodoTask>> groupDaysTasks)
        {
            dateTime = GetPrevMonthDateForGrid(dateTime);

            List<DayCol> listDayCol = new List<DayCol>();

            int gridDays = 7 * 6;
            for (int i = 0; i < gridDays; i++)
            {
                if (IsTaskExists(dateTime, groupDaysTasks))
                {
                    var groupTasks =
                        groupDaysTasks
                        .Where(dt => dt.Key.Date == dateTime.Date)
                        .FirstOrDefault();

                    listDayCol.Add(
                        new DayCol
                        {
                            Date = dateTime,
                            QuantityTask = groupTasks.Count()
                        }
                        );
                }
                else
                {
                    listDayCol.Add(
                        new DayCol
                        {
                            Date = dateTime,
                            QuantityTask = 0
                        }
                        );
                }
                dateTime = dateTime.AddDays(1);
            }

            return listDayCol;
        }

        public static DateTime GetPrevMonthDateForGrid(DateTime dateTime)
        {
            int prevMonthDay = (int)dateTime.DayOfWeek - 1;
            dateTime = dateTime.AddDays(-prevMonthDay);
            return dateTime;
        }

        private static bool IsTaskExists(
            DateTime dateTime,
            List<IGrouping<DateTime, TodoTask>> groupDaysTasks)
        {
            foreach (var group in groupDaysTasks)
            {
                if (group.Key.Date == dateTime.Date)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
