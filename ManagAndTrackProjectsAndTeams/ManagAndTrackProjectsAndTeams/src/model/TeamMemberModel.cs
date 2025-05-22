using System;
using MySql.Data.MySqlClient;

namespace ManagAndTrackProjectsAndTeams.src.model
{
    public class TeamMemberModel
    {
        private readonly string connectionString = "server=localhost;database=ManagAndTrackProjectsAndTeams_db;user=root;password=;";

        public bool AddTeamMember(int userId, int teamId, string role)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO team_members (user_id, team_id, role) VALUES (@user_id, @team_id, @role)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@team_id", teamId);
                    cmd.Parameters.AddWithValue("@role", role);

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("خطأ أثناء الإضافة: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
