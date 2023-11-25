namespace Flashcard.Services
{
    internal class UserInput
    {
        public static void PromptUser()
        {


            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Main Menu");
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine(
                @"
        Type 0 to  Close Application
        Type 1 to Manage Stacks
        Type 2 to Manage Flashcards
        Type 3 to Study
        Type 4 to View Study Session Data
        ");
            Console.WriteLine("-----------------------------------");
        }
        public static bool IsValidUserResponse(string? resp)
        {

            if (string.IsNullOrWhiteSpace(resp))
            {
                Console.WriteLine("Please Enter a valid response");
                Console.WriteLine();
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void ParseUserInput(string? input, ref bool running)
        {

            if (IsValidUserResponse(input))
            {


                switch (input)
                {
                    case "0":
                        Console.WriteLine();
                        Console.WriteLine("Closing application...");
                        Console.WriteLine();
                        running = false;
                        break;
                    case "1":

                        Console.WriteLine("1 was selected");
                        break;
                    case "2":
                        Console.WriteLine("2 was selected");

                        break;
                    case "3":
                        Console.WriteLine("3 was selected");
                        break;

                    default:
                        {
                            Console.WriteLine("Please select a value in the list");
                        }
                        break;
                }
            }


        }
    }
}
