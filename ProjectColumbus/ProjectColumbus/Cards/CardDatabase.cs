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

        private async void InsertCard(Card card) {
            var id = await database.InsertAsync(card);
        }

        public async void InsertCardIfNeeded(Card card) {
            var found = await FindCardInDatabase(card);
            if (found == null) {
                InsertCard(card);
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
