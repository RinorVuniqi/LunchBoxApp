using SQLite;
using System;
using System.IO;
using Xamarin.Forms;
using LunchBoxApp.Domain.Services.Abstract;
using SQLite.Net.Platform.XamarinAndroid;

[assembly: Dependency(typeof(LunchBoxApp.Droid.Services.SqLiteConnectionFactory))]

namespace LunchBoxApp.Droid.Services
{
    internal class SqLiteConnectionFactory : ISQLiteConnectionFactory
    {
        public SQLiteConnection CreateConnection(string databaseFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path = Path.Combine(path, databaseFileName);

            return new SQLiteConnection(path);
        }
    }
}