using ManagAndTrackProjectsAndTeams.src.NewFolder1;
using MySql.Data.MySqlClient;
using System;
using ManagAndTrackProjectsAndTeams.src.Models;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagAndTrackProjectsAndTeams.src.control;
using ManagAndTrackProjectsAndTeams.src.Controller;

namespace ManagAndTrackProjectsAndTeams.src.Views
{





    public partial class TeamFoem : Form
    {

        public TeamFoem()
        {
            InitializeComponent();
            LoadTeamMembersToGrid(); 
            LoadUsers();
            LoadTeam();
           
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Guna2Button6_Click(object sender, EventArgs e)
        {
            mainForm mainForm1 = new mainForm();
            mainForm1.Show();


            this.Hide(); // لإخفاء الفورم الحالي (LoginForm)
        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Guna2Button1_Click_1(object sender, EventArgs e)
        {//اضافة اسم للفريق
            string teamName = txtTeamName.Text;

            if (string.IsNullOrEmpty(teamName))
            {
                MessageBox.Show("يرجى إدخال اسم الفريق");
                return;
            }

            conDB db = new conDB(); // إنشاء كائن من conDB

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO teams (name) VALUES (@name)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", teamName);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("تم إضافة الفريق بنجاح");
                    LoadTeam();
                    txtTeamName.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ: " + ex.Message);
                }
            }
        }
        //دالة لتعبية كمبو بوكس للمستخدمين

        private void LoadUsers()
        {
            conDB db = new conDB();

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT id, username FROM users";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    guna2ComboBoxUser.Items.Clear(); // تفريغ العناصر أولًا

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string username = reader["username"].ToString();

                        // إضافة كائن باسم وعنوان
                        guna2ComboBoxUser.Items.Add(new ComboBoxItem(username, id));
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ: " + ex.Message);
                }
            }
        }

        // حميل الفرق
        private void LoadTeam()
        {
            conDB db = new conDB();

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT id, name FROM teams";  // خذ id و name
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    guna2ComboBoxTeam.Items.Clear(); // ننظف العناصر قبل الإضافة

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string name = reader["name"].ToString();

                        // إضافة العنصر مع اسم الفريق و الـ id
                        guna2ComboBoxTeam.Items.Add(new ComboBoxItem(name, id));
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ: " + ex.Message);
                }
            }
        }

        private void ComboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TeamFoem_Load(object sender, EventArgs e)
        {

        }

        private void Guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Guna2Button2_Click(object sender, EventArgs e)
        {

            // إضافة عضو
            TeamMemberController controller = new TeamMemberController();
            if (guna2ComboBoxUser.SelectedItem == null || guna2ComboBoxTeam.SelectedItem == null || string.IsNullOrEmpty(txtRole.Text))
            {
                MessageBox.Show("يرجى اختيار المستخدم والفريق وإدخال الدور");
                return;
            }

            // لازم تتأكد إن النوع صحيح، عشان تستخرج القيمة
            ComboBoxItem selectedUser = guna2ComboBoxUser.SelectedItem as ComboBoxItem;
            ComboBoxItem selectedTeam = guna2ComboBoxTeam.SelectedItem as ComboBoxItem;

            if (selectedUser == null || selectedTeam == null)
            {
                MessageBox.Show("خطأ في اختيار المستخدم أو الفريق");
                return;
            }

            int userId = selectedUser.Value;
            int teamId = selectedTeam.Value;
            string role = txtRole.Text.ToLower();

            if (role != "leader" && role != "member")
            {
                MessageBox.Show("الدور يجب أن يكون leader أو member فقط");
                return;
            }

            if (controller.AddMember(userId, teamId, role))
            {
                MessageBox.Show("تمت إضافة العضو بنجاح");
                LoadTeamMembersToGrid();

                txtRole.Clear();
            }

        }



        /// <summary>
        /// يحمل بيانات أعضاء الفرق ويعرضها في DataGridView
        /// </summary>
        private void LoadTeamMembersToGrid()
        {
            UserTeamController controller = new UserTeamController();
            
            var dt = controller.GetTeamMembers();
<<<<<<< HEAD
            dataGridView1.DataSource = dt;// . ربط البيانات بجدول العرض:

            // تعديل عناوين الأعمدة حسب الحاجة (اختياري)
            dataGridView1.Columns["id"].Visible = false; // إخفاء عمود الـ id  
=======
            dataGridView1.DataSource = dt;
          
            // تعديل عناوين الأعمدة حسب الحاجة (اختياري)
            dataGridView1.Columns["id"].Visible = false; // إخفاء عمود الـ id لو تحب
>>>>>>> d8d56ec0261da7a804d8ff0871ff0151ab992d57
            dataGridView1.Columns["UserName"].HeaderText = "اسم المستخدم";
            dataGridView1.Columns["TeamName"].HeaderText = "اسم الفريق";
            dataGridView1.Columns["role"].HeaderText = "الدور";
            dataGridView1.Columns["joined_at"].HeaderText = "تاريخ الانضمام";
        }







        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string username = row.Cells[1].Value.ToString();   // UserName
                string teamName = row.Cells[2].Value.ToString();   // TeamName
                string role = row.Cells[3].Value.ToString();       // role
                // تعبئة ComboBox المستخدم
                foreach (ComboBoxItem item in comboBox3.Items)
                {
                    if (item.Text == username)
                    {
                        comboBox3.SelectedItem = item;
                        break;
                    }
                }

                // تعبئة ComboBox الفريق
                foreach (ComboBoxItem item in comboBox4.Items)
                {
                    if (item.Text == teamName)
                    {
                        comboBox4.SelectedItem = item;
                        break;
                    }
                }

                // تعبئة حقل الدور
                TextRole.Text = role;
            }







        }

        private void Guna2Button4_Click(object sender, EventArgs e)
        {
            //حذف عضو من فريق معين
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("يرجى تحديد عضو لحذفه");
                return;
            }

            // نأخذ الـ ID للعضو من الصف المحدد
            int memberId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);

            DialogResult result = MessageBox.Show("هل أنت متأكد أنك تريد حذف هذا العضو؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                TeamMemberController controller = new TeamMemberController();
                bool deleted = controller.DeleteMember(memberId);

                if (deleted)
                {
                    MessageBox.Show("تم حذف العضو بنجاح");
                    LoadTeamMembersToGrid(); // تحديث الجدول
                }
                else
                {
                    MessageBox.Show("فشل في حذف العضو");
                }
            }
        }

        private void TextRole_TextChanged(object sender, EventArgs e)
        {

        }

        private void Guna2Button6_Click_1(object sender, EventArgs e)
        {
            // فتح الواجهة الرئيسية MainForm
            mainForm mainForm1 = new mainForm();
            mainForm1.Show();


            this.Hide(); // لإخفاء الفورم الحالي (LoginForm)
        }
    }

    public class ComboBoxItem
    {//خاص بالفرق
        public string Text { get; set; }
        public int Value { get; set; }

        public ComboBoxItem(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text; // يظهر الاسم داخل الكمبوبوكس
        }
    }
}

