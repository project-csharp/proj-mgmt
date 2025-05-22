using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagAndTrackProjectsAndTeams.src.Views
{
    public partial class ProfileForm : Form
    {
        // private bool isEditMode = false;
        private bool isSidebarVisible = false;
        private bool isDarkMode = false;
        private string selectedImagePath = "";
        // private readonly Guna2ToolTip toolTip = new Guna2ToolTip();
        private readonly Guna2Transition transition = new Guna2Transition();

        private readonly UserProfile currentUser = new UserProfile
        {
            Username = "muayad",
            Email = "Mayad@email.com",
            JoinDate = new DateTime(2025, 1, 1),
            Role = "Admin",
            AvatarPath = "default_avatar.png",
            Language = "English",
            EmailNotifications = true
        };

        private Guna2Panel mainPanel, sidebarPanel;
        private Guna2Button btnHamburger, btnBack, btnLogout, btnEdit, btnUpload, btnRemove, btnSave, btnCancel;
        private Guna2ToggleSwitch toggleDarkMode, toggleNotifications;
        private Guna2PictureBox viewAvatar, editAvatar;
        private Guna2HtmlLabel lblUsername, lblEmail, lblJoinDate, lblRole, lblStats, lblUsernameError, lblEmailError, lblPasswordError;
        private Guna2TextBox txtUsername, txtEmail, txtCurrentPassword, txtNewPassword, txtConfirmPassword;
        private Guna2ComboBox cmbLanguage;
        private Guna2Separator separator;
        private TableLayoutPanel mainLayout;

        public ProfileForm()
        {
            // InitializeComponent();
            SetupForm();
            LoadUserDataAsync().GetAwaiter().GetResult();
            this.Resize += ProfileForm_Resize;
        }

        private void SetupForm()
        {
            this.Text = "Profile";
            this.DoubleBuffered = true;
            this.MinimumSize = new Size(620, 590);
         
            this.VScroll = true;
            //this.BackColor = Color.FromArgb(245, 247, 250);
            this.BackColor = Color.Brown;
            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Font = new Font("Segoe UI", 9.75F);
           

            SetupHeader();
            SetupSidebar();
            SetupMainPanel();
            SetupFooter();
            ApplyTheme();
        }

        private void SetupHeader()
        {
            btnHamburger = new Guna2Button
            {
                Text = "☰",
                Size = new Size(40, 40),
                Location = new Point(10, 10),
                Font = new Font("Segoe UI", 12F),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(52, 73, 94),
                BorderRadius = 5,
                Animated = true

            };
            btnHamburger.Click += (s, e) => ToggleSidebar();
            this.Controls.Add(btnHamburger);

            toggleDarkMode = new Guna2ToggleSwitch
            {
                Size = new Size(40, 20),
                Location = new Point(100, 15),
                BackColor = Color.MediumVioletRed,
                Animated = true,
                CheckedState = { FillColor = Color.FromArgb(46, 204, 113) },
                UncheckedState = { FillColor = Color.FromArgb(127, 140, 141) }
            };
            toggleDarkMode.CheckedChanged += (s, e) => { isDarkMode = toggleDarkMode.Checked; ApplyTheme(); };
            this.Controls.Add(toggleDarkMode);

            btnLogout = new Guna2Button
            {
                Text = "Logout",
                Size = new Size(100, 30),
                Location = new Point(580, 15),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(231, 76, 60),
                BorderRadius = 5,
                Animated = true
            };
            btnLogout.Click += (s, e) =>
            {
                //   if (Guna2MessageDialog.Show("Are you sure you want to logout?", "Logout", MessageDialogButtons.YesNo, MessageDialogIcon.Question) == DialogResult.Yes)
                this.Close();
            };
            this.Controls.Add(btnLogout);

            btnBack = new Guna2Button
            {
                Text = "Back",
                Size = new Size(80, 30),
                Location = new Point(330, 15),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(52, 73, 94),
                BorderRadius = 5,
                Animated = true
            };
            btnBack.Click += (s, e) => this.Close();
            this.Controls.Add(btnBack);
        }

        private void SetupSidebar()
        {
            sidebarPanel = new Guna2Panel
            {
                Size = new Size(200, this.ClientSize.Height - 60),
                Location = new Point(-200, 60),
                BorderRadius = 0,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(189, 195, 199),
                FillColor = Color.White,
                ShadowDecoration = { Color = Color.FromArgb(149, 165, 166), Depth = 20, Enabled = true },
                // Transition = transition
                // BackColor = Color.Green,

            };

            var lblSidebarTitle = new Guna2HtmlLabel
            {
                Text = "<b>Menu</b>",
                Location = new Point(20, 20),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                AutoSize = true,
                //BackColor = Color.Salmon,
            };
            sidebarPanel.Controls.Add(lblSidebarTitle);

            var btnTeams = new Guna2Button
            {
                Text = "Teams",
                Size = new Size(160, 40),
                Location = new Point(20, 60),
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(44, 62, 80),
                FillColor = Color.Transparent,
                BorderRadius = 5,
                TextAlign = HorizontalAlignment.Left,
                //  Image = Properties.Resources.team_icon,
                ImageAlign = HorizontalAlignment.Left,
                Animated = true
            };
            sidebarPanel.Controls.Add(btnTeams);

            var btnProjects = new Guna2Button
            {
                Text = "Projects",
                Size = new Size(160, 40),
                Location = new Point(20, 110),
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(44, 62, 80),
                FillColor = Color.Transparent,
                BorderRadius = 5,
                TextAlign = HorizontalAlignment.Left,
                //  Image = Properties.Resources.project_icon,
                ImageAlign = HorizontalAlignment.Left,
                Animated = true
            };
            sidebarPanel.Controls.Add(btnProjects);

            this.Controls.Add(sidebarPanel);
        }

        private void SetupMainPanel()
        {
            mainPanel = new Guna2Panel
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                Location = new Point(50, 60),
                Size = new Size(this.ClientSize.Width - 100, this.ClientSize.Height - 120),
                BorderRadius = 10,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(189, 195, 199),
                FillColor = Color.White,
                ShadowDecoration = { Color = Color.FromArgb(149, 165, 166), Depth = 20, Enabled = true },
                Padding = new Padding(15),
                AutoScroll = true
            };
            this.Controls.Add(mainPanel);

            mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 10,
                AutoSize = true,
                Padding = new Padding(10),


            };
            mainPanel.Controls.Add(mainLayout);

            SetupViewModeComponents();
            SetupEditModeComponents();
        }

        private void SetupViewModeComponents()
        {
            mainLayout.Controls.Add(viewAvatar = new Guna2PictureBox
            {
                Size = new Size(120, 120),
                Anchor = AnchorStyles.None,
                BorderRadius = 60,
                SizeMode = PictureBoxSizeMode.Zoom,
                //   ErrorImage = Properties.Resources.default_avatar,
                ShadowDecoration = { Enabled = true, Color = Color.FromArgb(149, 165, 166), Depth = 10 }
            }, 0, 0);
            mainLayout.SetColumnSpan(viewAvatar, 2);

            mainLayout.Controls.Add(lblUsername = new Guna2HtmlLabel
            {
                Text = "Username: ",
                Anchor = AnchorStyles.Left,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                AutoSize = true
            }, 0, 1);

            mainLayout.Controls.Add(lblEmail = new Guna2HtmlLabel
            {
                Text = "Email: ",
                Anchor = AnchorStyles.Left,
                Font = new Font("Segoe UI", 16F),
                ForeColor = Color.FromArgb(52, 73, 94),
                AutoSize = true
            }, 0, 2);

            mainLayout.Controls.Add(lblJoinDate = new Guna2HtmlLabel
            {
                Text = "Join Date: ",
                Anchor = AnchorStyles.Left,
                Font = new Font("Segoe UI", 16F),
                ForeColor = Color.FromArgb(52, 73, 94),
                AutoSize = true
            }, 0, 3);

            mainLayout.Controls.Add(lblRole = new Guna2HtmlLabel
            {
                Text = "Role: ",
                Anchor = AnchorStyles.Left,
                Font = new Font("Segoe UI", 16F),
                ForeColor = Color.FromArgb(52, 73, 94),
                AutoSize = true
            }, 0, 4);

            mainLayout.Controls.Add(lblStats = new Guna2HtmlLabel
            {
                Text = "Completed Tasks: 15 | Teams: 3",
                Anchor = AnchorStyles.Left,
                Font = new Font("Segoe UI", 16F),
                ForeColor = Color.FromArgb(52, 73, 94),
                AutoSize = true
            }, 0, 5);

            mainLayout.Controls.Add(btnEdit = new Guna2Button
            {
                Text = "Edit Profile",
                Size = new Size(150, 40),
                Anchor = AnchorStyles.None,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(52, 152, 219),
                BorderRadius = 5,
                Animated = true
            }, 0, 6);
            mainLayout.SetColumnSpan(btnEdit, 2);
            btnEdit.Click += (s, e) => SwitchToEditMode();
        }

        private void SetupEditModeComponents()
        {
            mainLayout.Controls.Add(editAvatar = new Guna2PictureBox
            {
                Size = new Size(120, 120),
                Anchor = AnchorStyles.None,
                BorderRadius = 60,
                SizeMode = PictureBoxSizeMode.Zoom,
                //  ErrorImage = Properties.Resources.default_avatar,
                ShadowDecoration = { Enabled = true, Color = Color.FromArgb(149, 165, 166), Depth = 10 },
                Visible = false
            }, 0, 0);
            mainLayout.SetColumnSpan(editAvatar, 2);

            mainLayout.Controls.Add(btnUpload = new Guna2Button
            {
                Text = "Upload Image 🖼️",
                Size = new Size(120, 30),
                Anchor = AnchorStyles.None,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(52, 152, 219),
                BorderRadius = 5,
                Animated = true,
                Visible = false
            }, 0, 1);
            btnUpload.Click += BtnUpload_Click;

            mainLayout.Controls.Add(btnRemove = new Guna2Button
            {
                Text = "Remove Image 🗑️",
                TextAlign = HorizontalAlignment.Center,
                Size = new Size(120, 30),
                Anchor = AnchorStyles.None,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(127, 140, 141),
                BorderRadius = 5,
                Animated = true,
                Visible = false
            }, 1, 1);
            //     btnRemove.Click += (s, e) => { editAvatar.Image = Properties.Resources.default_avatar; selectedImagePath = ""; };

            mainLayout.Controls.Add(new Guna2HtmlLabel { Text = "Username:", Anchor = AnchorStyles.Left, Font = new Font("Segoe UI", 10F), ForeColor = Color.FromArgb(52, 73, 94), AutoSize = true }, 0, 2);
            mainLayout.Controls.Add(txtUsername = new Guna2TextBox
            {
                PlaceholderText = "Enter username",
                Anchor = AnchorStyles.Left,
                Font = new Font("Segoe UI", 10F),
                BorderRadius = 5,
                BorderColor = Color.FromArgb(189, 195, 199),
                // FocusedColor = Color.FromArgb(52, 152, 219),
                Cursor = Cursors.IBeam,
                Visible = false
            }, 1, 2);
            txtUsername.TextChanged += (s, e) => ValidateUsername();
            //  toolTip.SetToolTip(txtUsername, "3-20 characters, letters and numbers only");

            mainLayout.Controls.Add(lblUsernameError = new Guna2HtmlLabel
            {
                Text = "",
                Anchor = AnchorStyles.Left,
                ForeColor = Color.FromArgb(231, 76, 60),
                Font = new Font("Segoe UI", 9F),
                AutoSize = true,
                Visible = false
            }, 1, 3);

            mainLayout.Controls.Add(new Guna2HtmlLabel { Text = "Email:", Anchor = AnchorStyles.Left, Font = new Font("Segoe UI", 10F), ForeColor = Color.FromArgb(52, 73, 94), AutoSize = true }, 0, 4);
            mainLayout.Controls.Add(txtEmail = new Guna2TextBox
            {
                PlaceholderText = "Enter email 📧",
                Anchor = AnchorStyles.Left,
                Font = new Font("Segoe UI", 10F),
                BorderRadius = 5,
                BorderColor = Color.FromArgb(189, 195, 199),
                //    FocusedColor = Color.FromArgb(52, 152, 219),
                Cursor = Cursors.IBeam,
                Visible = false
            }, 1, 4);
            txtEmail.TextChanged += (s, e) => ValidateEmail();
            //   toolTip.SetToolTip(txtEmail, "Enter a valid email address");

            mainLayout.Controls.Add(lblEmailError = new Guna2HtmlLabel
            {
                Text = "",
                Anchor = AnchorStyles.Left,
                ForeColor = Color.FromArgb(231, 76, 60),
                Font = new Font("Segoe UI", 9F),
                AutoSize = true,
                Visible = false
            }, 1, 5);

            mainLayout.Controls.Add(separator = new Guna2Separator
            {
                Size = new Size(500, 10),
                Anchor = AnchorStyles.Left,
                FillColor = Color.FromArgb(189, 195, 199),
                Visible = false
            }, 0, 6);
            mainLayout.SetColumnSpan(separator, 2);

            mainLayout.Controls.Add(new Guna2HtmlLabel { Text = "Current Password:", Anchor = AnchorStyles.Left, Font = new Font("Segoe UI", 10F), ForeColor = Color.FromArgb(52, 73, 94), AutoSize = true }, 0, 7);
            mainLayout.Controls.Add(txtCurrentPassword = new Guna2TextBox
            {
                PlaceholderText = "Current Password 🔒",
                Anchor = AnchorStyles.Left,
                Font = new Font("Segoe UI", 10F),
                BorderRadius = 5,
                BorderColor = Color.FromArgb(189, 195, 199),
                //   FocusedColor = Color.FromArgb(52, 152, 219),
                PasswordChar = '●',
                UseSystemPasswordChar = true,
                Visible = false
            }, 1, 7);

            mainLayout.Controls.Add(new Guna2HtmlLabel { Text = "New Password:", Anchor = AnchorStyles.Left, Font = new Font("Segoe UI", 10F), ForeColor = Color.FromArgb(52, 73, 94), AutoSize = true }, 0, 8);
            mainLayout.Controls.Add(txtNewPassword = new Guna2TextBox
            {
                PlaceholderText = "New Password 🔒",
                Anchor = AnchorStyles.Left,
                Font = new Font("Segoe UI", 10F),
                BorderRadius = 5,
                BorderColor = Color.FromArgb(189, 195, 199),
                //   FocusedColor = Color.FromArgb(52, 152, 219),
                PasswordChar = '●',
                UseSystemPasswordChar = true,
                Visible = false
            }, 1, 8);
            //  toolTip.SetToolTip(txtNewPassword, "6-20 characters, must contain letters and numbers");

            mainLayout.Controls.Add(new Guna2HtmlLabel { Text = "Confirm Password:", Anchor = AnchorStyles.Left, Font = new Font("Segoe UI", 10F), ForeColor = Color.FromArgb(52, 73, 94), AutoSize = true }, 0, 9);
            mainLayout.Controls.Add(txtConfirmPassword = new Guna2TextBox
            {
                PlaceholderText = "Confirm Password 🔒",
                Anchor = AnchorStyles.Left,
                Font = new Font("Segoe UI", 10F),
                BorderRadius = 5,
                BorderColor = Color.FromArgb(189, 195, 199),
                // FocusedColor = Color.FromArgb(52, 152, 219),
                PasswordChar = '●',
                UseSystemPasswordChar = true,
                Visible = false
            }, 1, 9);

            mainLayout.Controls.Add(lblPasswordError = new Guna2HtmlLabel
            {
                Text = "",
                Anchor = AnchorStyles.Left,
                ForeColor = Color.FromArgb(231, 76, 60),
                Font = new Font("Segoe UI", 9F),
                AutoSize = true,
                Visible = false
            }, 1, 10);

            mainLayout.Controls.Add(cmbLanguage = new Guna2ComboBox
            {
                DataSource = new[] { "English", "Arabic" },
                Anchor = AnchorStyles.Left,
                Font = new Font("Segoe UI", 9F),
                BorderRadius = 5,
                FillColor = Color.White,
                ForeColor = Color.FromArgb(44, 62, 80),
                BorderColor = Color.FromArgb(189, 195, 199),
                //SelectedIndex = 0,

                Visible = false
            }, 0, 11);
            if (cmbLanguage.Items.Count > 0)
                cmbLanguage.SelectedIndex = 0;

            mainLayout.SetColumnSpan(cmbLanguage, 2);

            mainLayout.Controls.Add(toggleNotifications = new Guna2ToggleSwitch
            {
                Checked = true,
                Anchor = AnchorStyles.Left,
                Animated = true,
                CheckedState = { FillColor = Color.FromArgb(46, 204, 113) },
                UncheckedState = { FillColor = Color.FromArgb(127, 140, 141) },
                Visible = false
            }, 0, 12);

            mainLayout.Controls.Add(new Guna2HtmlLabel
            {
                Text = "Email Notifications:",
                Anchor = AnchorStyles.Left,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(52, 73, 94),
                AutoSize = true,
                Visible = false
            }, 1, 12);
        }

        private void SetupFooter()
        {
            btnSave = new Guna2Button
            {
                Text = "Save 💾",
                Size = new Size(120, 40),
                Anchor = AnchorStyles.Bottom,
                Location = new Point((this.ClientSize.Width - 240) / 2, this.ClientSize.Height - 50),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(52, 152, 219),
                BorderRadius = 5,
                Animated = true,
                Visible = true
            };
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            btnCancel = new Guna2Button
            {
                Text = "Cancel ❌",
                Size = new Size(120, 40),
                Anchor = AnchorStyles.Bottom,
                Location = new Point((this.ClientSize.Width + 120) / 2, this.ClientSize.Height - 50),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(127, 140, 141),
                BorderRadius = 5,
                Animated = true,
                Visible = false
            };
            btnCancel.Click += (s, e) => SwitchToViewMode();
            this.Controls.Add(btnCancel);
        }

        private async Task LoadUserDataAsync()
        {
            lblUsername.Text = $"Username: {currentUser.Username}";
            lblEmail.Text = $"Email: {currentUser.Email} 📧";
            lblJoinDate.Text = $"Join Date: {currentUser.JoinDate:yyyy-MM-dd}";
            lblRole.Text = $"Role: {currentUser.Role} 👑";

            try
            {
                if (File.Exists(currentUser.AvatarPath))
                {
                    using (var stream = new FileStream(currentUser.AvatarPath, FileMode.Open, FileAccess.Read))
                    {
                        var img = await Task.Run(() => Image.FromStream(stream));
                        viewAvatar.Image = new Bitmap(img);
                        editAvatar.Image = new Bitmap(img);
                    }
                }
                else
                {
                    //  viewAvatar.Image = Properties.Resources.default_avatar;
                    //  editAvatar.Image = Properties.Resources.default_avatar;
                }
            }
            catch
            {
                //  viewAvatar.Image = Properties.Resources.default_avatar;
                //  editAvatar.Image = Properties.Resources.default_avatar;
            }

            txtUsername.Text = currentUser.Username;
            txtEmail.Text = currentUser.Email;
            cmbLanguage.SelectedItem = currentUser.Language;
            toggleNotifications.Checked = currentUser.EmailNotifications;
        }

        private void SwitchToViewMode()
        {
            mainPanel.SuspendLayout();
            bool isEditMode = false;
            viewAvatar.Visible = true;
            lblUsername.Visible = true;
            lblEmail.Visible = true;
            lblJoinDate.Visible = true;
            lblRole.Visible = currentUser.Role == "Admin";
            lblStats.Visible = true;
            btnEdit.Visible = true;

            editAvatar.Visible = false;
            btnUpload.Visible = false;
            btnRemove.Visible = false;
            txtUsername.Visible = false;
            txtEmail.Visible = false;
            separator.Visible = false;
            txtCurrentPassword.Visible = false;
            txtNewPassword.Visible = false;
            txtConfirmPassword.Visible = false;
            cmbLanguage.Visible = false;
            toggleNotifications.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            lblUsernameError.Visible = false;
            lblEmailError.Visible = false;
            lblPasswordError.Visible = false;

            mainPanel.ResumeLayout();
            LoadUserDataAsync().GetAwaiter().GetResult();
        }

        private void SwitchToEditMode()
        {
            mainPanel.SuspendLayout();
            bool isEditMode = true;
            viewAvatar.Visible = false;
            lblUsername.Visible = false;
            lblEmail.Visible = false;
            lblJoinDate.Visible = false;
            lblRole.Visible = false;
            lblStats.Visible = false;
            btnEdit.Visible = false;

            editAvatar.Visible = true;
            btnUpload.Visible = true;
            btnRemove.Visible = true;
            txtUsername.Visible = true;
            txtEmail.Visible = true;
            separator.Visible = true;
            txtCurrentPassword.Visible = true;
            txtNewPassword.Visible = true;
            txtConfirmPassword.Visible = true;
            cmbLanguage.Visible = true;
            toggleNotifications.Visible = true;
            btnSave.Visible = true;
            btnCancel.Visible = true;

            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";

            mainPanel.ResumeLayout();
        }

        private void ToggleSidebar()
        {
            isSidebarVisible = !isSidebarVisible;
            if (isSidebarVisible)
            {
                transition.ShowSync(sidebarPanel);
                sidebarPanel.Location = new Point(0, 60);
                mainPanel.Location = new Point(210, 60);
                mainPanel.Width = this.ClientSize.Width - 260;
            }
            else
            {
                transition.HideSync(sidebarPanel);
                sidebarPanel.Location = new Point(-200, 60);
                mainPanel.Location = new Point(50, 60);
                mainPanel.Width = this.ClientSize.Width - 100;
            }
        }

        private void ApplyTheme()
        {
            if (isDarkMode)
            {
                this.BackColor = Color.FromArgb(44, 62, 80);
                mainPanel.FillColor = Color.FromArgb(52, 73, 94);
                sidebarPanel.FillColor = Color.FromArgb(52, 73, 94);
                lblUsername.ForeColor = lblEmail.ForeColor = lblJoinDate.ForeColor = lblRole.ForeColor = lblStats.ForeColor = Color.FromArgb(236, 240, 241);
                txtUsername.ForeColor = txtEmail.ForeColor = txtCurrentPassword.ForeColor = txtNewPassword.ForeColor = txtConfirmPassword.ForeColor = Color.FromArgb(236, 240, 241);
                btnHamburger.FillColor = btnBack.FillColor = Color.FromArgb(52, 73, 94);
                btnLogout.FillColor = Color.FromArgb(231, 76, 60);
                btnEdit.FillColor = btnUpload.FillColor = btnSave.FillColor = Color.FromArgb(52, 152, 219);
                btnRemove.FillColor = btnCancel.FillColor = Color.FromArgb(127, 140, 141);
                lblUsernameError.ForeColor = lblEmailError.ForeColor = lblPasswordError.ForeColor = Color.FromArgb(231, 76, 60);
                //  lblSidebarTitle.ForeColor = Color.FromArgb(236, 240, 241);
                cmbLanguage.ForeColor = Color.FromArgb(236, 240, 241);
                cmbLanguage.FillColor = Color.FromArgb(52, 73, 94);
                separator.FillColor = Color.FromArgb(127, 140, 141);
            }
            else
            {
                this.BackColor = Color.FromArgb(245, 247, 250);
                mainPanel.FillColor = sidebarPanel.FillColor = Color.White;
                lblUsername.ForeColor = Color.FromArgb(44, 62, 80);
                lblEmail.ForeColor = lblJoinDate.ForeColor = lblRole.ForeColor = lblStats.ForeColor = Color.FromArgb(52, 73, 94);
                txtUsername.ForeColor = txtEmail.ForeColor = txtCurrentPassword.ForeColor = txtNewPassword.ForeColor = txtConfirmPassword.ForeColor = Color.Black;
                btnHamburger.FillColor = btnBack.FillColor = Color.FromArgb(52, 73, 94);
                btnLogout.FillColor = Color.FromArgb(231, 76, 60);
                btnEdit.FillColor = btnUpload.FillColor = btnSave.FillColor = Color.FromArgb(52, 152, 219);
                btnRemove.FillColor = btnCancel.FillColor = Color.FromArgb(127, 140, 141);
                lblUsernameError.ForeColor = lblEmailError.ForeColor = lblPasswordError.ForeColor = Color.FromArgb(231, 76, 60);
                //   lblSidebarTitle.ForeColor = Color.FromArgb(44, 62, 80);
                cmbLanguage.ForeColor = Color.FromArgb(44, 62, 80);
                cmbLanguage.FillColor = Color.White;
                separator.FillColor = Color.FromArgb(189, 195, 199);
            }
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Select an Avatar Image";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var fileInfo = new FileInfo(openFileDialog.FileName);
                        if (fileInfo.Length > 2 * 1024 * 1024)
                        {
                            //    Guna2MessageDialog.Show("Image size must not exceed 2 MB", "Error", MessageDialogButtons.OK, MessageDialogIcon.Error, Color.FromArgb(231, 76, 60));
                            return;
                        }
                        selectedImagePath = openFileDialog.FileName;
                        editAvatar.Image?.Dispose();
                        editAvatar.Image = Image.FromFile(selectedImagePath);
                    }
                    catch (Exception)
                    {
                        //  Guna2MessageDialog.Show($"Error loading image: {ex.Message}", "Error", MessageDialogButtons.OK, MessageDialogIcon.Error, Color.FromArgb(231, 76, 60));
                    }
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            currentUser.Username = txtUsername.Text;
            currentUser.Email = txtEmail.Text;
            currentUser.Language = cmbLanguage.SelectedItem.ToString();
            currentUser.EmailNotifications = toggleNotifications.Checked;
            if (!string.IsNullOrEmpty(selectedImagePath))
                currentUser.AvatarPath = selectedImagePath;

            //  Guna2MessageDialog.Show("Changes saved successfully!", "Success", MessageDialogButtons.OK, MessageDialogIcon.Information, Color.FromArgb(46, 204, 113));
            SwitchToViewMode();
        }

        private bool ValidateForm()
        {
            bool isValid = true;
            if (!ValidateUsername())
                isValid = false;
            if (!ValidateEmail())
                isValid = false;
            if (!ValidatePasswords())
                isValid = false;
            return isValid;
        }

        private bool ValidateUsername()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || txtUsername.Text.Length < 3 || txtUsername.Text.Length > 20)
            {
                lblUsernameError.Text = "Username must be between 3 and 20 characters";
                lblUsernameError.Visible = true;
                return false;
            }
            lblUsernameError.Text = "";
            lblUsernameError.Visible = false;
            return true;
        }

        private bool ValidateEmail()
        {
            bool isValid = System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            lblEmailError.Text = isValid ? "" : "Invalid email address";
            lblEmailError.Visible = !isValid;
            return isValid;
        }

        private bool ValidatePasswords()
        {
            if (!string.IsNullOrEmpty(txtNewPassword.Text) || !string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                if (txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    lblPasswordError.Text = "New password and confirmation do not match";
                    lblPasswordError.Visible = true;
                    return false;
                }
                if (txtNewPassword.Text.Length < 6)
                {
                    lblPasswordError.Text = "Password must be at least 6 characters";
                    lblPasswordError.Visible = true;
                    return false;
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtNewPassword.Text, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,20}$"))
                {
                    lblPasswordError.Text = "Password must contain letters and numbers";
                    lblPasswordError.Visible = true;
                    return false;
                }
            }
            lblPasswordError.Text = "";
            lblPasswordError.Visible = false;
            return true;
        }

        private void ProfileForm_Resize(object sender, EventArgs e)
        {
            if (this.ClientSize.Width < 800 && isSidebarVisible)
            {
                ToggleSidebar();
            }
            btnSave.Location = new Point((this.ClientSize.Width - 240) / 2, this.ClientSize.Height - 50);
            btnCancel.Location = new Point((this.ClientSize.Width + 120) / 2, this.ClientSize.Height - 50);
        }
    }

    public class UserProfile
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }
        public string Role { get; set; }
        public string AvatarPath { get; set; }
        public string Language { get; set; }
        public bool EmailNotifications { get; set; }
    }

}
