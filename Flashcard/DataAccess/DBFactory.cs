namespace Flashcards.DataAccess
{
    public class DBFactory
    {
        private readonly string _connectionString;


        public DBFactory()
        {
            _connectionString = ConnectionStringManager.GetConnectionString();
        }

    }
}
