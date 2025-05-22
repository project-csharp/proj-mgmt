using ManagAndTrackProjectsAndTeams.src.Models;
using System.Data;

namespace ManagAndTrackProjectsAndTeams.src.Controller
{
    public class TaskController
    {
        public bool AddTask(TaskModel task)
        {
            return task.AddTask();
        }
        private TaskModel model = new TaskModel();

        public DataTable GetAllTasksWithNames()//بيانات الجدول
        {
            return model.GetAllTasksWithNames();
        }
    }

}
