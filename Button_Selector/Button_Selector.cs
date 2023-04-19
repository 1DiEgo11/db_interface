using Button;

namespace Button_Selector
{
    public class ConsoleMenu
    {
        private List<Buttons> items;
        public ConsoleMenu(params Buttons[] methods)
        {
            items = new List<Buttons>();
            items.AddRange(methods);
            ItemColor = ConsoleColor.Yellow;
            SelectionColor = ConsoleColor.Blue;
        }

        public ConsoleColor ItemColor;
        public ConsoleColor SelectionColor;
        public int SelectedItem { get; private set; }
        private int _top;//Положение первой строки меню


        public void Show(bool addEmptyLineBefore = true)
        {
            _top = Console.CursorTop;
            if (addEmptyLineBefore)
            {
                Console.WriteLine();
                _top++;
            }
            Console.ForegroundColor = ItemColor;

            for (int i = 0; i < items.Count; i++)
            {
                if (i == SelectedItem)
                {
                    Console.BackgroundColor = SelectionColor;
                }
                else
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ItemColor;
                }
                items[i].Method();
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.ResetColor();
            WaitForInput();
        }

        private void WaitForInput()
        {
            ConsoleKeyInfo cki = Console.ReadKey();
            switch (cki.Key)
            {
                case ConsoleKey.DownArrow:
                    MoveDown();
                    break;
                case ConsoleKey.UpArrow:
                    MoveUp();
                    break;
                case ConsoleKey.Enter:
                    break;
                case ConsoleKey.Tab:
                    return;
            }
        }

        private void MoveDown()
        {
            SelectedItem = SelectedItem == items.Count - 1 ? 0 : SelectedItem + 1;
            Show(false);
        }

        private void MoveUp()
        {
            SelectedItem = SelectedItem == 0 ? items.Count - 1 : SelectedItem - 1;
            Show(false);
        }
    }
}