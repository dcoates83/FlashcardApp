

namespace Flashcards.Services
{
    public class MenuBuilder
    {
        public MenuItem CreateMenu(string title, List<(string, Action)> options)
        {
            MenuItem menu = new(title);

            foreach ((string optionText, Action action) in options)
            {
                menu.AddSubMenu(new MenuItem(optionText, action));
            }

            return menu;
        }

        // You can add other methods to generate different types of menus as needed
    }
}

