﻿using ManagAndTrackProjectsAndTeams.control;
using System;
using System.Windows.Forms;

namespace ManagAndTrackProjectsAndTeams.src.Views
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            UserController controller = new UserController();
            bool success = controller.RegisterUser(txtFullName.Text, txtPassword.Text, txtEmail.Text);

            if (success)
            {
                MessageBox.Show("تم التسجيل بنجاح!");
                this.Close();
            }
            else
            {
                MessageBox.Show("حدث خطأ أثناء التسجيل.");
            }

        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                MessageBox.Show("الرجاء إدخال الاسم الكامل");
                return false;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("البريد الإلكتروني غير صالح");
                return false;
            }

            if (txtPassword.Text != txtConfirm.Text)
            {
                MessageBox.Show("كلمة المرور غير متطابقة");
                return false;
            }

            if (!chkTerms.Checked)
            {
                MessageBox.Show("يجب الموافقة على الشروط");
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch { return false; }
        }

        private void linkToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new LoginForm().Show();
            this.Close();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
