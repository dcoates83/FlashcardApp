namespace Flashcards.Services
{
    public class MenuLoop
    {
        private readonly MenuManager _menuManager;

        public MenuLoop(MenuManager menuManager)
        {
            _menuManager = menuManager;
        }

        public void Start()
        {
            var runningSubMenu = true;

            while (runningSubMenu)
            {
                _menuManager.DisplayMenu();
                // Additional logic based on user input can be added here
                // For now, it will keep displaying the menu until the user exits manually.
            }
        }
    }
}