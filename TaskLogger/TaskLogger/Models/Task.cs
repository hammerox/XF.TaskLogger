using System;
using System.Collections.Generic;
using System.Text;

namespace TaskLogger.Models
{
    public class Activity
    {
        public string name;
        public string description;
        public DateTime date;
        public bool isCompleted;

        public Activity(string name, string description, DateTime date, bool isCompleted)
        {
            this.name = name;
            this.description = description;
            this.date = date;
            this.isCompleted = isCompleted;
        }
    }
}
