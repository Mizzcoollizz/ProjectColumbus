using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectColumbus
{

    public class CardDatabase
    {
        readonly SQLiteAsyncConnection database;

        public CardDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Card>().Wait();
        }

        public void CloseCardDatabase()
        {
            database.CloseAsync();
        }
    }
}
