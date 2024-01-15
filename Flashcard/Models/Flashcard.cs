namespace Flashcards.Models
{
    public class Flashcard
    {
        public int FlashcardId { get; set; }
        public int StackId { get; set; }
        public required string FrontContent { get; set; }
        public required string BackContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModified { get; set; }

    }
}
