using System;
using System.Collections.Generic;
using System.Text;

namespace TaskLogger.Models
{
    public class Activity : ICloneable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }

        public object Clone()
        {
            var clone = new Activity()
            {
                Name = this.Name,
                Description = this.Description,
                Date = new DateTime(this.Date.Ticks),
                IsCompleted = this.IsCompleted
            };
            return clone;
        }
    }
}
