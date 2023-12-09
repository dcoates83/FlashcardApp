using Flashcards.Models;
using Flashcards.Utilities;

namespace Flashcards.Services
{
    public class StackManger
    {
        public static void Menu()
        {
            var menuOptions = new List<(string, Action)>
{
    ("Return to Main Menu", () => Console.WriteLine("Action: Return to Main Menu")),
    ("Create a Stack", () => Console.WriteLine("Action: Create a Stack")),
    ("Delete a Stack", () => Console.WriteLine("Action: Delete a Stack")),
    ("Rename a Stack", () => Console.WriteLine("Action: Rename a Stack")),
    ("View All Stacks", () => Console.WriteLine("Action: View All Stacks")),
    ("View All Flashcards in a Stack", () => Console.WriteLine("Action: View All Flashcards in a Stack"))
            };

            var menuBuilder = new MenuBuilder();
            var menu = menuBuilder.CreateMenu("Manage Stacks & Flashcards", menuOptions);

            var menuManager = new MenuManager(menu);
            var menuLoop = new MenuLoop(menuManager);
            menuLoop.Start();



            //DisplayMenu.DisplayMenuOptions("Stack", menuOptions);

        }
        public static void ParseUserInput(string? input, ref bool running)
        {

            if (ResponseValidator.IsValidResponse(input))
            {


                switch (input)
                {
                    // Exit Application
                    case "0":
                        Console.WriteLine();
                        Console.WriteLine("Closing application...");
                        Console.WriteLine();
                        running = false;
                        break;

                    // Manage Stacks
                    case "1":

                        var runningSubMenu = true;

                        //while (runningSubMenu)
                        //{
                        //    StackManger.Menu(ref runningSubMenu);
                        //    var resp = Console.ReadLine();
                        //}
                        break;

                    // Manage Flashcards
                    case "2":
                        Console.WriteLine("2 was selected");
                        break;

                    // Study
                    case "3":
                        StackManger.DisplayStacks(new List<FlashcardStack> { new FlashcardStack { StackId = 1, Name = "Test Stack", Description = "This is a test stack" } });
                        var studyResp = Console.ReadLine();

                        if (ResponseValidator.IsValidResponse(studyResp))
                        {
                            // add logic here to match the studyResp to see if the stacks Databases matches the name
                            StackManger.StudyStack(studyResp);
                        }
                        Console.WriteLine("");
                        break;

                    // View Study Session Data
                    case "4":
                        Console.WriteLine("4 was selected");
                        break;
                    default:
                        {
                            Console.WriteLine("Please select a value in the list");
                        }
                        break;
                }
            }


        }

        public static void DisplayStacks(IEnumerable<FlashcardStack> stacks)
        {
            if (stacks == null || !stacks.Any())
            {
                Console.WriteLine("No stacks available.");
                return;
            }
            Console.Clear();
            Console.WriteLine("{0,-10} {1,-30} {2}", "Stack ID", "Name", "Description");
            Console.WriteLine(new string('-', 50));

            foreach (var stack in stacks)
            {
                Console.WriteLine("{0,-10} {1,-30} {2}", stack.StackId, stack.Name, stack.Description ?? "N/A");
            }
            Console.WriteLine();
            Console.WriteLine("Input a current stack name or input 0 to return to main menu");
        }
        //public static FlashcardStack PickStack(string stackName)
        //{

        //}

        public static void CreateStack(FlashcardStack stack)
        {

        }
        public static void RenameStack(string stackName)
        {

        }
        public static void DeleteStack(string stackName)
        {

        }
        public static void StudyStack(string stackName)
        {

        }

    }
}
