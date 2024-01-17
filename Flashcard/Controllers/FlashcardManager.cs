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
                ("Modify the front of a Flashcard", ModifyFrontOfFlashcard),
                ("Modify the back of a Flashcard", ModifyBackOfFlashcard),
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
            Console.WriteLine("Enter the stack id to view its Flashcard:");
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
                    factory.ExecuteQuery($"UPDATE Flashcards\r\nSET FrontContent = '{newFrontContent}', LastModified = CURRENT_TIMESTAMP \r\nWHERE FlashcardId = {flashcardId};");
                }
                else
                {
                    Console.WriteLine("Please enter a valid response");
                }


            }


        }
        public static void ModifyBackOfFlashcard()
        {
            int? flashcardId = GetFlashcardId();
            if (flashcardId != null)
            {
                Console.WriteLine("Enter the new front content:");
                string? newBackContent = Console.ReadLine();
                if (ResponseValidator.IsValidResponse(newBackContent))
                {
                    ModifyBackOfFlashcard((int)flashcardId, newBackContent);
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
            factory.ExecuteQuery($"UPDATE Flashcards\r\nSET BackContent = '{newBackContent}', LastModified = CURRENT_TIMESTAMP \r\nWHERE FlashcardId = {flashcardId};");
        }

        public static void DeleteFlashcard(int flashcardId)
        {
            using DBFactory factory = new();
            factory.ExecuteQuery($"DELETE FROM Flashcards\r\nWHERE FlashcardId = {flashcardId};");
        }
        public static void DeleteFlashcard()
        {
            int? flashcardId = GetFlashcardId();
            if (flashcardId != null)
            {
                DeleteFlashcard((int)flashcardId);
            }
        }

        public static void AddFlashcard()
        {
            StackManager.ViewStacks();
            Console.WriteLine("Enter the stack id you want to add to:");
            string? stackIdResp = Console.ReadLine();

            if (ResponseValidator.IsValidResponse(stackIdResp))
            {
                if (int.TryParse(stackIdResp, out int stackId))
                {
                    Console.WriteLine("Enter the front content:");
                    string? frontContent = Console.ReadLine();
                    Console.WriteLine("Enter the back content:");
                    string? backContent = Console.ReadLine();
                    if (ResponseValidator.IsValidResponse(frontContent) && ResponseValidator.IsValidResponse(backContent))
                    {
                        AddFlashcard(stackId, frontContent, backContent);
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }
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

        public static void StudyFlashcards()
        {
            List<FlashcardModal> flashcards = new();

            using DBFactory factory = new();
            StackManager.ViewStacks();
            Console.WriteLine("Enter the stack id to study its Flashcard:");
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

                    StudyFlashcards(flashcards);
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }
        }

        public static void StudyFlashcards(List<FlashcardModal> flashcards)
        {
            int flashcardIndex = 0;
            int flashcardCount = flashcards.Count;
            int correctCount = 0;
            int incorrectCount = 0;
            while (flashcardIndex < flashcardCount)
            {
                FlashcardModal flashcard = flashcards[flashcardIndex];
                Console.WriteLine($"Front: {flashcard.FrontContent}");
                Console.WriteLine("Press Enter to reveal the back");
                _ = Console.ReadLine();
                Console.WriteLine($"Back: {flashcard.BackContent}");
                Console.WriteLine("Did you get it right? (Y/N)");
                string? response = Console.ReadLine();
                if (ResponseValidator.IsValidResponse(response))
                {
                    response = response.ToUpper();
                    if (response == "Y")
                    {
                        correctCount++;
                    }
                    else if (response == "N")
                    {
                        incorrectCount++;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid response");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid response");
                }
                flashcardIndex++;
            }
            Console.WriteLine($"You got {correctCount} correct and {incorrectCount} incorrect");
        }

    }
}
