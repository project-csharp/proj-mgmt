using MySql.Data.MySqlClient;
using System.Collections.Generic;

public class ProjectDashboardModel
{
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public int TaskCount { get; set; }
    public int TeamCount { get; set; }
}

public class ProjectRepository
{
    // سلسلة الاتصال بقاعدة البيانات
    private readonly string connectionString = "server=localhost;database=ManagAndTrackProjectsAndTeams_db;user=root;password=;";

    // هذه الدالة تجلب بيانات المشاريع مع عدد المهام وعدد الفرق لكل مشروع
    public List<ProjectDashboardModel> GetProjectDashboard()
    {
        // انشاء قائمة لتخزين النتائج
        List<ProjectDashboardModel> projects = new List<ProjectDashboardModel>();

        // استعلام SQL لجلب البيانات المطلوبة
        string sql = @"
            SELECT 
                p.id AS project_id,
                p.name AS project_name,
                COUNT(t.id) AS task_count,
                (
                    SELECT COUNT(DISTINCT tm.team_id)
                    FROM tasks t2
                    JOIN team_members tm ON tm.team_id = t2.assigned_to
                    WHERE t2.project_id = p.id
                ) AS team_count
            FROM projects p
            LEFT JOIN tasks t ON t.project_id = p.id
            GROUP BY p.id, p.name
            ORDER BY p.created_at DESC;";

        // فتح اتصال مع قاعدة البيانات باستخدام الـ using لضمان اغلاقه تلقائياً
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open(); // فتح الاتصال

            // إنشاء أمر SQL مع الاستعلام والاتصال المفتوح
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            // تنفيذ الاستعلام واستقبال البيانات باستخدام DataReader
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                // التكرار على كل صف تم إرجاعه من قاعدة البيانات
                while (reader.Read())
                {
                    // إنشاء كائن جديد من نوع ProjectDashboardModel وملئه بالبيانات
                    var project = new ProjectDashboardModel()
                    {
                        ProjectId = reader.GetInt32("project_id"),       // قراءة رقم المشروع
                        ProjectName = reader.GetString("project_name"),  // قراءة اسم المشروع
                        TaskCount = reader.GetInt32("task_count"),       // قراءة عدد المهام
                        TeamCount = reader.GetInt32("team_count")        // قراءة عدد الفرق
                    };

                    // إضافة الكائن إلى القائمة
                    projects.Add(project);
                }
            }
        }

        // إرجاع قائمة المشاريع مع البيانات المطلوبة
        return projects;
    }
}
