using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TodoTask
    {
        public int TodoTaskID { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
    }
}
