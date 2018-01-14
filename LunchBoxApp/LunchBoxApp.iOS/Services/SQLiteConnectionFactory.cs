using System;
using System.IO;
using LunchBoxApp.Domain.Services.Abstract;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;
using Xamarin.Forms;
using SQLite.Net.Interop;

[assembly: Dependency(typeof(LunchBoxApp.iOS.Services.SQLiteConnectionFactory))]

namespace LunchBoxApp.iOS.Services
{
    internal class SQLiteConnectionFactory : ISQLiteConnectionFactory
    {
        public SQLiteConnection CreateConnection(string databaseFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path = Path.Combine(path, databaseFileName);

            return new SQLiteConnection(
                new SQLitePlatformIOS(),
                path,
                SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite,
                storeDateTimeAsTicks: false
            );
        }
    }
}