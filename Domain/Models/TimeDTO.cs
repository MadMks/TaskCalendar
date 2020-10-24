using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class TimeDTO
    {
        public int Hour { get; set; }
        public int Minute { get; set; }

        public TimeDTO() { }
        public TimeDTO(string time)
        {
            string[] arr = time.Split(':');
            Hour = Convert.ToInt32(arr[0]);
            Minute = Convert.ToInt32(arr[1]);
        }

        public override string ToString()
        {
            return $"{Hour.ToString("00")}:{Minute.ToString("00")}";
        }
    }
}
