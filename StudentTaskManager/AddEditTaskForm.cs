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
            // Unit is required (the task name is checked inside TaskItem)
            if (string.IsNullOrWhiteSpace(txtUnit.Text))
            {
                MessageBox.Show("Unit is required.", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            catch (ArgumentException ex)
            {
                // Bad input: empty name or past date
                MessageBox.Show(ex.Message, "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Anything else, such as a database problem
                MessageBox.Show("Error saving task: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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