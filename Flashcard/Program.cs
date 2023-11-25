using Flashcard.Services;

namespace Flashcard
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var _running = true;

            while (_running)
            {
                UserInput.PromptUser();

                var resp = Console.ReadLine();

                UserInput.ParseUserInput(resp, ref _running);
            }
        }
    }
}