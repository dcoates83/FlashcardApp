namespace Flashcards.Utilities
{
    internal class DisplayMenu
    {
        public static void DisplayMenuOptions(
            string menuName, string menuOptions)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"{menuName} Menu");
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine(
                             $@"{menuOptions}");
            Console.WriteLine("-----------------------------------");
        }
    }
}
