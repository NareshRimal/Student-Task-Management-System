using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

public class TaskManager
{
    private DatabaseHelper dbHelper = new DatabaseHelper();

    public void AddTask(TaskItem task)
    {
        try
        {
            var connection = dbHelper.GetConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Tasks (TaskName, Unit, Description, DueDate, Priority, Status) " +
                                   "VALUES (@name, @unit, @desc, @due, @priority, @status)";

            command.Parameters.AddWithValue("@name", task.TaskName);
            command.Parameters.AddWithValue("@unit", task.Unit);
            command.Parameters.AddWithValue("@desc", task.Description);
            command.Parameters.AddWithValue("@due", task.DueDate.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@priority", task.Priority.ToString());
            command.Parameters.AddWithValue("@status", task.Status.ToString());

            command.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to add task: " + ex.Message);
        }
    }

    public List<TaskItem> GetAllTasks()
    {
        List<TaskItem> tasks = new List<TaskItem>();

        try
        {
            var connection = dbHelper.GetConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Tasks";
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                TaskItem task = new TaskItem(
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    DateTime.Parse(reader.GetString(4)),
                    (Priority)Enum.Parse(typeof(Priority), reader.GetString(5))
                );
                task.TaskId = reader.GetInt32(0);
                task.Status = (TaskStatus)Enum.Parse(typeof(TaskStatus), reader.GetString(6));
                tasks.Add(task);
            }

            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to load tasks: " + ex.Message);
        }

        return tasks;
    }

    public void DeleteTask(int taskId)
    {
        try
        {
            var connection = dbHelper.GetConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Tasks WHERE TaskId = @id";
            command.Parameters.AddWithValue("@id", taskId);

            command.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to delete task: " + ex.Message);
        }
    }
}