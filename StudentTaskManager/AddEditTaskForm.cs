using System;
using System.Windows.Forms;
using StudentTaskManager.Models;

namespace StudentTaskManager
{
    public partial class AddEditTaskForm : Form
    {
        public bool TaskSaved { get; private set; } = false;

        public AddEditTaskForm()
        {
            InitializeComponent();
            cmbPriority.Items.AddRange(new object[] { Priority.Low, Priority.Medium, Priority.High });
            cmbPriority.SelectedIndex = 0;
            dtpDueDate.MinDate = DateTime.Today;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaskName.Text))
            {
                MessageBox.Show("Task name is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUnit.Text))
            {
                MessageBox.Show("Unit is required.");
                return;
            }

            try
            {
                TaskItem task = new TaskItem(
                    txtTaskName.Text.Trim(),
                    txtUnit.Text.Trim(),
                    txtDescription.Text.Trim(),
                    dtpDueDate.Value,
                    (Priority)cmbPriority.SelectedItem!
                );

                TaskManager taskManager = new TaskManager();
                taskManager.AddTask(task);

                TaskSaved = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving task: " + ex.Message);
            }
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTaskName_TextChanged(object sender, EventArgs e)
        {

        }
    }
} 