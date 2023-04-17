using ConsoleTools;

var menu = new ConsoleMenu(
        new MenuMethod
        {
            Method = new Action(() => Console.WriteLine("Выполнена первая строка меню")),
            MenuText = "Первый пункт"
        },
        new MenuMethod
        {
            Method = new Action(() => Console.WriteLine(" вторая строка меню")),
            MenuText = "Второй пункт"
        });
menu.Show();


namespace ConsoleTools
{
    class MenuMethod
    {
        public Action Method;
        public string MenuText;
    }

    class ConsoleMenu
    {
        private List<MenuMethod> _methods;
        public ConsoleMenu(params MenuMethod[] methods)
        {
            _methods = new List<MenuMethod>();
            _methods.AddRange(methods);
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
            
            for (int i = 0; i < _methods.Count; i++)
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
                Console.SetCursorPosition(20, i);
                Console.WriteLine(_methods[i].MenuText);
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Нажмите любую клавишу для выхода...");
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
                    Console.Clear();
                    Console.SetCursorPosition(0, _methods.Count + 1);
                    _methods[SelectedItem].Method();
                    Show();
                    break;
            }
        }

        private void MoveDown()
        {
            SelectedItem = SelectedItem == _methods.Count - 1 ? 0 : SelectedItem + 1;
            Show(false);
        }

        private void MoveUp()
        {
            SelectedItem = SelectedItem == 0 ? _methods.Count - 1 : SelectedItem - 1;
            Show(false);
        }
    }
}

