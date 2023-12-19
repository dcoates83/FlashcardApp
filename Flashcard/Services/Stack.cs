using Flashcards.Models;
using Flashcards.Utilities;

namespace Flashcards.Services
{
    public class Stack
    {

        public static void Menu()
        {

            List<(string, Action)> menuOptions = new()
            {

                ("Return to Main Menu", () => Console.WriteLine("Returning to Main Menu...")),
                ("Create a Stack", ()=> CreateStack()),
                ("Delete a Stack", DeleteStack),
                ("Rename a Stack", RenameStack),
                ("Edit Flashcards in a Stack", () => Console.WriteLine("Action: Rename a Stack")),
                ("View All Stacks", () => Console.WriteLine("Action: View All Stacks")),
                ("View All Flashcards in a Stack", () => Console.WriteLine("Action: View All Flashcards in a Stack"))
                        };

            MenuBuilder menuBuilder = new();
            MenuItem menu = menuBuilder.CreateMenu("Manage Stacks & Flashcards", menuOptions);

            MenuManager menuManager = new(menu);
            MenuLoop menuLoop = new(menuManager);

            menuLoop.Start();


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

            foreach (FlashcardStack stack in stacks)
            {
                Console.WriteLine("{0,-10} {1,-30} {2}", stack.StackId, stack.Name, stack.Description ?? "N/A");
            }
            Console.WriteLine();
            Console.WriteLine("Input a current stack name or input 0 to return to main menu");
        }


        public static FlashcardStack CreateStack()
        {

            Console.WriteLine("Enter a name for the stack");
            string name = Console.ReadLine();
            _ = ResponseValidator.IsValidResponse(name);

            Console.WriteLine("Enter a description for the stack");
            string description = Console.ReadLine();
            _ = ResponseValidator.IsValidResponse(description);

            // TODO: Create a new stack with database here

            FlashcardStack stack = new(name, description, 1);

            Console.WriteLine($"Stack {stack.Name} was created");
            Console.WriteLine($"Stack ID: {stack.StackId}");
            Console.WriteLine($"Stack Description: {stack.Description}");

            return stack;
        }
        public static void RenameStack()
        {
            Console.WriteLine($"RenameStack was called");
        }
        public static void DeleteStack()
        {
            Console.WriteLine($"DeleteStack was called ");
        }
        public static void StudyStack(int id)
        {
            _ = FlashcardManager.GetFlashcards(id);

        }


    }
}
