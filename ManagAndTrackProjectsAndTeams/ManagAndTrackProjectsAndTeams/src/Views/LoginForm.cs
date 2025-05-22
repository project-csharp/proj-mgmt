using ManagAndTrackProjectsAndTeams.control;
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

            UserControllerLogin userController = new UserControllerLogin();
            bool isAuthenticated = userController.Login(txtUsername.Text, txtPassword.Text);

            if (isAuthenticated)
            {
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
