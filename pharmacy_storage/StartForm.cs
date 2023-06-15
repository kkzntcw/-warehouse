using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmacy_storage
{
    public partial class StartForm : Form
    {
        DataBase dataBase;
        public StartForm()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            InfoForm infoForm = new InfoForm();
            infoForm.ShowDialog();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }
    }
}
