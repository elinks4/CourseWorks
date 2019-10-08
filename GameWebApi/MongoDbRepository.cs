using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GameWebApi
{
    public class MongoDbRepository : IRepository
    {

        private IMongoClient client;
        private IMongoDatabase database;

        private IMongoCollection<Player> playercollection;

        public MongoDbRepository()
        {
            string connectionString = "mongodb://localhost:27017";

            client = new MongoClient(connectionString);
            database = client.GetDatabase("mongo");
            playercollection = database.GetCollection<Player>("players");


        }
        public Task<Player> Create(Player player)
        {

            playercollection.InsertOneAsync(player);
            return Task.FromResult(player);


        }

        public async Task<Item> CreateItem(Guid player, Item playerItem)
        {

            var filter = Builders<Player>.Filter.Eq(p => p.Id, player);

            var result = await playercollection.Find(filter).FirstAsync();

            result.items.Add(playerItem);

            var update = Builders<Player>.Update.Set(p => p.items, result.items);
            var result2 = await playercollection.UpdateOneAsync(filter, update);

            return playerItem;

        }

        public async Task<Player> Delete(Guid id)
        {

            var filter = Builders<Player>.Filter.Eq(p => p.Id, id);
            var result1 = await playercollection.Find(filter).FirstAsync();

            var result = await playercollection.DeleteOneAsync(filter);

            return result1;
        }

        public async Task<Item> DeleteItem(Guid player, Guid id)
        {

            var filter = Builders<Player>.Filter.Eq(p => p.Id, player);
            var pull = Builders<Player>.Update.PullFilter(p => p.items, i => i.Id == id);
            var resulted = await playercollection.FindOneAndUpdateAsync(filter, pull);

            var item = resulted.items.First(i => i.Id == id);


            return item;


        }

        public async Task<Player> Get(Guid id)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Id, id);
            var result = await playercollection.Find(filter).FirstAsync();

            return result;

        }

        public async Task<Player[]> GetAll()
        {
            //  var filter = Builders<Player>.Filter.Eq();

            List<Player> list = await playercollection.Find(_ => true).ToListAsync();
            Player[] array = list.ToArray();

            return array;

        }

        public async Task<Item[]> GetAllItems(Guid player)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Id, player);

            var player1 = await playercollection.Find(filter).FirstAsync();

            Item[] array = player1.items.ToArray();

            return array;

        }

        public async Task<Item> GetItem(Guid player, Guid id)
        {

            var filter = Builders<Player>.Filter.Eq(p => p.Id, player);

            var player1 = await playercollection.Find(filter).FirstAsync();

            var result = player1.items.First(i => i.Id == id);



            return result;

        }

        public async Task<Player> Modify(Guid id, ModifiedPlayer player)
        {

            var filter = Builders<Player>.Filter.Eq(p => p.Id, id);
            var update = Builders<Player>.Update.Set(p => p.Score, player.Score);
            var result = await playercollection.UpdateOneAsync(filter, update);

            return await playercollection.Find(filter).FirstAsync();
        }

        public async Task<Item> ModifyItem(Guid player, Guid id, ModifiedItem item)
        {

            var filter = Builders<Player>.Filter.Eq(p => p.Id, player);
            var player1 = await playercollection.Find(filter).FirstAsync();

            var result = player1.items.First(i => i.Id == id);

            result.Level = item.Level;

            var update = Builders<Player>.Update.Set(p => p.items, player1.items);
            var resulted = await playercollection.UpdateOneAsync(filter, update);

            var result2 = await playercollection.Find(filter).FirstAsync();

            return result;
        }

        public async Task<Item> UpdateItem(Guid player, Guid id, Item item)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Id, player);
            var player1 = await playercollection.Find(filter).FirstAsync();

            var result = player1.items.First(i => i.Id == id);

            result.Level = item.Level;

            var update = Builders<Player>.Update.Set(p => p.items, player1.items);
            var resulted = await playercollection.UpdateOneAsync(filter, update);

            return result;

        }



        public async Task<Player[]> GetPlayerWithX(int x)
        {

            var filter = Builders<Player>.Filter.Gte(p => p.Level, x);
            var players = await playercollection.Find(filter).ToListAsync();

            return players.ToArray();



        }

        public async Task<Player> GetPlayerWithName(string name)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Name, name);
            var result = await playercollection.Find(filter).FirstAsync();

            return result;

        }

        public async Task<Player[]> GetPlayerWithItemIn(int level)
        {
            List<Player> list = await playercollection.Find(_ => true).ToListAsync();
            List<Player> itemholders = new List<Player>();

            for (int i = 0; i < list.Count; i++)
            {

                for (int o = 0; o < list[i].items.Count; o++)
                {

                    if (list[i].items[o].Level >= level)
                    {

                        itemholders.Add(list[i]);


                    }

                }

            }


            List<Player> onlyOneId = itemholders.GroupBy(x => x.Id).Select(x => x.First()).ToList();


            return onlyOneId.ToArray();



        }


        public async Task<Player[]> Get10PlayersWithHighScore()
        {
            List<Player> list = await playercollection.Find(_ => true).ToListAsync();

            Player[] array = list.ToArray();
            List<Player> winners = new List<Player>();

            Array.Sort<Player>(array, new Comparison<Player>((i1, i2) => i2.Score.CompareTo(i1.Score)));

            if (array.Length >= 10)
            {
                for (int i = 0; i < 10; i++)
                {

                    winners[i] = array[i];

                }

            }
            else
            {

                winners = array.ToList();
            }

            return winners.ToArray();
        }
    }
}