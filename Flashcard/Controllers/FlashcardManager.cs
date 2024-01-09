using FlashcardModal = Flashcards.Models.Flashcard;
namespace Flashcards.Services
{
    public class FlashcardManager
    {
        public static List<FlashcardModal> GetFlashcards(int stackId)
        {
            Console.WriteLine($"GetFlashcards was called with stackId:{stackId}");
            // TODO: Implement this method
            // TODO: Return a list of flashcards
            // TODO: If no flashcards are available, return an empty list
            // TODO: If the stackId is invalid, return an empty list
            // TODO: If the stackId is valid, return a list of flashcards
            // TODO: If the stackId is valid, but no flashcards are available, return an empty list
            return new List<FlashcardModal>();
        }
        public static FlashcardModal GetFlashcard()
        {

            return new FlashcardModal();
        }
        public static void EditFlashcard()
        {

        }
    }
}
