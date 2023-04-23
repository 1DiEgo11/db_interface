using System.Text.RegularExpressions;

namespace Checks
{
    public class Checks
    {
        
        public static void LogIn(string username, string password)
        {
            do
            {
                Console.CursorVisible = true;
                Console.WriteLine("Введите имя пользователя(от 2 до 10 символов)");
                username = Console.ReadLine();
                //Отсылаем в базу данных для проверки, что бы проверить не совпадает ли он с каким то из сущесвующих
                Console.WriteLine("Введите пароль(от 5 до 10 символов)");
                password = Console.ReadLine();
            } while (Check_Login(username) == false || Check_newPassword(password) == false);
        }

        public static void LogOn(string username, string password)
        {
            string password_fromBase;
            do
            {
                Console.CursorVisible = true;
                Console.WriteLine("Введите имя пользователя(от 2 до 10 символов)");
                username = Console.ReadLine();
                //Отсылаем в базу данных для проверки, существует ли такой логин
                Console.WriteLine("Введите пароль(от 5 до 10 символов)");
                password_fromBase = "Admin123";// тут база присылает пароль для сравнения
                password = Console.ReadLine();
            } while (Check_Login(username) == false || Check_Password(password, password_fromBase) == false);
        }


        public static bool Check_Login(string username)
        {
            Regex login_regex = new("^[a-zA-Zа-яА-Я][a-zA-Zа-яА-Я0-9]{2,9}$");

            if (login_regex.Match(username).Success) // если совпадение удачно
            {
                return true;
            }
            else
            {
               Console.WriteLine("Error log");
               return false;
            }
        }

        public static bool Check_Password(string password_from_person, string password_from_db)
        {
            if(password_from_db == password_from_person)
                return true;
            else
                return false;
        }

        public static bool Check_newPassword(string username)
        {
            Regex login_regex = new("^[a-zA-Zа-яА-Я][a-zA-Zа-яА-Я0-9]{4,9}$");

            if (login_regex.Match(username).Success) // если совпадение удачно
            {
                return true;
            }
            else
            {
                Console.WriteLine("Error pas");
                return false;
            }
        }
    }
}