using System.Drawing;

namespace Interface
{
    public class ConsoleRectangle
    {
        public static void Window1(int x, int y)//отрисовка рамки для кнопки
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

        public static void Window(int x, int y, int line, int column)//отрисовка окна
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

        public static void Window3(int x, int y)//выпадающее окно
        {
            int line = 13;
            int column = 30;
            int Y = y;
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (i == 0 | j == 0 | i == line - 1 | j == column - 1 | i == 4 | i == 8)
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
            Console.SetCursorPosition(x + 3, y + 2);
            Console.Write("Кнопка 1");
            Console.SetCursorPosition(x + 3, y + 6);
            Console.Write("Кнопка 2");
            Console.SetCursorPosition(x + 3, y + 10);
            Console.Write("Кнопка 3");

        }

        public static void LogOrSign(int x, int y)//регистрация или вход
        {
            Window(x - 15, y - 6, 20, 45);
            Console.SetCursorPosition(x + 1, y - 4);
            Console.Write("!!!WELCOME!!!");
            Window1(x, y);
            Console.SetCursorPosition(x + 4, y + 1);
            Console.Write("LOG IN");

            y = y + 5;
            Window1(x, y);
            Console.SetCursorPosition(x + 4, y + 1);
            Console.Write("SIGN IN");
        }

        public static void Restaurant(int x, int y)//выбор ресторана
        {
            Window(x - 19, y - 6, 25, 55);
            Console.SetCursorPosition(x - 13, y - 3);
            Console.Write("Какой рестсоран <ЧешиНа> Вы хотите посетить?");
            Window1(x, y);
            Console.SetCursorPosition(x + 2, y + 1);
            Console.Write("ЧешиНаСевер");

            y = y + 5;
            Window1(x, y);
            Console.SetCursorPosition(x + 3, y + 1);
            Console.Write("ЧешиНаЮг");

            y = y + 5;
            Window1(x, y);
            Console.SetCursorPosition(x + 2, y + 1);
            Console.Write("ЧешиНаЗапад");

            Console.SetCursorPosition(x - 10, y + 4);
            Console.Write("<ЧешиНа> - сеть ресторанов Чешской кухни");
        }

        public static void Date(int x, int y)
        {
            Window(x - 19, y - 6, 25, 55);
            Console.SetCursorPosition(x - 14, y - 3);
            Console.Write("Выберите день, когда хотите посетить ресторан:");
            Window1(x, y);
            Console.SetCursorPosition(x + 4, y + 1);
            Console.Write("Сегодня");

            y = y + 5;
            Window1(x, y);
            Console.SetCursorPosition(x + 4, y + 1);
            Console.Write("Завтра");

            y = y + 5;
            Window1(x, y);
            Console.SetCursorPosition(x + 2, y + 1);
            Console.Write("Послезавтра");
        }

        public static void Time(int x, int y)
        {
            Window(x - 19, y - 3, 28, 53);
            Console.SetCursorPosition(x, y - 2);
            Console.Write("Выберите время:");
            Window1(x, y);
            Console.SetCursorPosition(x + 2, y + 1);
            Console.Write("10:00-11:30");

            y = y + 4;
            Window1(x, y);
            Console.SetCursorPosition(x + 2, y + 1);
            Console.Write("11:30-13:00");

            y = y + 4;
            Window1(x, y);
            Console.SetCursorPosition(x + 2, y + 1);
            Console.Write("13:00-14:30");

            y = y + 4;
            Window1(x, y);
            Console.SetCursorPosition(x + 2, y + 1);
            Console.Write("14:30-16:00");

            y = y + 4;
            Window1(x, y);
            Console.SetCursorPosition(x + 2, y + 1);
            Console.Write("16:00-17:30");

            y = y + 4;
            Window1(x, y);
            Console.SetCursorPosition(x + 2, y + 1);
            Console.Write("17:30-19:00");

        }

        public static void Table(int x, int y)
        {
            Window(x - 19, y - 6, 25, 53);
            Console.SetCursorPosition(x - 7, y - 2);
            Console.Write("На сколько человек бронируете?");
            Window1(x, y);
            Console.SetCursorPosition(x + 6, y + 1);
            Console.Write("1-2");

            y = y + 5;
            Window1(x, y);
            Console.SetCursorPosition(x + 6, y + 1);
            Console.Write("2-5");

            y = y + 5;
            Window1(x, y);
            Console.SetCursorPosition(x + 7, y + 1);
            Console.Write("5+");
        }
    }
}

//    //Window3(1,1);

//    LogOrSign(53, 10);
//    System.Threading.Thread.Sleep(3000);
//    Console.Clear();

//    Restaurant(53, 10);
//    System.Threading.Thread.Sleep(3000);
//    Console.Clear();

//    Date(53, 10);
//    System.Threading.Thread.Sleep(3000);
//    Console.Clear();

//    Time(53, 4);
//    System.Threading.Thread.Sleep(3000);
//    Console.Clear();

//    Table(53,10);


//    Console.ReadKey();
//}

