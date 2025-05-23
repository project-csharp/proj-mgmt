using System;
using ManagAndTrackProjectsAndTeams.src.model;
using MySql.Data.MySqlClient;

namespace ManagAndTrackProjectsAndTeams.model
{
    public class UserModelLogin
    {
        private readonly string connectionString = "server=localhost;database=ManagAndTrackProjectsAndTeams_db;user=root;password=;";

        public User AuthenticateUser(string username, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id, username FROM users WHERE username = @username AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password); // يفضل تشفيرها

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Username = reader["username"].ToString()
                        };
                    }
                }
            }   // تخزين معلومات الجلسة
           


            return null; // المستخدم غير موجود
        }
    }
}
