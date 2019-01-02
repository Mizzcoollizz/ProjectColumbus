using ProjectColumbus.Cards;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectColumbus
{
    public class CardDatabase
    {
        readonly SQLiteAsyncConnection database;

        public CardDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<CountryCard>().Wait();
            database.CreateTableAsync<AreaCard>().Wait();
        }

        public void CloseCardDatabase()
        {
            database.CloseAsync();
        }

        private async Task<bool> InsertCard(Card card) {
            var id = await database.InsertAsync(card);
            return true; //Maybe do something with the id?
        }

        public async Task<bool> InsertCardIfNeeded(Card card) {
            var found = await FindCardInDatabase(card);
            if (found == null)
            {
                return await InsertCard(card);
            }
            else {
                return false;
            }
        }

        private async Task<Card> FindCardInDatabase(Card card)
        {
            if (card is AreaCard) {
                return await database.FindAsync<AreaCard>(card.GetId());
            } else if (card is CountryCard) {
                return await database.FindAsync<CountryCard>(card.GetId());
            }
            return null;
        }
    }
}
