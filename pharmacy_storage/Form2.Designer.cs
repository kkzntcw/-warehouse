namespace pharmacy_storage
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBoxID = new TextBox();
            textBoxName = new TextBox();
            textBoxSurname = new TextBox();
            textBoxLastName = new TextBox();
            textBoxJobPosition = new TextBox();
            dgvWorkers = new DataGridView();
            btnSave = new Button();
            btnDelete = new Button();
            btnReset = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvWorkers).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 82);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 0;
            label1.Text = "ID работника ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 138);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(39, 20);
            label2.TabIndex = 1;
            label2.Text = "Имя";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 196);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 2;
            label3.Text = "Фамилия";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 251);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 3;
            label4.Text = "Отчество";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 305);
            label5.Name = "label5";
            label5.Size = new Size(86, 20);
            label5.TabIndex = 4;
            label5.Text = "Должность";
            // 
            // textBoxID
            // 
            textBoxID.Location = new Point(127, 79);
            textBoxID.Name = "textBoxID";
            textBoxID.Size = new Size(110, 27);
            textBoxID.TabIndex = 5;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(127, 139);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(134, 27);
            textBoxName.TabIndex = 6;
            // 
            // textBoxSurname
            // 
            textBoxSurname.Location = new Point(127, 200);
            textBoxSurname.Name = "textBoxSurname";
            textBoxSurname.Size = new Size(150, 27);
            textBoxSurname.TabIndex = 7;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(127, 255);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(171, 27);
            textBoxLastName.TabIndex = 8;
            // 
            // textBoxJobPosition
            // 
            textBoxJobPosition.Location = new Point(127, 306);
            textBoxJobPosition.Name = "textBoxJobPosition";
            textBoxJobPosition.Size = new Size(171, 27);
            textBoxJobPosition.TabIndex = 9;
            // 
            // dgvWorkers
            // 
            dgvWorkers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWorkers.Location = new Point(304, 39);
            dgvWorkers.Name = "dgvWorkers";
            dgvWorkers.RowHeadersWidth = 51;
            dgvWorkers.RowTemplate.Height = 29;
            dgvWorkers.Size = new Size(484, 294);
            dgvWorkers.TabIndex = 10;
            dgvWorkers.CellContentClick += dgvWorkers_CellContentClick;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(467, 393);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 11;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(567, 393);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(667, 393);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 13;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReset);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(dgvWorkers);
            Controls.Add(textBoxJobPosition);
            Controls.Add(textBoxLastName);
            Controls.Add(textBoxSurname);
            Controls.Add(textBoxName);
            Controls.Add(textBoxID);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Добавление нового сотрудника";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dgvWorkers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBoxID;
        private TextBox textBoxName;
        private TextBox textBoxSurname;
        private TextBox textBoxLastName;
        private TextBox textBoxJobPosition;
        private DataGridView dgvWorkers;
        private Button btnSave;
        private Button btnDelete;
        private Button btnReset;
    }
}