using ManagAndTrackProjectsAndTeams.src.NewFolder1;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace ManagAndTrackProjectsAndTeams.src.Model
{
    public class UserTeamModel
    {
        private conDB db;

        public UserTeamModel()
        {
            db = new conDB();
        }

        /// <summary>
        /// جلب جميع أعضاء الفرق مع اسم المستخدم واسم الفريق والدور والانضمام
        /// </summary>
        /// <returns>DataTable تحتوي على النتائج</returns>
        public DataTable GetTeamMembers()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();

                    // جلب بيانات مع JOIN بين الجداول لعرض الاسماء بدل الأيدي
                    string sql = @"
                        SELECT tm.id, u.username AS UserName, t.name AS TeamName, tm.role, tm.joined_at
                        FROM team_members tm
                        INNER JOIN users u ON tm.user_id = u.id
                        INNER JOIN teams t ON tm.team_id = t.id
                        ORDER BY tm.joined_at DESC";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    // هنا يمكن تسجيل الخطأ أو التعامل معه
                }
            }

            return dt;
        }
    }
}
