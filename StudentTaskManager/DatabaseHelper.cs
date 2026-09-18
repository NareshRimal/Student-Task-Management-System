using Microsoft.Data.Sqlite;

namespace StudentTaskManager
{
    public class DatabaseHelper
    {
        private string connectionString = "Data Source=studenttasks.db";

        public SqliteConnection GetConnection()
        {
            return new SqliteConnection(connectionString);
        }

        public void CreateDatabase()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Tasks
                    (
                        TaskId INTEGER PRIMARY KEY AUTOINCREMENT,
                        TaskName TEXT NOT NULL,
                        Unit TEXT NOT NULL,
                        Description TEXT,
                        DueDate TEXT NOT NULL,
                        Priority TEXT NOT NULL,
                        Status TEXT NOT NULL
                    )";

                command.ExecuteNonQuery();
            }
        }
    }
}
 