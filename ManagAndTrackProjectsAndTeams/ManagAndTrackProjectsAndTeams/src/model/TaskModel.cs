using ManagAndTrackProjectsAndTeams.src.NewFolder1;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ManagAndTrackProjectsAndTeams.src.Models
{
    public class TaskModel
    {
        public int ProjectId { get; set; }
        public int TeamId { get; set; } // assigned_to = team_id
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public int Id { get; set; }
        public string Priority { get; set; } // NEW

        public bool AddTask()
        {
            conDB db = new conDB();

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"INSERT INTO tasks 
                                  (project_id, assigned_to, title, description, due_date, status, priority)
                                   VALUES (@project_id, @team_id, @title, @description, @due_date, @status, @priority)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@project_id", ProjectId);
                    cmd.Parameters.AddWithValue("@team_id", TeamId);
                    cmd.Parameters.AddWithValue("@title", Title);
                    cmd.Parameters.AddWithValue("@description", Description);
                    cmd.Parameters.AddWithValue("@due_date", DueDate);
                    cmd.Parameters.AddWithValue("@status", Status);
                    cmd.Parameters.AddWithValue("@priority", Priority);

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في إضافة المهمة: " + ex.Message);
                    return false;
                }
            }
        }
        public DataTable GetAllTasksWithNames()
        {
            conDB db = new conDB();
            DataTable dt = new DataTable();

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    t.id, 
                    t.title AS 'اسم المهمة',
                    t.description AS 'الوصف',
                    t.due_date AS 'تاريخ البداية',
                    t.status AS 'الحالة',
                    t.priority AS 'الأولوية',
                    pr.name AS 'اسم المشروع',
                    tm.name AS 'اسم الفريق'
                FROM tasks t
                JOIN projects pr ON t.project_id = pr.id
                JOIN teams tm ON t.assigned_to = tm.id
            ";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في تحميل المهام: " + ex.Message);
                }
            }

            return dt;
        }
        //للتعديل 
        public bool UpdateTask(TaskModel task)
        {
            conDB db = new conDB();

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = @"UPDATE tasks 
                           SET project_id = @projectId, 
                               assigned_to = @teamId, 
                               title = @title,
                               description = @description,
                               due_date = @dueDate,
                               status = @status,
                               priority = @priority
                           WHERE id = @id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@projectId", task.ProjectId);
                    cmd.Parameters.AddWithValue("@teamId", task.TeamId);
                    cmd.Parameters.AddWithValue("@title", task.Title);
                    cmd.Parameters.AddWithValue("@description", task.Description);
                    cmd.Parameters.AddWithValue("@dueDate", task.DueDate);
                    cmd.Parameters.AddWithValue("@status", task.Status);
                    cmd.Parameters.AddWithValue("@priority", task.Priority);
                    cmd.Parameters.AddWithValue("@id", task.Id);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في التحديث: " + ex.Message);
                    return false;
                }
            }
        }


    }
}
