using SQLite;

namespace LunchBoxApp.Domain.Services.Abstract
{
    public interface ISQLiteConnectionFactory
    {
        SQLiteConnection CreateConnection(string databaseFileName);
    }
}
