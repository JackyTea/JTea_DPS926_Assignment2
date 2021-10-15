using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using JTea_DPS926_Assignment2.Droid;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(JTea_DPS926_Assignment2.Droid.SQLiteDB))]
namespace JTea_DPS926_Assignment2.Droid
{
    public class SQLiteDB : SQLiteDBInterface
    {
        // create database with android dependency service
        public SQLiteAsyncConnection createSQLiteDB()
        {
            var document_path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(document_path, "coinsDB.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}