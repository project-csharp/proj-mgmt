using ManagAndTrackProjectsAndTeams.control;
using ManagAndTrackProjectsAndTeams.model;
using ManagAndTrackProjectsAndTeams.src.model;
using System;
using System.Windows.Forms;

namespace ManagAndTrackProjectsAndTeams.src.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("الرجاء إدخال اسم المستخدم وكلمة المرور");
                return;
            }

            UserModelLogin model = new UserModelLogin();
            User user = model.AuthenticateUser(txtUsername.Text, txtPassword.Text);


            if (user != null)
            {
                // تخزين معلومات الجلسة
                Session.UserId = user.Id;
                Session.Username = user.Username;


                // فتح الواجهة الرئيسية MainForm
                mainForm mainForm1 = new mainForm();
                mainForm1.Show();
               

                this.Hide(); // لإخفاء الفورم الحالي (LoginForm)
            }
            else
            {
                MessageBox.Show("اسم المستخدم أو كلمة المرور غير صحيحة");
            }
            // كود التحقق من صحة البيانات هنا
        }

        private void linkToRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new RegisterForm().Show();
            this.Hide();
        }

        private void LinkToRegister_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new RegisterForm().Show();
            this.Hide();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
