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
                UserInput.PromptUser();

                var resp = Console.ReadLine();

                UserInput.ParseUserInput(resp, ref Running);
            }
        }
    }
}