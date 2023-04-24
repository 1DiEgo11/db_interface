using Interface;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Users;

namespace Business_Logic
{
    public class Logic
    {

        public static void Logics(int x, int y)
        {
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[1];
            IPEndPoint ipEndPoint = new(ipAddr, 8081);

            Socket socket = new(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            socket.Connect(ipEndPoint);

            string command = "";
            string username = "";
            string password = "";
            var user = new User();
            ConsoleKeyInfo keyInfo = new();


            user = ConsoleInterface.LogIn_Or_LogOn(x, y, username, password, user);
            //user.bookings = new List<Booking>
            //{
            //    new Booking
            //    {
            //        Restaurant = "ЧешиНаЮг",
            //        Date = "Сегодня",
            //        Time = "10:00-11:30",
            //        Table = "1-2"
            //    }
            //};
            //Запрашиваем брони userа и записываем в user.bookings
            while (true)
            {
                command = ConsoleInterface.Dropdown_Menu(x, y, command, user);
                byte[] send = Encoding.UTF8.GetBytes(command);
                socket.Send(send);
                command = "";
                //Отсылаем бронь на проверку
                //Если проверку прошла записываем в бд
                //Ели не прошла, отсылаем fallse и я вывожу текст о том что бронь занята   
            }
             
        }
    }
}