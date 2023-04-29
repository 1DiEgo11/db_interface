﻿using Button_Selector;
using Button;
using Checks;
using Users;
using System.Diagnostics;
using Client_Server;
using System.Net.Sockets;

namespace Interface
{
   
    public class ConsoleInterface
    {
        public static void Line(int x, int y, User user, string[] users)
        {
            int X = x;
            int Y = y;
            int i = 0;
            Window_Main(x, y, 29, 80);
            foreach (var book in user.bookings)
            {
                if (users.Length > 0)
                {
                    Console.SetCursorPosition(x + 2, y + 1);
                    Console.WriteLine(users[i] + " " + book.Restaurant + " " + book.Date + " " + book.Time + " " + book.Table);
                    y++;
                    i++;
                }
                else
                {
                    Console.SetCursorPosition(x + 2, y + 1);
                    Console.WriteLine(book.Restaurant + " " + book.Date + " " + book.Time + " " + book.Table);
                    y++;
                }
            }

            var Button_del = new Buttons
            {

                method = new Action(() =>
                {
                    Console.SetCursorPosition(X + 4, Y + 1);
                    Console.Write("Удалить");
                }),
                command = new Action(() => 
                {
                    Console.SetCursorPosition(x + 5, y + 4);
                    Console.WriteLine("Выбирите строку которую хотели бы удалить: ");
                    Console.SetCursorPosition(x + 49, y + 4);
                    string s = Console.ReadLine();
                    string s1 = "";
                    if (s != "\n" || s != " ")
                    {
                        while (int.Parse(s) > user.bookings.Count)
                        {
                            Console.WriteLine("Нет такой строки");
                            s = Console.ReadLine();
                        }
                    }
                    
                    var book = user.bookings[int.Parse(s) - 1];
                    s1 = book.Restaurant + "/" + book.Date + "/" + book.Time + "/" + book.Table;

                    TcpClient client = new("127.0.0.1", 7000);

                    NetworkStream stream = client.GetStream();
                    if (users.Length > 0)
                    {
                        s1 = $"6/{users[int.Parse(s) - 1]}/" + s1;
                    }
                    else { s1 = $"6/{user.Id}/" + s; }
                    ReceivingAndSending.Sending(stream, s1);
                    user.bookings.Clear();
                })
            };
            var Button_back = new Buttons
            {
                method = new Action(() =>
                {
                    Console.SetCursorPosition(X + 5, Y + 4);
                    Console.Write("Назад");
                }),
                command = new Action(() =>
                {
                    return;
                })
            };

            var select = new ConsoleMenu(Button_del, Button_back);
            
            X += 30;
            Y += 19;

            Window_Button(X, Y);
           
            Window_Button(X, Y + 3);

            select.Show();
        }
        
        public static void Booking(int x, int y, string s, User user)
        {
            TcpClient client = new("127.0.0.1", 7000);

            NetworkStream stream = client.GetStream();
            s = Restaurants(x, y, s);
            s = Date(x, y, s);
            s = Time(x, y, s);
            s = Table(x, y, s);
            ReceivingAndSending.Sending(stream, $"5/{user.Id}/" + s);
        }

        public static void Window_Button(int x, int y)//отрисовка рамки для кнопки
        {
            int line = 3;
            int column = 15;
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (i == 0 | j == 0 | i == line - 1 | j == column - 1)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                y++;
                Console.WriteLine();
                Console.SetCursorPosition(x, y);
            }

        }

