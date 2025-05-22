using System;
using ManagAndTrackProjectsAndTeams.src.NewFolder1;
using MySql.Data.MySqlClient;

namespace ManagAndTrackProjectsAndTeams.src.Model
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool Save()
        {
            try
            {
                conDB db = new conDB();
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string sql = "INSERT INTO projects (name, description, start_date, end_date) VALUES (@name, @description, @start_date, @end_date)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@name", Name);
                    cmd.Parameters.AddWithValue("@description", Description);
                    cmd.Parameters.AddWithValue("@start_date", StartDate.HasValue ? StartDate.Value.ToString("yyyy-MM-dd") : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@end_date", EndDate.HasValue ? EndDate.Value.ToString("yyyy-MM-dd") : (object)DBNull.Value);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("خطأ في حفظ المشروع: " + ex.Message);
                return false;
            }
        }
    }
}
