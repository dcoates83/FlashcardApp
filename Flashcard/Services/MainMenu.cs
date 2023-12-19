using Flashcards.Utilities;

namespace Flashcards.Services
{
    internal class MainMenu
    {
        private static readonly bool _running = true;
        // maybe privately store the menu object here

        public static void Menu()
        {

            List<(string, Action)> menuOptions = new()
            {

                ("Close Application", () =>
                {
                    Console.WriteLine("Closing application...");

                }
                ),
                ("Manage Flashcards", Stack.Menu),
                ("Study Flashcards", StudyManager.Menu),
                ("View Statistics", () => Console.WriteLine("Action: View statistics")),

                        };

            MenuBuilder menuBuilder = new();
            MenuItem menu = menuBuilder.CreateMenu("Main Menu", menuOptions);

            MenuManager menuManager = new(menu);
            MenuLoop menuLoop = new(menuManager);

            menuLoop.Start();
        }

        public static void StopMenu()
        {

        }

    }
}
