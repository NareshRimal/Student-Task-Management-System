using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using StudentTaskManager.Models;

namespace StudentTaskManager
{
    public class TaskManager
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public void AddTask(TaskItem task)
        {
            // Rule for NEW tasks only: due date cannot be in the past.
            // This is outside the try so the form can show a warning.
            if (task.DueDate.Date < DateTime.Today)
                throw new ArgumentException("Due date cannot be in the past.");

            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText =
                            "INSERT INTO Tasks " +
                            "(TaskName, Unit, Description, DueDate, Priority, Status) " +
                            "VALUES (@name, @unit, @desc, @due, @priority, @status)";

                        command.Parameters.AddWithValue("@name", task.TaskName);
                        command.Parameters.AddWithValue("@unit", task.Unit);
                        command.Parameters.AddWithValue("@desc", task.Description);
                        command.Parameters.AddWithValue("@due", task.DueDate.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@priority", task.Priority.ToString());
                        command.Parameters.AddWithValue("@status", task.Status.ToString());

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add task: " + ex.Message, ex);
            }
        }

        public List<TaskItem> GetAllTasks()
        {
            List<TaskItem> tasks = new List<TaskItem>();

            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM Tasks";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TaskItem task = new TaskItem(
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetString(3),
                                    DateTime.Parse(reader.GetString(4)),
                                    Enum.Parse<Priority>(reader.GetString(5))
                                );

                                task.TaskId = reader.GetInt32(0);
                                task.Status = Enum.Parse<StudentTaskManager.Models.TaskStatus>(
                                    reader.GetString(6));

                                tasks.Add(task);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to load tasks: " + ex.Message, ex);
            }

            return tasks;
        }

        public void UpdateTask(TaskItem task)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText =
                            "UPDATE Tasks SET " +
                            "TaskName = @name, Unit = @unit, Description = @desc, " +
                            "DueDate = @due, Priority = @priority, Status = @status " +
                            "WHERE TaskId = @id";

                        command.Parameters.AddWithValue("@name", task.TaskName);
                        command.Parameters.AddWithValue("@unit", task.Unit);
                        command.Parameters.AddWithValue("@desc", task.Description);
                        command.Parameters.AddWithValue("@due", task.DueDate.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@priority", task.Priority.ToString());
                        command.Parameters.AddWithValue("@status", task.Status.ToString());
                        command.Parameters.AddWithValue("@id", task.TaskId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update task: " + ex.Message, ex);
            }
        }

        public void DeleteTask(int taskId)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "DELETE FROM Tasks WHERE TaskId = @id";
                        command.Parameters.AddWithValue("@id", taskId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete task: " + ex.Message, ex);
            }
        }
    }
} 