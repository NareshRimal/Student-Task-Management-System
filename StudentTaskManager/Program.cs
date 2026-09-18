using System;
using System.Windows.Forms;

namespace StudentTaskManager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configure the Windows Forms application.
            ApplicationConfiguration.Initialize();

            // Create the database and Tasks table if they do not already exist.
            DatabaseHelper databaseHelper = new DatabaseHelper();
            databaseHelper.CreateDatabase();

            // Start the main application window.
            Application.Run(new Form1());
        }
    }
}