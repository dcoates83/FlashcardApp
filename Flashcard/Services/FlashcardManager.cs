namespace Flashcards.Services
{
    public class FlashcardManager
    {
        public static void DisplayFlashcards(IEnumerable<Models.Flashcard> flashcards)
        {
            if (flashcards == null || !flashcards.Any())
            {
                Console.WriteLine("No flashcards available.");
                return;
            }
            Console.Clear();
            Console.WriteLine("{0,-10} {1,-30} {2}", "Stack ID", "Name", "Description");
            Console.WriteLine(new string('-', 50));

            foreach (var flashcard in flashcards)
            {
                Console.WriteLine("{0,-10} {1,-30} {2}", flashcard.FlashcardId, flashcard.FrontContent, flashcard.BackContent ?? "N/A");
            }
            Console.WriteLine();
            Console.WriteLine("Input a current stack name or input 0 to return to main menu");
        }

        public static void ManageFlashcard(Models.Flashcard flashcard)
        {

        }
        public static void StudyFlashcard(string stackName)
        {

        }
    }
}
