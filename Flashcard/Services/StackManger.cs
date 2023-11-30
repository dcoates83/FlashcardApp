using Flashcards.Models;

namespace Flashcards.Services
{
    public class StackManger
    {
        public static void DisplayMenuOptions(ref bool running)
        {


            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Stack Menu");
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine(
              @"
        Type 0 to Return to Main Menu
        Type 1 to Create a Stack
        Type 2 to Delete a Stack
        Type 3 to Rename a Stack
        Type 4 to View All Stacks
        ");
            Console.WriteLine("-----------------------------------");

            var resp = Console.ReadLine();


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

        public static void ManageStack(FlashcardStack stack)
        {

        }
        public static void StudyStack(string stackName)
        {

        }
    }
}
