using Flashcards.Models;
using Flashcards.Utilities;
namespace Flashcards.Services
{
    internal class MainMenu
    {

        static bool _running = true;

        public static void Menu()
        {



            //while (_running)
            //{
            //    MainMenu.Menu();

            //    //var resp = Console.ReadLine();

            //    //MainMenu.ParseUserInput(resp, ref Running);
            //}
            var menuOptions = new List<(string, Action)> {

                ("Close Application", () =>
                {
                    Console.WriteLine("Closing application...");
                    _running = false;
                }
                ),
    ("Manage Flashcards", () =>  StackManger.Menu()),
    ("Study Flashcards", () => Console.WriteLine("Action: Delete a Stack")),
    ("View Statistics", () => Console.WriteLine("Action: Rename a Stack")),

                        };

            var menuBuilder = new MenuBuilder();
            var menu = menuBuilder.CreateMenu("Main Menu", menuOptions);

            var menuManager = new MenuManager(menu);
            var menuLoop = new MenuLoop(menuManager);

            menuLoop.Start();
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

                    // Manage Stacks & Flashcards
                    case "1":
                        StackManger.Menu();
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
