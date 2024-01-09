using Microsoft.Extensions.Configuration;

namespace Flashcards.DataAccess
{
    public static class ConnectionStringManager
    {
        public static string GetConnectionString()
        {
            try
            {
                ConfigurationBuilder builder = new();
                _ = builder.AddJsonFile("appsettings.json", optional: false);
                IConfigurationRoot configuration = builder.Build();
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                return connectionString;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine($"Error fetching connection string: {ex.Message}");
                return string.Empty; // Return a default or empty string in case of failure
            }
        }
    }

}
