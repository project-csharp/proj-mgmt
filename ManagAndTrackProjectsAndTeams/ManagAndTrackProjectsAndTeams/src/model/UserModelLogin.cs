using System;
<<<<<<< HEAD
using ManagAndTrackProjectsAndTeams.src.model;
=======
using System.Data;
>>>>>>> d8d56ec0261da7a804d8ff0871ff0151ab992d57
using MySql.Data.MySqlClient;

namespace ManagAndTrackProjectsAndTeams.model
{
    public class UserModelLogin
    {
        private readonly string connectionString = "server=localhost;database=ManagAndTrackProjectsAndTeams_db;user=root;password=;";

<<<<<<< HEAD
        public User AuthenticateUser(string username, string password)
=======
        public bool AuthenticateUser(string username, string password)
>>>>>>> d8d56ec0261da7a804d8ff0871ff0151ab992d57
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
<<<<<<< HEAD
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
=======
                string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password); // يفضل تشفيرها في الإنتاج

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
>>>>>>> d8d56ec0261da7a804d8ff0871ff0151ab992d57
        }
    }
}
