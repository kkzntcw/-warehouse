namespace pharmacy_storage
{
    partial class StartForm
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
            startBtn = new Button();
            infoBtn = new Button();
            quitBtn = new Button();
            SuspendLayout();
            // 
            // startBtn
            // 
            startBtn.Location = new Point(109, 63);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(200, 30);
            startBtn.TabIndex = 0;
            startBtn.Text = "Начать работу ";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += startBtn_Click;
            // 
            // infoBtn
            // 
            infoBtn.Location = new Point(103, 108);
            infoBtn.Name = "infoBtn";
            infoBtn.Size = new Size(100, 30);
            infoBtn.TabIndex = 1;
            infoBtn.Text = "Справка";
            infoBtn.UseVisualStyleBackColor = true;
            infoBtn.Click += infoBtn_Click;
            // 
            // quitBtn
            // 
            quitBtn.Location = new Point(209, 108);
            quitBtn.Name = "quitBtn";
            quitBtn.Size = new Size(100, 30);
            quitBtn.TabIndex = 2;
            quitBtn.Text = "Выход";
            quitBtn.UseVisualStyleBackColor = true;
            quitBtn.Click += quitBtn_Click;
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 194);
            Controls.Add(quitBtn);
            Controls.Add(infoBtn);
            Controls.Add(startBtn);
            Name = "StartForm";
            Text = "Аптечный склад \"Еклиник\"";
            Load += StartForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button startBtn;
        private Button infoBtn;
        private Button quitBtn;
    }
}