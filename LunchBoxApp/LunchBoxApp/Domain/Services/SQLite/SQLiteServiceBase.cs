using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LunchBoxApp.Domain.Models;
using LunchBoxApp.Domain.Services.Abstract;
using SQLite;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace LunchBoxApp.Domain.Services.SQLite
{
    public abstract class SQLiteServiceBase
    {
        protected readonly SQLiteConnection connection;

        public SQLiteServiceBase()
        {
            //get the platform-specific SQLiteConnection
            var connectionFactory = DependencyService.Get<ISQLiteConnectionFactory>();
            connection = connectionFactory.CreateConnection("lunchboxdata.db3");

            //drop tables to update data (not users, those we want to store)
            connection.DropTable<Category>();
            connection.DropTable<Subcategory>();
            connection.DropTable<Product>();
            connection.DropTable<Payment>();

            //create tables (if not existing)
            connection.CreateTable<User>();
            connection.CreateTable<Category>();
            connection.CreateTable<Subcategory>();
            connection.CreateTable<Product>();
            connection.CreateTable<Payment>();

        }
    }
}
