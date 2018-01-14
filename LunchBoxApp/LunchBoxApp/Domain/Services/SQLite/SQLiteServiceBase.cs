using System;
using System.Collections.Generic;
using System.Text;
using LunchBoxApp.Domain.Models;
using LunchBoxApp.Domain.Services.Abstract;
using SQLite;
using Xamarin.Forms;

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

            //create tables (if not existing)
            connection.CreateTable<User>();
            connection.CreateTable<Category>();
            connection.CreateTable<Subcategory>();
            connection.CreateTable<Product>();
            connection.CreateTable<Payment>();
        }
    }
}
