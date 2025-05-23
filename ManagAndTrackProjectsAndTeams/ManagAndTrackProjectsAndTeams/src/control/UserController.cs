using ManagAndTrackProjectsAndTeams.model;

namespace ManagAndTrackProjectsAndTeams.control
{
    public class UserController
    {
        private readonly UserModel model = new UserModel();

        public bool RegisterUser(string username, string password, string email)
        {
            return model.CreateUser(username, password, email);
        }
    }
}
