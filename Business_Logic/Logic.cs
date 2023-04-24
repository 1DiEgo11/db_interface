using Interface;

namespace Business_Logic
{
    public class Logic
    {
        public static string Booking(int x, int y, string s)
        {
            s = ConsoleInterface.Restaurants(x, y, s);
            s = ConsoleInterface.Date(x, y, s);
            s = ConsoleInterface.Time(x, y, s);
            s = ConsoleInterface.Table(x, y, s);
            return s;
        }

        public static string Logics(int x, int y, string s, string username, string password)
        {
            ConsoleInterface.LogIn_Or_LogOn(x, y, username, password);
            s = Booking(x, y, s);
            //Отсылаем бронь на проверку
            //Если проверку прошла записываем в бд
            //Ели не прошла, отсылаем fallse и я вывожу текст о том что бронь занята    
            return s;
        }
    }
}