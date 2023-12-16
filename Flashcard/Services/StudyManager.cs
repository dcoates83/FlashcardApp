using Flashcards.Models;

namespace Flashcards.Services
{
    public class StudyManager
    {

        public static void Menu()
        {

            var menuOptions = new List<(string, Action)> {

                ("Return to Main Menu", () => Console.WriteLine("Returning to Main Menu...")),
                ("Study All", () => StudyAll()),
                ("Study by Stack", ()=> StudyByStack()),

                        };

            var menuBuilder = new MenuBuilder();
            var menu = menuBuilder.CreateMenu("Study Menu", menuOptions);

            var menuManager = new MenuManager(menu);
            var menuLoop = new MenuLoop(menuManager);

            menuLoop.Start();
        }

        public static void StudyByStack()
        {
            StackManger.DisplayStacks(
        new List<FlashcardStack> { new FlashcardStack { StackId = 1, Name = "Test Stack", Description = "This is a test stack" } }
        );
            StackManger.StudyStack(Console.ReadLine());

        }
        public static void StudyAll()
        {
            Console.WriteLine("Study All");
        }
    }
}
