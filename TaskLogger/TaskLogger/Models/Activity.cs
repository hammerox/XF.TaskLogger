using System;
using System.Collections.Generic;
using System.Text;

namespace TaskLogger.Models
{
    public class Activity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }

    }
}
