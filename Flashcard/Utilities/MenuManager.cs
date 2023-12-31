﻿namespace Flashcards.Utilities
{
    public class MenuItem
    {
        public string Title { get; }
        public Action Action { get; }
        public List<MenuItem> SubMenu { get; }

        public MenuItem(string title, Action? action = null)
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
        private readonly MenuItem _menu;
        private bool _shouldStop;

        public MenuManager(MenuItem menu)
        {
            _menu = menu;
            _shouldStop = false;
        }

        public void DisplayMenu()
        {
            DisplaySubMenu(_menu);
        }

        public bool ShouldStop()
        {
            return _shouldStop;
        }

        private void DisplaySubMenu(MenuItem menuItem, string indent = "")
        {
            Console.WriteLine($"{indent}{menuItem.Title}");

            for (int i = 0; i < menuItem.SubMenu.Count; i++)
            {
                Console.WriteLine($"{indent} {i} : {menuItem.SubMenu[i].Title}");
            }

            Console.Write($"{indent}Enter choice: ");

            string? choice = Console.ReadLine();

            Console.WriteLine();

            if (int.TryParse(choice, out int index) && index >= 0 && index < menuItem.SubMenu.Count)
            {
                MenuItem selectedMenuItem = menuItem.SubMenu[index];
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

            // Example: If the user enters '0', stop the loop
            if (choice == "0")
            {
                _shouldStop = true;
            }
        }
    }

}
