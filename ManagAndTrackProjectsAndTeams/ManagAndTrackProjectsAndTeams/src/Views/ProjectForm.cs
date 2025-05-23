using ManagAndTrackProjectsAndTeams.src.Model;
using ManagAndTrackProjectsAndTeams.src.NewFolder1;
using MySql.Data.MySqlClient;
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




        private int selectedProjectId = -1;
//متغير لتخزين مشروع محدد في list
        public ProjectForm()
        {
            InitializeComponent();
            LoadProjectsToListBox();//تحميل اسماء المشاريع ل list
            this.StartPosition = FormStartPosition.CenterScreen;
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
            string name = txtProjectName.Text.Trim();
            string description = txtProjectDescription.Text.Trim();
            DateTime? startDate = dateTimeStartDate.Value;
            DateTime? endDate = dateTimeEndDate.Value;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("الرجاء إدخال اسم المشروع");
                return;
            }

            var project = new ProjectModel
            {
                Name = name,
                Description = description,
                StartDate = startDate,
                EndDate = endDate
            };

            bool success = project.Save();
            if (success)
            {
                MessageBox.Show("تمت إضافة المشروع بنجاح");

                LoadProjectsToListBox();//تحميل اسماء المشاريع ل list
                ClearProjectFields(); // تنظف الحقول بعد الإضافة
            }
        }
        private void ClearProjectFields()
        {// تنظف الحقول بعد الإضافة
            txtProjectName.Text = "";
            txtProjectDescription.Text = "";
            dateTimeStartDate.Value = DateTime.Today;
            dateTimeEndDate.Value = DateTime.Today;
        }

        private void BtnNewProject_Click(object sender, EventArgs e)
        {
            tabProjects.SelectedTab = tabPage2;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

            if (selectedProjectId == -1)
            {
                MessageBox.Show("يرجى اختيار مشروع أولاً.");
                return;
            }

            string name = txtProjectNa.Text.Trim();
            string description = txtProjectNam.Text.Trim();
            DateTime startDate = dateTimeStartDat.Value;
            DateTime endDate = dateTimeEndDat.Value;

            conDB db = new conDB();
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"UPDATE projects SET 
                            name = @name, 
                            description = @description, 
                            start_date = @start_date, 
                            end_date = @end_date,
                            updated_at = CURRENT_TIMESTAMP()
                          WHERE id = @id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@start_date", startDate);
                    cmd.Parameters.AddWithValue("@end_date", endDate);
                    cmd.Parameters.AddWithValue("@id", selectedProjectId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("تم تحديث المشروع بنجاح.");
                        LoadProjectsToListBox(); // تحديث القائمة
                    }
                    else
                    {
                        MessageBox.Show("لم يتم العثور على المشروع لتعديله.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في تعديل المشروع: " + ex.Message);
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (selectedProjectId == -1)
            {
                MessageBox.Show("يرجى اختيار مشروع لحذفه.");
                return;
            }

            DialogResult result = MessageBox.Show("هل أنت متأكد أنك تريد حذف هذا المشروع؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DeleteProject(selectedProjectId);
                MessageBox.Show("تم حذف المشروع بنجاح.");
                LoadProjectsToListBox(); // إعادة تحميل المشاريع
                ClearProjectField();    // تنظيف الحقول
                selectedProjectId = -1;
            }
        }
        private void DeleteProject(int projectId)
        {//دالة تستخدم لحذف مشروع معين
            conDB db = new conDB();
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "DELETE FROM projects WHERE id = @id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", projectId);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ أثناء حذف المشروع: " + ex.Message);
                }
            }
        }
        private void ClearProjectField()
        {//لتفريغ الحقول بعد الحذف
            txtProjectNa.Clear();
            txtProjectNam.Clear();
            dateTimeStartDat.Value = DateTime.Now;
            dateTimeEndDat.Value = DateTime.Now;
        }


        private void TxbxSearch_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadProjectsToListBox()
        {// لتحميل المشاريع ل list
            conDB db = new conDB();
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, name FROM projects";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    listBox1.Items.Clear();

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string name = reader["name"].ToString();
                        listBox1.Items.Add(new ListBoxProjectItem(id, name));
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في جلب المشاريع: " + ex.Message);
                }
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {//

            if (listBox1.SelectedItem is ListBoxProjectItem selectedItem)
            {
                selectedProjectId = selectedItem.Id; // نحفظ الـ ID
                LoadProjectDetails(selectedProjectId);
            }
        }
        private void LoadProjectDetails(int projectId)
        {// تحمل تفاصيل المشروع
            conDB db = new conDB();
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT name, description, start_date, end_date FROM projects WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", projectId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtProjectNa.Text = reader["name"].ToString();
                            txtProjectNam.Text = reader["description"].ToString();

                            if (reader["start_date"] != DBNull.Value)
                                dateTimeStartDat.Value = Convert.ToDateTime(reader["start_date"]);

                            if (reader["end_date"] != DBNull.Value)
                                dateTimeEndDat.Value = Convert.ToDateTime(reader["end_date"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في تحميل بيانات المشروع: " + ex.Message);
                }
            }
        }

        private void Guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {

            mainForm main = new mainForm();
            main.Visible = true;
            this.Hide();
        }
    }
}
