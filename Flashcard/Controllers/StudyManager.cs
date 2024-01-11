using Flashcards.Models;
using Flashcards.Utilities;

namespace Flashcards.Controllers
{
    public class StudyManager
    {

        public static void Menu()
        {

            List<(string, Action)> menuOptions = new()
            {

                ("Return to Main Menu", () => Console.WriteLine("Returning to Main Menu...")),
                ("Study All", StudyAll),
                ("Study by Stack", StudyByStack),

                        };

            MenuBuilder menuBuilder = new();
            MenuItem menu = menuBuilder.CreateMenu("Study Menu", menuOptions);

            MenuManager menuManager = new(menu);
            MenuLoop menuLoop = new(menuManager);

            menuLoop.Start();
        }

        public static void StudyByStack()
        {

            List<FlashcardStack> flashcardStacks = new()
            { new FlashcardStack{
            Name ="test"} };

            Stack.DisplayStacks(
                flashcardStacks

        );
            string? response = Console.ReadLine();
            if (ResponseValidator.IsValidResponse(response))
            {
                if (int.TryParse(response, out int number))
                {

                    Stack.StudyStack(number);
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }

        }
        public static void StudyAll()
        {
            Console.WriteLine("Study All");
        }
    }
}
