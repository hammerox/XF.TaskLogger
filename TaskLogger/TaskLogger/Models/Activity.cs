using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskLogger.Models
{
    public class Activity : ICloneable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }

        public object Clone()
        {
            var clone = new Activity()
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                Date = new DateTime(this.Date.Ticks),
                IsCompleted = this.IsCompleted
            };
            return clone;
        }
    }
}
