using Microsoft.Data.SqlClient;

namespace Flashcards.DataAccess
{
    public class DBFactory : IDisposable
    {
        private readonly string _connectionString;


        public DBFactory()
        {
            _connectionString = ConnectionStringManager.GetConnectionString();
        }


        public void ExecuteQuery(string query, Action<SqlDataReader>? processResults = null)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();


            using SqlCommand command = new(query, connection);
            using SqlDataReader reader = command.ExecuteReader();

            processResults?.Invoke(reader);
            connection.Close();
        }

        public void Dispose()
        {
            // No specific resources to dispose in this case
        }


    }
}
