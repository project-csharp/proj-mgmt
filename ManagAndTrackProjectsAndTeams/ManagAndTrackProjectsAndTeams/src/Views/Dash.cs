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
    public partial class Dash : Form
    {
        public Dash()
        {
            InitializeComponent();
            LoadProjectPieChart();

        }
        DashboardModel model = new DashboardModel();


        private void Dash_Load(object sender, EventArgs e)
        {
  LoadProjectPieChart();
        }


        private void DashboardForm_Load(object sender, EventArgs e)
        {
          
        }

        private void LoadProjectPieChart()
        {
            DataTable dt = model.GetProjectTasks();

            chart1.Series[0].Points.Clear();

            foreach (DataRow row in dt.Rows)
            {
                string projectName = row["project_name"].ToString();
                int taskCount = Convert.ToInt32(row["task_count"]);

                chart1.Series[0].Points.AddXY(projectName, taskCount);
            }

            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
        }

        private void Chart1_Click(object sender, EventArgs e)
        {

        }

        private void Guna2Button5_Click(object sender, EventArgs e)
        {
            // فتح الواجهة الرئيسية MainForm
            mainForm mainForm1 = new mainForm();
            mainForm1.Show();


            this.Hide(); // لإخفاء الفورم الحالي (LoginForm)
        }
    }
}
