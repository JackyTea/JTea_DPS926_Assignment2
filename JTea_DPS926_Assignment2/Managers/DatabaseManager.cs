﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace JTea_DPS926_Assignment2.Managers
{
    public class DatabaseManager
    {
        // connection instance
        SQLiteAsyncConnection _connection;

        // constructor (0 params required)
        public DatabaseManager()
        {
            _connection = DependencyService.Get<SQLiteDBInterface>().createSQLiteDB();
        }

        // initialization of table and getting all coins
        public async Task<ObservableCollection<Coin>> CreateTable()
        {
            await _connection.CreateTableAsync<Coin>();
            var coinsFromDB = await _connection.Table<Coin>().ToListAsync();
            var coinsCollection = new ObservableCollection<Coin>(coinsFromDB);
            return coinsCollection;
        }

        // insert into database
        public async void InsertCoin(Coin newCoin)
        {
            await _connection.InsertAsync(newCoin);
        }

        // delete from database
        public async void DeleteCoin(Coin removeCoin)
        {
            await _connection.DeleteAsync(removeCoin);
        }
    }
}
