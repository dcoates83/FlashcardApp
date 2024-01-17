// Ignore Spelling: Validator

namespace Flashcards.Utilities
{
    public static class ResponseValidator
    {
        public static bool IsValidResponse(string? resp)
        {
            if (string.IsNullOrWhiteSpace(resp))
            {
                Console.WriteLine("Please Enter a valid response");
                Console.WriteLine();
                return false;
            }

            return true;
        }
        public static bool IsInt(string resp)
        {
            if (int.TryParse(resp, out _))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Please Enter a valid number");
                Console.WriteLine();
                return false;
            }
        }
    }
}
