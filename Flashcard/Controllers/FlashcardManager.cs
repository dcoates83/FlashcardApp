using Flashcards.DataAccess;
using Flashcards.Utilities;
using Spectre.Console;
using FlashcardModal = Flashcards.Models.Flashcard;

namespace Flashcards.Controllers
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
        public static void ViewFlashcards(int stackId)
        {

            List<FlashcardModal> flashcards = new();

            using DBFactory factory = new();
            factory.ExecuteQuery($"SELECT FlashcardId,FrontContent,BackContent, CreatedDate,LastModified \r\nFROM Flashcards\r\nJOIN Stacks\r\nON Flashcards.StackId = Stacks.StackId\r\nWHERE Stacks.StackId = {stackId};", reader =>
            {
                while (reader.Read())
                {

                    FlashcardModal flashcard = new()
                    {
                        FlashcardId = reader.GetInt32(0),
                        FrontContent = reader.GetString(1),
                        BackContent = reader.GetString(2),
                        CreatedDate = reader.GetDateTime(3),
                        LastModified = reader.IsDBNull(4) ? null : reader.GetDateTime(4)
                    };
                    flashcards.Add(flashcard);
                }
            });

            DisplayFlashcards(flashcards);

        }
        public static void DisplayFlashcards(List<FlashcardModal> flashcards)
        {
            Table table = new();
            _ = table.AddColumn("FlashcardId");
            _ = table.AddColumn("FrontContent");
            _ = table.AddColumn("BackContent");
            _ = table.AddColumn("CreatedDate");
            _ = table.AddColumn("LastModified");


            foreach (FlashcardModal flashcard in flashcards)
            {
                _ = table.AddRow(flashcard.FlashcardId.ToString(), flashcard.FrontContent, flashcard.BackContent, flashcard.CreatedDate.ToString(), flashcard.LastModified.ToString());
            }
            AnsiConsole.Write(table);

        }

        public static void EditFlashcards()
        {
            StackManager.ViewStacks();
            Console.WriteLine("Enter the Id of the stack you want to edit");
            string? response = Console.ReadLine();
            if (ResponseValidator.IsValidResponse(response))
            {
                if (int.TryParse(response, out int number))
                {

                    ViewFlashcards(number);


                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }

        }

        public static void EditFlashcard()
        {

        }
    }
}
