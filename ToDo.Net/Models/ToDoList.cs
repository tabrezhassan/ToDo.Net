using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDo.Net.Models
{
    public class ToDoList
    {
        public enum Priority
        {
            LOW,MEDIUM,HIGH
        }

        public int ID { get; set; }

        [Required]
        public string Task { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        [DisplayFormat(NullDisplayText = "", ApplyFormatInEditMode = true)]
        public Priority? TaskPriority { get; set; }
        public bool Completed { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "", ApplyFormatInEditMode = true)]
        public DateTime? DateCompleted { get; set; }

        [DisplayFormat(NullDisplayText = "", ApplyFormatInEditMode = true)]
        public int? DaysToComplete { get; set; }

    }
}