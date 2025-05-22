using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagAndTrackProjectsAndTeams.src.Views
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void PnlSideBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void Guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Guna2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void PbxProfile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry! this form coming soon");
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already in home page!");
        }

        private void BtnTeams_Click(object sender, EventArgs e)
        {
            TeamFoem teamfoem = new TeamFoem();
            teamfoem.Show();
            

                this.Hide(); // لإخفاء الفورم الحالي (LoginForm)
        }

        private void BtnProjects_Click(object sender, EventArgs e)
        {
           
            MessageBox.Show("You are already in home page!");
        }

        private void BtnStatistics_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry! this form coming soon");
        }

        private void BtnTasks_Click(object sender, EventArgs e)
        {
                   ProjectForm main = new ProjectForm();
        main.Visible = true;
            this.Hide();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry! this form coming soon");
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnViewTeamMem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry! this form coming soon");
        }

        private void BtnNewTask_Click(object sender, EventArgs e)
        {

            TaskForm teamfoem = new TaskForm();
            teamfoem.Show();
            this.Hide(); // لإخفاء الفورم الحالي (LoginForm)
        }

        private void BtnViewReports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry! this form coming soon");
        }

        private void DgTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
