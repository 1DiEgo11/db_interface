namespace Users
{
    public class User
    {
        public int Id;
        public string name;
        public string password;
        public int IsAdmin;
        public List<Booking>? bookings;
        public User() 
        {
            Id = 0;
            name = "";
            password = "";
            IsAdmin = 0;
            bookings = null;
        }
        public User(string id, string username, string password) 
        {
            Id = int.Parse(id);
            name = username;
            this.password = password;
            IsAdmin = 0;
        }
        public User(int id, string username, string password, int IsAdmin)
        {
            Id = id;
            name = username;
            this.password = password;
            this.IsAdmin = IsAdmin;
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