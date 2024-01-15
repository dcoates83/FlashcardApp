using Flashcards.DataAccess;
using Flashcards.Utilities;
using Spectre.Console;
using FlashcardModal = Flashcards.Models.Flashcard;

namespace Flashcards.Controllers
{
    public class FlashcardManager
    {


        public static void Menu()
        {

            List<(string, Action)> menuOptions = new()
            {

                ("Return to Main Menu", () => Console.WriteLine("Returning to Main Menu...")),
                ("Create a Flashcard", AddFlashcard),
                ("Delete a Flashcard", DeleteFlashcard),
                ("Modify the front of a Flashcard", ModifyFrontOfFlashcard),
                ("Modify the back of a Flashcard", ModifyBackOfFlashcard),
                //modify both front and back
                
                ("Delete a Flashcard", DeleteFlashcard),
                ("View All Flashcards", ViewFlashcards) };

            MenuBuilder menuBuilder = new();
            MenuItem menu = menuBuilder.CreateMenu("Manage Flashcards", menuOptions);

            MenuManager menuManager = new(menu);
            MenuLoop menuLoop = new(menuManager);

            menuLoop.Start();


        }

        public static void ViewFlashcards()
        {

            List<FlashcardModal> flashcards = new();

            using DBFactory factory = new();
            StackManager.ViewStacks();
            Console.WriteLine("Enter the Id of the stack you want to view:");
            string? response = Console.ReadLine();
            if (ResponseValidator.IsValidResponse(response))
            {
                if (int.TryParse(response, out int stackId))
                {

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
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }

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

        public static void ModifyFrontOfFlashcard()
        {
            int? flashcardId = GetFlashcardId();
            if (flashcardId != null)
            {
                Console.WriteLine("Enter the new front content:");
                string? newFrontContent = Console.ReadLine();
                if (ResponseValidator.IsValidResponse(newFrontContent))
                {
                    using DBFactory factory = new();
                    factory.ExecuteQuery($"UPDATE Flashcards\r\nSET FrontContent = '{newFrontContent}'\r\nWHERE FlashcardId = {flashcardId};");
                }
                else
                {
                    Console.WriteLine("Please enter a valid response");
                }


            }


        }
        public static void ModifyBackOfFlashcard(int flashcardId, string newBackContent)
        {
            using DBFactory factory = new();
            factory.ExecuteQuery($"UPDATE Flashcards\r\nSET BackContent = '{newBackContent}'\r\nWHERE FlashcardId = {flashcardId};");
        }

        public static void DeleteFlashcard(int flashcardId)
        {
            using DBFactory factory = new();
            factory.ExecuteQuery($"DELETE FROM Flashcards\r\nWHERE FlashcardId = {flashcardId};");
        }

        public static void AddFlashcard(int stackId, string frontContent, string backContent)
        {
            using DBFactory factory = new();
            factory.ExecuteQuery($"INSERT INTO Flashcards (StackId, FrontContent, BackContent)\r\nVALUES ({stackId}, '{frontContent}', '{backContent}');");
        }

        public static int? GetFlashcardId()
        {
            ViewFlashcards();
            Console.WriteLine("Enter the Id of the flashcard you want to edit:");

            string? response = Console.ReadLine();
            if (ResponseValidator.IsValidResponse(response))
            {
                if (int.TryParse(response, out int flashcardId))
                {
                    return flashcardId;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid response");
            }
            return null;
        }



    }
}
