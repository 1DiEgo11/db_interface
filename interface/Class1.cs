using System.Drawing;

namespace Interface
{
    public class ConsoleRectangle
    {
       
        public static void Draw(int x, int y, int sizeX, int sizeY, ConsoleColor BorderColor)
        {

            
            string s = "╔";
            string space = "";
            string temp = "";
            for (int i = 0; i < sizeX; i++)
            {
                space += " ";
                s += "═";
            }
            for (int j = 0; j < x; j++)
                temp += " ";
            s += "╗" + "\n";
            for (int i = 0; i < sizeY; i++)
                s += temp + "║" + space + "║" + "\n";
            s += temp + "╚";
            for (int i = 0; i < sizeX; i++)
                s += "═";
            s += "╝" + "\n";
            Console.ForegroundColor = BorderColor;
            Console.CursorTop = y;
            Console.CursorLeft = x;
            Console.Write(s);
            Console.ResetColor();
        }
    }
}

