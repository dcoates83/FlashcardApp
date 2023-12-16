namespace Flashcards.Utilities
{
    public class MenuLoop
    {
        private readonly MenuManager _menuManager;
        private bool _running;

        public MenuLoop(MenuManager menuManager)
        {
            _menuManager = menuManager;
            _running = true;

        }

        public void Start()
        {
            while (_running)
            {
                _menuManager.DisplayMenu();
                // Additional logic based on user input can be added here
                // For example, you can check for a condition to stop the loop
                if (_menuManager.ShouldStop())
                {
                    Stop();
                }
            }
        }
        public void Stop()
        {
            _running = false;

        }
    }
}