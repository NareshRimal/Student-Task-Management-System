using System;
using System.Windows.Forms;
using StudentTaskManager.Models;

namespace StudentTaskManager
{
    public partial class Form1 : Form
    {
        private TaskManager taskManager = new TaskManager();

        public Form1()
        {
            InitializeComponent();
            LoadTasks();
        }

        private void LoadTasks()
        {
            try
            {
                dataGridView.DataSource = null;
                dataGridView.DataSource = taskManager.GetAllTasks();

                if (dataGridView.Columns["TaskId"] != null)
                    dataGridView.Columns["TaskId"]!.HeaderText = "ID";
                if (dataGridView.Columns["TaskName"] != null)
                    dataGridView.Columns["TaskName"]!.HeaderText = "Task Name";
                if (dataGridView.Columns["Unit"] != null)
                    dataGridView.Columns["Unit"]!.HeaderText = "Unit";
                if (dataGridView.Columns["Description"] != null)
                    dataGridView.Columns["Description"]!.HeaderText = "Description";
                if (dataGridView.Columns["DueDate"] != null)
                    dataGridView.Columns["DueDate"]!.HeaderText = "Due Date";
                if (dataGridView.Columns["Priority"] != null)
                    dataGridView.Columns["Priority"]!.HeaderText = "Priority";
                if (dataGridView.Columns["Status"] != null)
                    dataGridView.Columns["Status"]!.HeaderText = "Status";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tasks: " + ex.Message);
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Add Task form coming tomorrow!");
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Select a task first.");
                return;
            }

            try
            {
                TaskItem? selectedTask = dataGridView.CurrentRow.DataBoundItem as TaskItem;
                if (selectedTask == null) return;

                taskManager.DeleteTask(selectedTask.TaskId);
                LoadTasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting task: " + ex.Message);
            }
        }

        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            LoadTasks();
        }
    }
}