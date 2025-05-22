using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace ManagAndTrackProjectsAndTeams.model
{
    public class UserModelLogin
    {
        private readonly string connectionString = "server=localhost;database=ManagAndTrackProjectsAndTeams_db;user=root;password=;";

        public bool AuthenticateUser(string username, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password); // يفضل تشفيرها في الإنتاج

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }
}
