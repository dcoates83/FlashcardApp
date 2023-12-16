using Flashcards.Models;
using FlashcardModal = Flashcards.Models.Flashcard;
namespace Flashcards.Services
{
    public class FlashcardManager
    {
        public static List<FlashcardModal> GetFlashcards(FlashcardStack statck)
        {
            Console.WriteLine($"GetFlashcards was called");
            return new List<FlashcardModal>();
        }
        public static void EditFlashcard()
        {

        }
    }
}
