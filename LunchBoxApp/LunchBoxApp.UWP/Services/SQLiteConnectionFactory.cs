using SQLite;
using SQLite.Net.Interop;
using SQLite.Net.Platform.WinRT;
using System.IO;
using Windows.Storage;
using LunchBoxApp.Domain.Services.Abstract;
using Xamarin.Forms;

[assembly: Dependency(typeof(LunchBoxApp.UWP.Services.SQLiteConnectionFactory))]

namespace LunchBoxApp.UWP.Services
{
    internal class SQLiteConnectionFactory : ISQLiteConnectionFactory
    {
        public SQLiteConnection CreateConnection(string databaseFileName)
        {
            string path = ApplicationData.Current.LocalFolder.Path;
            path = Path.Combine(path, databaseFileName);

            return new SQLiteConnection(path);
        }
    }
}
