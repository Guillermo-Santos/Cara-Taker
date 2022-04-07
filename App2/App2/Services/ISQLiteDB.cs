using SQLite;

namespace Care_Taker.Services
{
    public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}
