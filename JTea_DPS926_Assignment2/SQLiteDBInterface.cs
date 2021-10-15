using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace JTea_DPS926_Assignment2
{
    public interface SQLiteDBInterface
    {
        // instance of sqlite for initialization
        SQLiteAsyncConnection createSQLiteDB();
    }
}
