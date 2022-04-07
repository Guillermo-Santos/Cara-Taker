using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Care_Taker.Droid.Services;
using Care_Taker.Services;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Environment = System.Environment;

[assembly: Dependency(typeof(SQLiteDB))]
namespace Care_Taker.Droid.Services
{
    public class SQLiteDB : ISQLiteDB
    {
        
        SQLiteAsyncConnection ISQLiteDB.GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, "CareTaker.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}