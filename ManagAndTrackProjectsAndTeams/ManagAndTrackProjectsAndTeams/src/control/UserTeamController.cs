using System.Data;
using ManagAndTrackProjectsAndTeams.src.Model;

namespace ManagAndTrackProjectsAndTeams.src.Controller
{
    public class UserTeamController
    {//عرض الحدول حق اعضاء الفرق
        private UserTeamModel model;

        public UserTeamController()
        {
            model = new UserTeamModel();
        }

        /// <summary>
        /// جلب بيانات أعضاء الفرق
        /// </summary>
        /// <returns>DataTable للعرض</returns>
        public DataTable GetTeamMembers()
        {
            return model.GetTeamMembers();
        }
    }
}
