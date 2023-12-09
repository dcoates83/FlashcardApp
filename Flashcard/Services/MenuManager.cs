namespace Flashcards.Services
{
    public class MenuItem
    {
        public string Title { get; }
        public Action Action { get; }
        public List<MenuItem> SubMenu { get; }

        public MenuItem(string title, Action action = null)
        {
            Title = title;
            Action = action;
            SubMenu = new List<MenuItem>();
        }

        public void AddSubMenu(MenuItem menuItem)
        {
            SubMenu.Add(menuItem);
        }
    }

    public class MenuManager
    {
        private MenuItem _menu;

        public MenuManager(MenuItem menu)
        {
            _menu = menu;
        }

        public void DisplayMenu()
        {
            DisplaySubMenu(_menu);
        }

        private static void DisplaySubMenu(MenuItem menuItem, string indent = "")
        {
            Console.WriteLine($"{indent}{menuItem.Title}");

            foreach (var subMenuItem in menuItem.SubMenu)
            {
                Console.WriteLine($"{indent} - {subMenuItem.Title}");
            }

            Console.Write($"{indent}Enter choice: ");
            var choice = Console.ReadLine();

            if (int.TryParse(choice, out int index) && index >= 0 && index < menuItem.SubMenu.Count)
            {
                var selectedMenuItem = menuItem.SubMenu[index];
                if (selectedMenuItem.Action != null)
                {
                    selectedMenuItem.Action.Invoke();
                }
                else
                {
                    DisplaySubMenu(selectedMenuItem, indent + "  ");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice!");
            }
        }
    }

}
