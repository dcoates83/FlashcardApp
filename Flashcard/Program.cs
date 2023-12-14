using Flashcards.Services;

namespace Flashcard
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var running = true;

            while (running)
            {
                MainMenu.Menu();

                var resp = Console.ReadLine();

                MainMenu.ParseUserInput(resp, ref running);
            }
        }
    }
}