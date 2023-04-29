using Interface;
using Users;

namespace Business_Logic
{
    public class Logic
    {
        public static void Logics(int x, int y)
        {
            string command = "";
            string username = "";
            string password = "";
            var user = new User();

            user = ConsoleInterface.LogIn_Or_LogOn(x, y, username, password, user);

            while (true) { ConsoleInterface.Dropdown_Menu(x, y, command, user); }   
        }
    }
}