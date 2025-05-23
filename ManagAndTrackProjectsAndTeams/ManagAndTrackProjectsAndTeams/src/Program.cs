using System;
using System.Windows.Forms;
using ManagAndTrackProjectsAndTeams.src.Views;

namespace ManagAndTrackProjectsAndTeams
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            
            Application.Run(new Dash());
=======
>>>>>>> d8d56ec0261da7a804d8ff0871ff0151ab992d57

            Application.Run(new SplashForm());
        }
    }
}
