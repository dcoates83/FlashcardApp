namespace Flashcard.Models
{
    internal class Flashcard
    {
        int FlashcardId { get; set; }
        int StackId { get; set; }
        string FrontContent { get; set; }
        string BackContent { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime LastModified { get; set; }


    }
}
