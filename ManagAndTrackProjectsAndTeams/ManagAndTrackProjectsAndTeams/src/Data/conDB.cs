using System;
using MySql.Data.MySqlClient;

namespace ManagAndTrackProjectsAndTeams.src.NewFolder1
{
    public class conDB
    {
        private readonly string connectionString;

        public conDB()
        {
            // غيّر معلومات الاتصال حسب بيئة قاعدة بياناتك
            connectionString = "server=localhost;port=3306;database=ManagAndTrackProjectsAndTeams_db;user=root;password=;";
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // اختبار الاتصال
        public bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    Console.WriteLine("✅ الاتصال ناجح!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ خطأ الاتصال بقاعدة البيانات: " + ex.Message);
                return false;
            }
        }
    }
}
