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

            TcpClient client = new("127.0.0.1", 7000);

            NetworkStream stream = client.GetStream();

            string command = "";
            string username = "";
            string password = "";
            var user = new User();
            ConsoleKeyInfo keyInfo = new();


            //user = ConsoleInterface.LogIn_Or_LogOn(x, y, username, password, user);
            string answer = ReceivingAndSending.Receiving(stream);
            Console.WriteLine(answer);
            Console.ReadLine();

            string s = "Привет";
            ReceivingAndSending.Sending(stream, s);



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
            //while (true)
            //{
            //    //command = ConsoleInterface.Dropdown_Menu(x, y, command, user);
            //    byte[] send = Encoding.UTF8.GetBytes(command);
            //    stream.Write(send, 0, send.Length);
            //    stream.Flush();

            //    byte[] reads = new byte[1024];
            //    int lenght = stream.Read(reads, 0, reads.Length);
            //    answer = Encoding.UTF8.GetString(reads, 0, lenght);
            //    Console.WriteLine(answer);
            //    command = "";
            //    //Отсылаем бронь на проверку
            //    //Если проверку прошла записываем в бд
            //    //Ели не прошла, отсылаем fallse и я вывожу текст о том что бронь занята   
            //}
             
        }
    }
}