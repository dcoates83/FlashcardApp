using Flashcards.Models;
using Flashcards.Utilities;
namespace Flashcards.Services
{
    internal class Menu
    {

        // Should maybe be renames to main menu
        public static void MainMenu()
        {
            var menuOptions = @"
        Type 0 to  Close Application
        Type 1 to Manage Stacks
        Type 2 to Manage Flashcards
        Type 3 to Study
        Type 4 to View Study Session Data";


            DisplayMenu.DisplayMenuOptions("main", menuOptions);

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

                        while (runningSubMenu)
                        {
                            StackManger.Menu(ref runningSubMenu);
                        }
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
    }
}
