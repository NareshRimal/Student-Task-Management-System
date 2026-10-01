using System;

namespace StudentTaskManager.Models
{
    public class TaskItem
    {
        private string taskName;
        private DateTime dueDate;

        public int TaskId { get; set; }

        // ENCAPSULATION: validation happens inside the setter
        public string TaskName
        {
            get { return taskName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Task name cannot be empty.");
                taskName = value;
            }
        }

        public string Unit { get; set; }

        public string Description { get; set; }

        // ENCAPSULATION: validation happens inside the setter
        public DateTime DueDate
        {
            get { return dueDate; }
            set
            {
                if (value < DateTime.Now.Date)
                    throw new ArgumentException("Due date cannot be in the past.");
                dueDate = value;
            }
        }

        public Priority Priority { get; set; }

        public TaskStatus Status { get; set; }

        public TaskItem(
            string taskName,
            string unit,
            string description,
            DateTime dueDate,
            Priority priority)
        {
            TaskName = taskName;
            Unit = unit;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
            Status = TaskStatus.Pending;
        }
    }
}