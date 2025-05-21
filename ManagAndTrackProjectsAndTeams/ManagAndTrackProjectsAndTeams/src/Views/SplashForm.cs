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
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        private async void SplashForm_Load(object sender, EventArgs e)
        {
            // تأثير ظهور تدريجي
            for (double opacity = 0; opacity <= 1; opacity += 0.1)
            {
                this.Opacity = opacity;
                await Task.Delay(50);
            }
        }

        private async Task LoadResources()
        {
            await Task.Run(() => {
                // كود تحميل البيانات أو الاتصال بالسيرفر
            });
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (guna2ProgressBar1.Value < 100)
            {
                guna2ProgressBar1.Value += 2;
            }
            else
            {
                timer.Stop();
                this.Hide();
                new LoginForm().Show();
            }
        }
    }
}
