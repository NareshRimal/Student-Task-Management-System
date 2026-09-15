using System;
using Microsoft.Data.Sqlite;

public class DatabaseHelper
{
    private string connectionString = "Data Source=tasks.db";

    public DatabaseHelper()
    {
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        try
        {
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Tasks (
                        TaskId INTEGER PRIMARY KEY AUTOINCREMENT,
                        TaskName TEXT NOT NULL,
                        Unit TEXT,
                        Description TEXT,
                        DueDate TEXT,
                        Priority TEXT,
                        Status TEXT
                    );";

                using (SqliteCommand command = new SqliteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to initialize database: " + ex.Message);
        }
    }

    public SqliteConnection GetConnection()
    {
        return new SqliteConnection(connectionString);
    }
}