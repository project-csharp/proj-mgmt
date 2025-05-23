// Model/DashboardModel.cs
using MySql.Data.MySqlClient;
using System.Data;

public class DashboardModel
{
    private string connectionString = "server=localhost;port=3306;database=ManagAndTrackProjectsAndTeams_db;user=root;password=;";
   

    public DataTable GetProjectTasks()
    {
        string query = @"
            SELECT 
                p.name AS project_name,
                COUNT(t.id) AS task_count
            FROM projects p
            LEFT JOIN tasks t ON p.id = t.project_id
            GROUP BY p.id, p.name;";

        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}