        public static void Window_Main(int x, int y, int line, int column)//отрисовка окна
        {

            Console.SetCursorPosition(x, y);
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (i == 0 | j == 0 | i == line - 1 | j == column - 1)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                y++;
                Console.WriteLine();
                Console.SetCursorPosition(x, y);
            }
        }

        public static void Dropdown_Menu(int x, int y, string s, User user)//выпадающее окно
        {
            var Button_my = new Buttons
            {
                method = new Action(() =>
                {
                    Console.SetCursorPosition(x + 3, y + 2);
                    Console.Write("Мои брони");
                }),
                command = new Action(() => 
                {
                    user.bookings = new List<Booking>();
                    TcpClient client = new("127.0.0.1", 7000);

                    NetworkStream stream = client.GetStream();

                    ReceivingAndSending.Sending(stream, $"4/{user.Id}/{user.IsAdmin}/0");

                    string booking = ReceivingAndSending.Receiving(stream);
                    char[] delimiterChars = { ' ', '/', '\n' };
                    string[] bookings = booking.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                    string[] logins = Array.Empty<string>();
                    if (booking == " ")
                    {
                        Console.Clear();
                        Console.WriteLine("У вас нет броней(Нажмите ENTER)"); Console.ReadLine();
                    }
                    else
                    {
                        if (bookings[0] != "" || bookings[0] != " ")
                        {
                            for (int i = 0; i < bookings.Length; i += 4)
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
                        }
                        Line(x, y, user, logins);
                    }

                    Console.Clear();
                })
            };
            var Button_new = new Buttons
            {

                method = new Action(() =>
                {
                    Console.SetCursorPosition(x + 3, y + 6);
                    Console.Write("Новая бронь");
                }),
                command = new Action(() => { Booking(x, y, s, user); })
            };
            var Button_Exit = new Buttons
            {
                method = new Action(() =>
                {
                    Console.SetCursorPosition(x + 3, y + 10);
                    Console.Write("Выход");
                }),
                command = new Action(() => 
                {
                    Console.Clear();
                    Console.WriteLine("До свидания!");
                    Process.GetCurrentProcess().Kill();
                })
            };
            var select = new ConsoleMenu(Button_my, Button_new, Button_Exit);

            if (user.IsAdmin == 1)
            {
                var Button_Admin = new Buttons
                {
                    method = new Action(() =>
                    {
                        Console.SetCursorPosition(x + 3, y + 14);
                        Console.Write("Все брони");
                    }),
                    command = new Action(() =>
                    {
                        TcpClient client = new("127.0.0.1", 7000);

                        NetworkStream stream = client.GetStream();

                        ReceivingAndSending.Sending(stream, $"4/{user.Id}/{user.IsAdmin}/1");

                        user.bookings = new List<Booking>();
                        string booking = ReceivingAndSending.Receiving(stream);
                        char[] delimiterChars = { ' ', '/', '\n' };
                        string[] bookings = booking.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                        string[] logins = new string[bookings.Length];


                        int j = 0;
                        if (booking == " ")
                        {
                            Console.Clear();
                            Console.WriteLine("Броней нет!(Нажмите ENTER)"); Console.ReadLine();
                        }
                        else
                        {
                            if (bookings[0] != "" || bookings[0] != " ")
                            {
                                for (int i = 0; i < bookings.Length; i += 5)
                                {
                                    logins[j] = bookings[i];
                                    var book = new Booking
                                    {
                                        Restaurant = bookings[i + 1],
                                        Date = bookings[i + 2],
                                        Time = bookings[i + 3],
                                        Table = bookings[i + 4],
                                    };
                                    user.bookings.Add(book);
                                    j++;
                                }
                            }
                            Line(x, y, user, logins);
                        }

                        Console.Clear();
                    })
                };
                select = new ConsoleMenu(Button_my, Button_new, Button_Exit, Button_Admin);
            }

            

            int line = 17;
            int column = 30;
            int Y = y;
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (i == 0 | j == 0 | i == line - 1 | j == column - 1 | i == 4 | i == 8 | i == 12)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Y++;
                Console.WriteLine();
                Console.SetCursorPosition(x, Y);
            }

            select.Show();
            Console.Clear();
        }

        public static User LogOn(int x, int y, string username, string password)
        {
            
            while(true)
            {
                TcpClient client = new("127.0.0.1", 7000);

                NetworkStream stream = client.GetStream();

                Console.Clear();
                Console.SetCursorPosition(x, y);
                Window_Main(x, y, 17, 43);//53
                Console.SetCursorPosition(x + 18, y + 2);
                Console.Write("LOG ON");
                Console.SetCursorPosition(x + 13, y + 4);
                Console.Write("Имя пользователя:");
                Console.SetCursorPosition(x + 14, y + 5);
                Console.Write("(3-10 символов)");
                Console.SetCursorPosition(x + 16, y + 7);
                username = Console.ReadLine();
                if(Checks.Checks.Check_Login(username) == false) { continue; }
                ReceivingAndSending.Sending(stream, "2/" + username);
                string answer = ReceivingAndSending.Receiving(stream);
                string[] answers = answer.Split(new char[] {'/', '\n', ' '}, StringSplitOptions.RemoveEmptyEntries);
                if (answers[0] == "used")
                {
                    continue;
                }
                else
                {
                    string id = answers[2];
                    Console.SetCursorPosition(x + 18, y + 9);
                    Console.Write("Пароль:");
                    Console.SetCursorPosition(x + 14, y + 10);
                    Console.Write("(5-10 символов)");
                    Console.SetCursorPosition(x + 16, y + 11);
                    password = Console.ReadLine();
                    if(Checks.Checks.Check_newPassword(password) == true) 
                    {
                        
                        TcpClient client1 = new("127.0.0.1", 7000);

                        NetworkStream stream1 = client1.GetStream();

                        ReceivingAndSending.Sending(stream1, "3/" + id + "/" + username + "/" + password);
                        var user = new User(id,username, password);
                        return user;
                    }
                }
            };  
        }

        public static User LogIn(int x, int y, string username, string password)
        {
            string password_fromBase = "";
            int id;
            int isAdmin;
            while(true) 
            {
                TcpClient client = new("127.0.0.1", 7000);

                NetworkStream stream = client.GetStream();

                Console.Clear();
                Console.SetCursorPosition(x, y);
                Window_Main(x, y, 17, 43);//53
                Console.SetCursorPosition(x + 18, y + 2);
                Console.Write("LOG IN");
                Console.SetCursorPosition(x + 13, y + 4);
                Console.Write("Имя пользователя:");
                Console.SetCursorPosition(x + 14, y + 5);
                Console.Write("(3-10 символов)");
                Console.SetCursorPosition(x + 16, y + 7);
                username = Console.ReadLine();
                if (Checks.Checks.Check_Login(username) == false)
                {
                    continue;
                }
                ReceivingAndSending.Sending(stream, $"1/{username}");
                string answer = ReceivingAndSending.Receiving(stream);
                if (answer == "not found")
                {
                    continue;
                }
                else if (answer != "not found")
                {
                    //Отсылаем в базу данных для проверки, существует ли такой логин
                    Console.SetCursorPosition(x + 18, y + 9);
                    Console.Write("Пароль:");
                    Console.SetCursorPosition(x + 14, y + 10);
                    Console.Write("(5-10 символов)");
                    Console.SetCursorPosition(x + 16, y + 11);
                    password = Console.ReadLine();
                    char[] delimiterChars = { ' ', '/', '\n' };
                    string[] answer1 = answer.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                    id = int.Parse(answer1[0]);
                    password_fromBase = answer1[1];
                    isAdmin = int.Parse(answer1[2]);
                    if (Checks.Checks.Check_Password(password, password_fromBase) == true)
                    { 
                        var user = new User(id, username, password, isAdmin);
                        return user;
                    }
                }
            }
            
        }

        public static User LogIn_Or_LogOn(int x, int y, string username, string password, User user)//регистрация или вход
        {
            Window_Main(x, y, 20, 45);
            x += 15;
            y += 6;
            Console.SetCursorPosition(x + 1, y - 4);
            Console.Write("!!!WELCOME!!!");
            Window_Button(x, y);
            Window_Button(x, y + 5);


            var Button_LogIn = new Buttons
            {
                
                method = new Action(() =>
                {
                    Console.SetCursorPosition(x + 4, y + 1);
                    Console.WriteLine("Log In");
                }),
                command = new Action(() =>
                {
                    Console.Clear();
                    user = LogIn(x - 15, y - 6, username, password);
                })
            };
            var Button_LogOn = new Buttons
            {
                
                method = new Action(() =>
                {
                    Console.SetCursorPosition(x + 4, y + 6);
                    Console.WriteLine("Log On");
                }),
                command = new Action(() =>
                {
                    Console.Clear();
                    user = LogOn(x - 15, y - 6, username, password);
                })
            };
            var select = new ConsoleMenu(Button_LogIn, Button_LogOn);

            select.Show();
            Console.Clear();
            return user;
        }

        public static string Restaurants(int x, int y, string s)//выбор ресторана
        {
            Window_Main(x, y, 25, 55);
            x += 19;
            y += 6;
            Console.SetCursorPosition(x - 13, y - 3);
            Console.Write("Какой рестсоран <ЧешиНа> Вы хотите посетить?");
            Window_Button(x, y);

            Window_Button(x, y + 5);

            Window_Button(x, y + 10);

            Console.SetCursorPosition(x - 10, y + 14);
            Console.Write("<ЧешиНа> - сеть ресторанов Чешской кухни");
            
            var Button_north = new Buttons
            {
                method = new Action(() =>
                {
                    Console.SetCursorPosition(x + 2, y + 1);
                    Console.Write("ЧешиНаСевер");
                }),
                command = new Action(() => { s += "1/"; })
            };
            var Button_south = new Buttons
            {
                
                method = new Action(() =>
                {
                    Console.SetCursorPosition(x + 3, y + 6);
                    Console.Write("ЧешиНаЮг");
                }),
                command = new Action(() => { s += "2/"; })
            };
            var Button_west = new Buttons
            {
                method = new Action(() =>
                {
                    Console.SetCursorPosition(x + 2, y + 11);
                    Console.Write("ЧешиНаЗапад");
                }),
                command = new Action(() =>{ s += "3/"; })
            };
            var select = new ConsoleMenu(Button_north, Button_south, Button_west);

            select.Show();
            Console.Clear();
            return s;
        }

        public static string Date(int x, int y, string s)
        {
            Window_Main(x, y, 25, 55);
            x += 19;
            y += 6;
            Console.SetCursorPosition(x - 14, y - 3);
            Console.Write("Выберите день, когда хотите посетить ресторан:");
            Window_Button(x, y);

            Window_Button(x, y + 5);

            Window_Button(x, y + 10);

            var Button_today = new Buttons
            {
                method = new Action(() =>
                {
                    Console.SetCursorPosition(x + 4, y + 1);
                    Console.Write("Сегодня");
                }),
                command = new Action(() => { s += "1/"; })
            };
            var Button_tomorrow = new Buttons
            {
                method = new Action(() =>
                {
                    Console.SetCursorPosition(x + 4, y + 6);
                    Console.Write("Завтра");
                }),
                command = new Action(() => { s += "2/"; })
            };
            var Button_day_after_tomorrow = new Buttons
            {
                method = new Action(() =>
                {
                    Console.SetCursorPosition(x + 2, y + 11);
                    Console.Write("Послезавтра");
                }),
                command = new Action(() => { s += "3/"; })
            };
            var select = new ConsoleMenu(Button_today, Button_tomorrow, Button_day_after_tomorrow);
            

            select.Show();
            Console.Clear();
            return s;
        }

        public static string Time(int x, int y, string s)
        {
            Window_Main(x, y, 28, 53);
            x += 19;
            y += 3;
            Console.SetCursorPosition(x, y - 2);
            Console.Write("Выберите время:");
            Window_Button(x, y);

            Window_Button(x, y + 4);

            Window_Button(x, y + 8);

            Window_Button(x, y + 12);

            Window_Button(x, y + 16);

            Window_Button(x, y + 20);
            var Button_1000_1130 = new Buttons
            {
                method = new Action(() =>
                {
                    Console.SetCursorPosition(x + 2, y + 1);
                    Console.Write("10:00-11:30");
                }),
                command = new Action(() => { s += "1/"; })
            };
            var Button_1130_1300 = new Buttons
            {
                method = new Action(() =>
                {

                    Console.SetCursorPosition(x + 2, y + 5);
                    Console.Write("11:30-13:00");
                }),
                command = new Action(() => { s += "2/"; })
            };
            var Button_1300_1430 = new Buttons
            {
                method = new Action(() =>
                {
                    Console.SetCursorPosition(x + 2, y + 9);
                    Console.Write("13:00-14:30");
                }),
                command = new Action(() => { s += "3/"; })
            };
            var Button_1430_1600 = new Buttons
            {
                method = new Action(() =>
                {
                    Console.SetCursorPosition(x + 2, y + 13);
                    Console.Write("14:30-16:00");
                }),
                command = new Action(() => { s += "4/"; })
            };
            var Button_1600_1730 = new Buttons
            {
                method = new Action(() =>
                {
                    Console.SetCursorPosition(x + 2, y + 17);
                    Console.Write("16:00-17:30");
                }),
                command = new Action(() => { s += "5/"; })
            };
            var Button_1730_1900 = new Buttons
            {
                method = new Action(() =>
                {
                    Console.SetCursorPosition(x + 2, y + 21);
                    Console.Write("17:30-19:00");
                }),
                command = new Action(() => { s += "6/"; })
            };
            var select = new ConsoleMenu(Button_1000_1130, Button_1130_1300, Button_1300_1430, Button_1430_1600, Button_1600_1730, Button_1730_1900);
     
            select.Show();
            Console.Clear();
            return s;
        }

        public static string Table(int x, int y, string s)
        {
            Window_Main(x, y, 25, 53);
            x += 19;
            y += 6;
            Console.SetCursorPosition(x - 7, y - 2);
            Console.Write("На сколько человек бронируете?");
            Window_Button(x, y);

            Window_Button(x, y + 5);

            Window_Button(x, y + 10);
            var Button_12 = new Buttons
            {
                method = new Action(() =>
                {
                    Console.SetCursorPosition(x + 6, y + 1);
                    Console.Write("1-2");
                }),
                command = new Action(() => { s += "1"; })
            };
            var Button_25 = new Buttons
            {
                method = new Action(() =>
                {
                    Console.SetCursorPosition(x + 6, y + 6);
                    Console.Write("2-5");
                }),
                command = new Action(() => { s += "2"; })
            };
            var Button_6 = new Buttons
            {
                method = new Action(() =>
                {
                    Console.SetCursorPosition(x + 7, y + 11);
                    Console.Write("5+");
                }),
                command = new Action(() => {  s += "3"; })
            };
            var select = new ConsoleMenu(Button_12, Button_25, Button_6);

            select.Show();
            Console.Clear();
            return s;
        }    
    }
}