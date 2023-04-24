namespace Users
{
    public class User
    {
        public string name;
        public string password;
        public int IsAdmin;
        public List<Booking>? bookings;
        public User() 
        {
            name = "";
            password = "";
            IsAdmin = 0;
            bookings = null;
        }
        public User(string username, string password) 
        {
            name = username;
            this.password = password;
            bookings = null;
        }
    }

    public class Booking
    {
        public string Restaurant;
        public string Date;
        public string Time;
        public string Table;
    }
}