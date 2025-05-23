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
            label1.Text = Session.Username;//تحديد مستخدم من خلال الجلسة
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
            ProfileForm profile = new ProfileForm();
            profile.Show();
           // MessageBox.Show("Sorry! this form coming soon");

        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already in home page!");
        }

        private void BtnTeams_Click(object sender, EventArgs e)
        {
            TeamFoem teamfoem = new TeamFoem();
            teamfoem.Show();
<<<<<<< HEAD
            

                this.Hide(); // لإخفاء الفورم الحالي (LoginForm)
=======
            this.Hide(); // لإخفاء الفورم الحالي (LoginForm)
>>>>>>> d8d56ec0261da7a804d8ff0871ff0151ab992d57
        }

        private void BtnProjects_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
           
            MessageBox.Show("You are already in home page!");
=======
            ProjectForm main = new ProjectForm();
            main.Visible = true;
            this.Hide();
>>>>>>> d8d56ec0261da7a804d8ff0871ff0151ab992d57
        }

        private void BtnStatistics_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            // فتح الواجهة الرئيسية MainForm
            Dash mainForm1 = new Dash();
          
            mainForm1.Show();


            this.Hide(); // لإخفاء الفورم الحالي (LoginForm)
=======
            MessageBox.Show("You are already in home page!");
>>>>>>> d8d56ec0261da7a804d8ff0871ff0151ab992d57
        }

        private void BtnTasks_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
                   ProjectForm main = new ProjectForm();
        main.Visible = true;
=======
            TaskForm taskForm = new TaskForm();
            taskForm.Show();
>>>>>>> d8d56ec0261da7a804d8ff0871ff0151ab992d57
            this.Hide();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry! this form coming soon");
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            this.Close();
=======
            DialogResult result = MessageBox.Show("Are you sure to exit?", "Confirm exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
>>>>>>> d8d56ec0261da7a804d8ff0871ff0151ab992d57
        }

        private void BtnViewTeamMem_Click(object sender, EventArgs e)
        {
            TeamFoem teamfoem = new TeamFoem();
            teamfoem.Show();
            this.Hide(); // لإخفاء الفورم الحالي (LoginForm)
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
<<<<<<< HEAD

        private void TxbxSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void LblTitle_Click(object sender, EventArgs e)
        {

        }
=======
>>>>>>> d8d56ec0261da7a804d8ff0871ff0151ab992d57
    }
}
