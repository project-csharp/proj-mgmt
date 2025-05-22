using ManagAndTrackProjectsAndTeams.src.NewFolder1;
using MySql.Data.MySqlClient;
using System;

namespace ManagAndTrackProjectsAndTeams.model
{
    public class UserModel
    {
        private readonly conDB db = new conDB();

        public bool CreateUser(string username, string password, string email)
        {
            try
            {
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO users (username, password, email) VALUES (@username, @password, @email)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@email", email);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("خطأ أثناء إنشاء المستخدم: " + ex.Message);
                return false;
            }
        }
    }
}
