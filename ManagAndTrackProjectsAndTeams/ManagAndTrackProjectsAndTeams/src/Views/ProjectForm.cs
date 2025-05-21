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
    public partial class ProjectForm : Form
    {
        public ProjectForm()
        {
            InitializeComponent();
        }

        private void Guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("New Project Created Successfully");
        }

        private void BtnNewProject_Click(object sender, EventArgs e)
        {
            tabProjects.SelectedTab = tabPage2;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Will build soon");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Will build soon");
        }
    }
}
