namespace StudentTaskManager
{
    partial class AddEditTaskForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTaskName = new Label();
            txtTaskName = new TextBox();
            lblUnit = new Label();
            txtUnit = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblDueDate = new Label();
            dtpDueDate = new DateTimePicker();
            lblPriority = new Label();
            cmbPriority = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTaskName
            // 
            lblTaskName.AutoSize = true;
            lblTaskName.Location = new Point(15, 20);
            lblTaskName.Name = "lblTaskName";
            lblTaskName.Size = new Size(101, 25);
            lblTaskName.TabIndex = 0;
            lblTaskName.Text = "Task Name:";
            // 
            // txtTaskName
            // 
            txtTaskName.Location = new Point(120, 17);
            txtTaskName.Name = "txtTaskName";
            txtTaskName.Size = new Size(250, 31);
            txtTaskName.TabIndex = 1;
            txtTaskName.TextChanged += txtTaskName_TextChanged;
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Location = new Point(15, 55);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(48, 25);
            lblUnit.TabIndex = 2;
            lblUnit.Text = "Unit:";
            // 
            // txtUnit
            // 
            txtUnit.Location = new Point(120, 52);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(250, 31);
            txtUnit.TabIndex = 3;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(15, 90);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(106, 25);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(120, 91);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(250, 60);
            txtDescription.TabIndex = 5;
            // 
            // lblDueDate
            // 
            lblDueDate.AutoSize = true;
            lblDueDate.Location = new Point(15, 160);
            lblDueDate.Name = "lblDueDate";
            lblDueDate.Size = new Size(90, 25);
            lblDueDate.TabIndex = 6;
            lblDueDate.Text = "Due Date:";
            // 
            // dtpDueDate
            // 
            dtpDueDate.Format = DateTimePickerFormat.Short;
            dtpDueDate.Location = new Point(120, 157);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(250, 31);
            dtpDueDate.TabIndex = 7;
            // 
            // lblPriority
            // 
            lblPriority.AutoSize = true;
            lblPriority.Location = new Point(15, 195);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new Size(72, 25);
            lblPriority.TabIndex = 8;
            lblPriority.Text = "Priority:";
            // 
            // cmbPriority
            // 
            cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPriority.Location = new Point(120, 192);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(250, 33);
            cmbPriority.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(120, 235);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(230, 235);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 30);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.Click += BtnCancel_Click;
            // 
            // AddEditTaskForm
            // 
            ClientSize = new Size(433, 290);
            Controls.Add(lblTaskName);
            Controls.Add(txtTaskName);
            Controls.Add(lblUnit);
            Controls.Add(txtUnit);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(lblDueDate);
            Controls.Add(dtpDueDate);
            Controls.Add(lblPriority);
            Controls.Add(cmbPriority);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddEditTaskForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add / Edit Task";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTaskName;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
} 