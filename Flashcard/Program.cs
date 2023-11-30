using Flashcards.Services;

namespace Flashcard
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var Running = true;

            while (Running)
            {
                Menu.MainMenu();

                var resp = Console.ReadLine();

                Menu.ParseUserInput(resp, ref Running);
            }
        }
    }
}