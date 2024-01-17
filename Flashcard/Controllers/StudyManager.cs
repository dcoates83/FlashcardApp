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


            StackManager.ViewStacks();
            Console.WriteLine("Enter the id of the stack you would like to study: ");
            string resp = Console.ReadLine();

            if (ResponseValidator.IsValidResponse(resp))
            {
                if (ResponseValidator.IsInt(resp))
                {
                    int stackId = Convert.ToInt32(resp);
                    StackManager.StudyStack(stackId);
                }

            }
        }
        public static void StudyAll()
        {
            Console.WriteLine("Study All");
        }
    }
}
