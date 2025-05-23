using ManagAndTrackProjectsAndTeams.src.Controller;
using ManagAndTrackProjectsAndTeams.src.Models;
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
    public partial class TaskForm : Form
    {
        private int selectedTaskId = -1; // لتخزين ID المهمة المحددة
        public TaskForm()
        {
            InitializeComponent();
            LoadTeam();
            LoadProJect();
            LoadTasksToGrid();//تحميل البيانات للجدول
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

                    comboBoxTeams.Items.Clear(); // ننظف العناصر قبل الإضافة

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string name = reader["name"].ToString();

                        // إضافة العنصر مع اسم الفريق و الـ id
                        comboBoxTeams.Items.Add(new ComboBoxItemTeam(name, id));
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ: " + ex.Message);
                }
            }
        }
        private void LoadProJect()
        {//تحميل المشاريع
            conDB db = new conDB();

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT id, name FROM projects";  // خذ id و name
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    ComboBoxItemProject.Items.Clear(); // ننظف العناصر قبل الإضافة

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string name = reader["name"].ToString();

                        // إضافة العنصر مع اسم الفريق و الـ id
                        ComboBoxItemProject.Items.Add(new ComboBoxItemProject(name, id));
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ: " + ex.Message);
                }
            }
        }

        private void TaskForm_Load(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        private void ClearTaskForm()
        {//دالة تفريغ الحقول
            txtTaskTitle.Clear();
            txtDescription.Clear();
            comboBoxTeams.SelectedIndex = -1;
            ComboBoxItemProject.SelectedIndex = -1;
            comboBoxStatus.SelectedIndex = -1;
            comboBoxPriority.SelectedIndex = 1;
      
        }

        private void Guna2Button2_Click(object sender, EventArgs e)
        {
            // إضافة مهمة
            if (comboBoxTeams.SelectedItem == null  ||
                comboBoxStatus.SelectedItem == null || comboBoxPriority.SelectedItem == null)
            {
                MessageBox.Show("يرجى تعبئة كل الحقول");
                return;
            }



            // التأكد من أن المستخدم اختار الفريق
            if (comboBoxTeams.SelectedItem == null)
            {
                MessageBox.Show("الرجاء اختيار الفريق");
                return;
            }

            // التأكد من أن المستخدم اختار المشروع
            if (ComboBoxItemProject.SelectedItem == null)
            {
                MessageBox.Show("الرجاء اختيار المشروع");
                return;
            }

            // استخراج الفريق والمشروع
            ComboBoxItemTeam selectedTeam = comboBoxTeams.SelectedItem as ComboBoxItemTeam;
           ComboBoxItemProject selectedProject = ComboBoxItemProject.SelectedItem as ComboBoxItemProject;

            // التأكد من صحة التحويل
            if (selectedTeam == null || selectedProject == null)
            {
                MessageBox.Show("حدث خطأ في قراءة الفريق أو المشروع");
                return;
            }

            int teamId = selectedTeam.Value;
            int projectId = selectedProject.Value;




            string title = txtTaskTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            DateTime dueDate = dateTimePickerDueDate.Value;
            string status = comboBoxStatus.SelectedItem.ToString().ToLower();     // مثل "completed"
            string priority = comboBoxPriority.SelectedItem.ToString().ToLower(); // مثل "low"

            TaskModel task = new TaskModel
            {
                TeamId = selectedTeam.Value,
                ProjectId = selectedProject.Value, // لا تستخدم قيمة ثابتة
                Title = title,
                Description = description,
                DueDate = dueDate,
                Status = status,
                Priority = priority
            };

            TaskController controller = new TaskController();
            if (controller.AddTask(task))
            {
                MessageBox.Show("تمت إضافة المهمة بنجاح");
                LoadTasksToGrid();//تحميل البيانات للجدول
                ClearTaskForm();
            }
        }

        private void DataGridViewTask_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Guna2Button5_Click(object sender, EventArgs e)
        {
            // فتح الواجهة الرئيسية MainForm
            mainForm mainForm1 = new mainForm();
            mainForm1.Show();


            this.Hide(); // لإخفاء الفورم الحالي (LoginForm)
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadTasksToGrid()
        {//تحميل البيانات للجدول
            TaskController controller = new TaskController();
            DataTable dt = controller.GetAllTasksWithNames();

            dataGridViewTask.DataSource = dt;

            // إخفاء عمود id إذا تحب
            if (dataGridViewTask.Columns.Contains("id"))
            {
                dataGridViewTask.Columns["id"].Visible = false;
            }
        }

        private void Guna2Button6_Click(object sender, EventArgs e)
        {
            //للتعديل
            if (selectedTaskId == -1)
            {
                MessageBox.Show("الرجاء تحديد مهمة لتعديلها");
                return;
            }

            // تحقق من القيم المدخلة
            if (ComboBoxItemProject.SelectedItem == null || comboBoxTeams.SelectedItem == null)
            {
                MessageBox.Show("الرجاء اختيار المشروع والفريق");
                return;
            }

            
            string title = txtTaskTitle.Text;
            string description = txtDescription.Text;
            DateTime dueDate = dateTimePickerDueDate.Value;
            string status = comboBoxStatus.SelectedItem?.ToString();
            string priority = comboBoxPriority.SelectedItem?.ToString();

            // التأكد من أن المستخدم اختار الفريق
            if (comboBoxTeams.SelectedItem == null)
            {
                MessageBox.Show("الرجاء اختيار الفريق");
                return;
            }

            // التأكد من أن المستخدم اختار المشروع
            if (ComboBoxItemProject.SelectedItem == null)
            {
                MessageBox.Show("الرجاء اختيار المشروع");
                return;
            }

            // استخراج الفريق والمشروع
            ComboBoxItemTeam selectedTeam = comboBoxTeams.SelectedItem as ComboBoxItemTeam;
            ComboBoxItemProject selectedProject = ComboBoxItemProject.SelectedItem as ComboBoxItemProject;

            // التأكد من صحة التحويل
            if (selectedTeam == null || selectedProject == null)
            {
                MessageBox.Show("حدث خطأ في قراءة الفريق أو المشروع");
                return;
            }

            int teamId = selectedTeam.Value;
            int projectId = selectedProject.Value;

            // إنشاء النموذج
            TaskModel task = new TaskModel
            {
                Id = selectedTaskId,
                ProjectId = selectedProject.Value,
                TeamId = selectedTeam.Value,
                Title = title,
                Description = description,
                DueDate = dueDate,
                Status = status,
                Priority = priority
            };

            // استدعاء التحديث من الكنترول
            TaskModel controller = new TaskModel();
            bool updated = controller.UpdateTask(task);

            if (updated)
            {
                MessageBox.Show("تم تحديث المهمة بنجاح");
                LoadTasksToGrid();
                
            }
            else
            {
                MessageBox.Show("فشل في تحديث المهمة");
            }
        }

        private void DataGridViewTask_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //يستخدم للحذف 

          
            //عند النقر على خلية محدد
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dataGridViewTask.Rows[e.RowIndex];
  selectedTaskId = Convert.ToInt32(row.Cells["id"].Value);

                // حفظ ID المهمة
                selectedTaskId = Convert.ToInt32(row.Cells["id"].Value);

                // تعبئة الحقول
                txtTaskTitle.Text = row.Cells["اسم المهمة"].Value.ToString();
                txtDescription.Text = row.Cells["الوصف"].Value.ToString();
                dateTimePickerDueDate.Value = Convert.ToDateTime(row.Cells["تاريخ البداية"].Value);
                comboBoxStatus.SelectedItem = row.Cells["الحالة"].Value.ToString();
                comboBoxPriority.SelectedItem = row.Cells["الأولوية"].Value.ToString();

                // تعيين المشروع
                string projectName = row.Cells["اسم المشروع"].Value.ToString();
               

                // تعيين الفريق
                string teamName = row.Cells["اسم الفريق"].Value.ToString();
                
            }
        }

        private void Guna2Button3_Click(object sender, EventArgs e)
        {
            if (selectedTaskId == -1)
            {
                MessageBox.Show("الرجاء تحديد مهمة للحذف");
                return;
            }

            var result = MessageBox.Show("هل أنت متأكد من أنك تريد حذف هذه المهمة؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    conDB db = new conDB();
                    using (MySqlConnection conn = db.GetConnection())
                    {
                        conn.Open();
                        string sql = "DELETE FROM tasks WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", selectedTaskId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("تم حذف المهمة بنجاح");

                    // إعادة تحميل المهام
                    LoadTasksToGrid();//تحميل البيانات للجدول
                    // إعادة تعيين ID المحدد
                    selectedTaskId = -1;

                    // مسح الحقول
                    ClearTaskForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ أثناء الحذف: " + ex.Message);
                }
            }
        }
    }

  


}
