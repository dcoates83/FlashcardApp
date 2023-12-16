using Flashcards.Utilities;

namespace Flashcards.Services
{
    internal class MainMenu
    {
        private static bool _running = true;

        public static void Menu()
        {

            List<(string, Action)> menuOptions = new()
            {

                ("Close Application", () =>
                {
                    Console.WriteLine("Closing application...");
                    _running = false;
                }
                ),
                ("Manage Flashcards", StackManager.Menu),
                ("Study Flashcards", StudyManager.Menu),
                ("View Statistics", () => Console.WriteLine("Action: Rename a Stack")),

                        };

            MenuBuilder menuBuilder = new();
            MenuItem menu = menuBuilder.CreateMenu("Main Menu", menuOptions);

            MenuManager menuManager = new(menu);
            MenuLoop menuLoop = new(menuManager);

            menuLoop.Start();
        }



    }
}
