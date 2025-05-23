<<<<<<< HEAD
﻿//using ManagAndTrackProjectsAndTeams.model;

//namespace ManagAndTrackProjectsAndTeams.control
//{
//    public class UserControllerLogin
//    {
//        private UserModelLogin userModel = new UserModelLogin();

//        public bool Login(string username, string password)
//        {
//           / return userModel.AuthenticateUser(username, password);
//        }
//    }
//}
=======
﻿using ManagAndTrackProjectsAndTeams.model;

namespace ManagAndTrackProjectsAndTeams.control
{
    public class UserControllerLogin
    {
        private UserModelLogin userModel = new UserModelLogin();

        public bool Login(string username, string password)
        {
            return userModel.AuthenticateUser(username, password);
        }
    }
}
>>>>>>> d8d56ec0261da7a804d8ff0871ff0151ab992d57
