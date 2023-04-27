using Interface;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Users;
using Client_Server;

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
            ConsoleKeyInfo keyInfo = new();


            user = ConsoleInterface.LogIn_Or_LogOn(x, y, username, password, user);
            
            //TcpClient client1 = new("127.0.0.1", 7000);
            //NetworkStream stream1 = client1.GetStream();
            while (true)
            { 
                ConsoleInterface.Dropdown_Menu(x, y, command, user);   
            }

        }
    }
}