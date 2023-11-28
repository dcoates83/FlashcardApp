namespace Flashcards.Models
{
    public class Flashcard
    {
        public int FlashcardId { get; set; }
        public int StackId { get; set; }
        public string? FrontContent { get; set; }
        public string? BackContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }

    }
}
