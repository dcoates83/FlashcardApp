using Flashcards.DataAccess;
using Flashcards.Models;
using Flashcards.Utilities;
using Spectre.Console;

namespace Flashcards.Controllers
{
    public class StackManager
    {

        public static void Menu()
        {

            List<(string, Action)> menuOptions = new()
            {

                ("Return to Main Menu", () => Console.WriteLine("Returning to Main Menu...")),
                ("Create a Stack", CreateStack),
                ("Delete a Stack", DeleteStack),
                ("Rename a Stack", RenameStack),
                ("Rename a Stacks Description", RenameDescription),
                ("Edit Flashcards in a Stack", FlashcardManager.EditFlashcards),
                ("View All Stacks", ViewStacks),
                ("View All Flashcards in a Stack", () => Console.WriteLine("Action: View All Flashcards in a Stack"))
                        };

            MenuBuilder menuBuilder = new();
            MenuItem menu = menuBuilder.CreateMenu("Manage Stacks & Flashcards", menuOptions);

            MenuManager menuManager = new(menu);
            MenuLoop menuLoop = new(menuManager);

            menuLoop.Start();


        }
        public static void ViewStacks()
        {

            using DBFactory factory = new();
            factory.ExecuteQuery("SELECT * FROM Stacks", reader =>
            {

                List<FlashcardStack> _stacks = new() { };

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        FlashcardStack stack = new()
                        {
                            Name = reader.GetString(1),
                            Description = reader.GetString(2),
                            StackId = reader.GetInt32(0)
                        };

                        _stacks.Add(stack);
                    }
                    DisplayStacks(_stacks);
                }
                else
                {

                    Console.WriteLine("No Rows");

                }
            });
        }

        public static void DisplayStacks(IEnumerable<FlashcardStack> stacks)
        {
            if (stacks == null || !stacks.Any())
            {
                Console.WriteLine("No stacks available.");
                return;
            }
            Table table = new();
            _ = table.AddColumn("Stack ID");
            _ = table.AddColumn("Name");
            _ = table.AddColumn("Description");



            foreach (FlashcardStack stack in stacks)
            {
                _ = table.AddRow(stack.StackId.ToString(), stack.Name, stack.Description);
            }

            AnsiConsole.Write(table);

        }


        public static void CreateStack()
        {

            Console.WriteLine("Enter a name for the stack");
            string name = Console.ReadLine();
            _ = ResponseValidator.IsValidResponse(name);

            Console.WriteLine("Enter a description for the stack");
            string description = Console.ReadLine();
            _ = ResponseValidator.IsValidResponse(description);



            using (DBFactory factory = new())
            {
                factory.ExecuteQuery($"INSERT INTO Stacks (Name, Description)\r\nVALUES ('{name}', '{description}');");
            }


            Console.WriteLine($"Stack {name} was created with the description: {description}");


        }
        public static void RenameStack()
        {
            ViewStacks();
            Console.WriteLine($"Which Stack would you like to rename?");
            string name = Console.ReadLine();
            _ = ResponseValidator.IsValidResponse(name);
            Console.WriteLine(
                $"What would you like to rename {name} to?");
            string newName = Console.ReadLine();
            _ = ResponseValidator.IsValidResponse(newName);

            using (DBFactory factory = new())
            {
                factory.ExecuteQuery($"UPDATE Stacks\r\nSET Name = '{newName}'\r\nWHERE Name = '{name}';");
            }
            Console.WriteLine(
                $"Stack: {name} was renamed to {newName}");

        }
        public static void RenameDescription()
        {
            ViewStacks();
            Console.WriteLine($"Which Stack would you like to rename?");
            string name = Console.ReadLine();
            _ = ResponseValidator.IsValidResponse(name);
            Console.WriteLine(
                               $"What would you like to rename the description of Stack:{name} to?");
            string newName = Console.ReadLine();
            _ = ResponseValidator.IsValidResponse(newName);

            using (DBFactory factory = new())
            {
                factory.ExecuteQuery($"UPDATE Stacks\r\nSET Description = '{newName}'\r\nWHERE Name = '{name}';");
            }
            Console.WriteLine(
                               $"Stack: {name} description was renamed to {newName}");
        }
        public static void DeleteStack()
        {

            ViewStacks();
            Console.WriteLine($"Which Stack would you like to delete?");
            string name = Console.ReadLine();
            _ = ResponseValidator.IsValidResponse(name);
            Console.WriteLine(
                                              $"Are you sure you want to delete {name}? (Y/N)");
            string response = Console.ReadLine();
            _ = ResponseValidator.IsValidResponse(response);
            response = response.ToUpper();
            if (response == "Y")
            {
                using (DBFactory factory = new())
                {
                    factory.ExecuteQuery($"DELETE FROM Stacks\r\nWHERE Name = '{name}';");
                }
                Console.WriteLine(
                                                      $"Stack: {name} was deleted");
            }
            else
            {
                Console.WriteLine(
                                                      $"Stack: {name} was not deleted");
            }
        }
        public static void StudyStack(int id)
        {
            _ = FlashcardManager.GetFlashcards(id);

        }


    }
}
