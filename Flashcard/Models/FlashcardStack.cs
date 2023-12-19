namespace Flashcards.Models
{
    public class FlashcardStack
    {
        public int StackId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public FlashcardStack(string? name, string? description, int stackId)
        {
            Name = name;
            Description = description;
            StackId = stackId;
        }
    }
}
