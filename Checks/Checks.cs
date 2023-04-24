using System.Text.RegularExpressions;

namespace Checks
{
    public class Checks
    {
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