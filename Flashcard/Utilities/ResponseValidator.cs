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
    }
}
