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
            user.bookings = new List<Booking>();

            TcpClient client = new("127.0.0.1", 7000);

            NetworkStream stream = client.GetStream();

            ReceivingAndSending.Sending(stream, $"4/{user.Id}");

            string booking = ReceivingAndSending.Receiving(stream);
            char[] delimiterChars = { ' ', '/', '\n' };
            string[] bookings = booking.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

            //Запрашиваем брони userа и записываем в user.bookings
            for (int i = 0; i < bookings.Length ; i += 4) 
            {
                var book = new Booking
                {
                    Restaurant = bookings[i],
                    Date = bookings[i + 1],
                    Time = bookings[i + 2],
                    Table = bookings[i + 3],
                };
                user.bookings.Add(book);
            }



            while (true)
            {
                TcpClient client1 = new("127.0.0.1", 7000);

                NetworkStream stream1 = client1.GetStream();

                command = ConsoleInterface.Dropdown_Menu(x, y, command, user);
                ReceivingAndSending.Sending(stream1, command);

                string answer = ReceivingAndSending.Receiving(stream1);
                Console.Clear();
                Console.WriteLine(answer);
                Console.ReadLine();
                //Отсылаем бронь на проверку
                //Если проверку прошла записываем в бд
                //Ели не прошла, отсылаем fallse и я вывожу текст о том что бронь занята   
            }

        }
    }
}