using Flashcards.Models;

namespace Flashcards.Services
{
    internal class UserInput
    {

        // Should maybe be renames to main menu
        public static void MainMenu()
        {


            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Main Menu");
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine(
                @"
        Type 0 to  Close Application
        Type 1 to Manage Stacks
        Type 2 to Manage Flashcards
        Type 3 to Study
        Type 4 to View Study Session Data
        ");
            Console.WriteLine("-----------------------------------");
        }
        public static bool IsValidUserResponse(string? resp)
        {

            if (string.IsNullOrWhiteSpace(resp))
            {
                Console.WriteLine("Please Enter a valid response");
                Console.WriteLine();
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void ParseUserInput(string? input, ref bool running)
        {

            if (IsValidUserResponse(input))
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

                        var RunningSubMenu = true;
                        while (RunningSubMenu)
                        {
                            StackManger.DisplayMenuOptions(ref RunningSubMenu);
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

                        if (IsValidUserResponse(studyResp))
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
