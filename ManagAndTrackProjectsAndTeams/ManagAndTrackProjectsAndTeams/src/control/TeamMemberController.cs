using ManagAndTrackProjectsAndTeams.src.model;
using ManagAndTrackProjectsAndTeams.src.NewFolder1;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ManagAndTrackProjectsAndTeams.src.control
{
    public class TeamMemberController
    {
        private TeamMemberModel model = new TeamMemberModel();

        public bool AddMember(int userId, int teamId, string role)
        {
            return model.AddTeamMember(userId, teamId, role);
        }


        public bool DeleteMember(int memberId)
        {
            conDB db = new conDB();

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string sql = "DELETE FROM team_members WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", memberId);

                    int affectedRows = cmd.ExecuteNonQuery();
                    return affectedRows > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ أثناء الحذف: " + ex.Message);
                    return false;
                }
            }
        }





    }


}
