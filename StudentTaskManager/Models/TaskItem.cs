using System;

namespace StudentTaskManager.Models
{
    public class TaskItem
    {
        private string taskName = string.Empty;

        public int TaskId { get; set; }

        // ENCAPSULATION: the name is checked inside the setter
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

        // No past-date check here, so old saved tasks can still load
        public DateTime DueDate { get; set; }

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
