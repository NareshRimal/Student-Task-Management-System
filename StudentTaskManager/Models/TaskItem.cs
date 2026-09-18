using System;

namespace StudentTaskManager.Models
{
    public class TaskItem
    {
        public int TaskId { get; set; }

        public string TaskName { get; set; }

        public string Unit { get; set; }

        public string Description { get; set; }

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
