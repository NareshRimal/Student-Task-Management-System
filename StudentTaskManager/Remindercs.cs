using System;
using StudentTaskManager.Models;

namespace StudentTaskManager.Models
{
    // Abstract base class — demonstrates ABSTRACTION
    public abstract class Reminder
    {
        public TaskItem Task { get; private set; }

        protected Reminder(TaskItem task)
        {
            Task = task;
        }

        // Abstract method — every subclass must provide its own version
        public abstract string GetMessage();
    }

    // Demonstrates INHERITANCE (inherits from Reminder)
    // and POLYMORPHISM (overrides GetMessage())
    public class OverdueReminder : Reminder
    {
        public OverdueReminder(TaskItem task) : base(task) { }

        public override string GetMessage()
        {
            int daysOverdue = (DateTime.Now - Task.DueDate).Days;
            return $"OVERDUE: '{Task.TaskName}' was due {daysOverdue} day(s) ago.";
        }
    }

    // Demonstrates INHERITANCE and POLYMORPHISM
    public class DueSoonReminder : Reminder
    {
        public DueSoonReminder(TaskItem task) : base(task) { }

        public override string GetMessage()
        {
            int daysLeft = (Task.DueDate - DateTime.Now).Days;
            return $"DUE SOON: '{Task.TaskName}' is due in {daysLeft} day(s).";
        }
    }
}