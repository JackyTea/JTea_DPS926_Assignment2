using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using SQLite;
using Xamarin.Forms;
using JTea_DPS926_Assignment2.iOS;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(JTea_DPS926_Assignment2.iOS.SQLiteDB))]
namespace JTea_DPS926_Assignment2.iOS
{
    public class SQLiteDB : SQLiteDBInterface
    {
        // create database with ios dependency service
        public SQLiteAsyncConnection createSQLiteDB()
        {
            var document_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(document_path, "coinsDB.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}