using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GameWebApi
{
    public class FileRepository : IRepository
    {



        public static string path;



        AllPlayers allPlayer = new AllPlayers();


        public Task<Player> Create(Player player)
        {




            string AllText = File.ReadAllText(path);
            if (allPlayer.play != null)
            {
                AllPlayers players = JsonConvert.DeserializeObject<AllPlayers>(AllText);
                players.play.Add(player);

                string playerInfo = JsonConvert.SerializeObject(players);
                File.WriteAllText(path, playerInfo);

            }
            else
            {


                allPlayer.play.Add(player);
                string playerInfo = JsonConvert.SerializeObject(allPlayer);
                File.WriteAllText(path, playerInfo);
            }



            return Task.FromResult(player);


        }

        public Task<Player> Delete(Guid id)
        {




            Player searched = new Player();

            int number = 0;

            string AllText = File.ReadAllText(path);
            AllPlayers players = JsonConvert.DeserializeObject<AllPlayers>(AllText);


            for (int i = 0; i < players.play.Count; i++)
            {

                if (players.play[i].Id == id)
                {
                    number = i;
                    searched = players.play[i];
                }
            }
            players.play.Remove(players.play[number]);


            string playerInfo = JsonConvert.SerializeObject(players);
            File.WriteAllText(path, playerInfo);




            return Task.FromResult(searched);



        }

        public Task<Player> Get(Guid id)
        {
            Player searched = new Player();



            //  string AllText = File.ReadAllText(path);
            AllPlayers players = JsonConvert.DeserializeObject<AllPlayers>(File.ReadAllText(path));
            //  AllPlayers players = JsonConvert.DeserializeObject<AllPlayers>(AllText);


            for (int i = 0; i < players.play.Count; i++)
            {

                if (players.play[i].Id == id)
                {

                    searched = players.play[i];
                }
            }




            return Task.FromResult(searched);

        }

        public Task<Player[]> GetAll()
        {

            //   string AllText = File.ReadAllText(path);
            //   AllPlayers players = JsonConvert.DeserializeObject<AllPlayers>(AllText);
            AllPlayers players = JsonConvert.DeserializeObject<AllPlayers>(File.ReadAllText(path));
            //  Player[] allP = new Player[players.play.Count];
            //   List<Player> list = new List<Player>();

            //    for (int i = 0; i < players.play.Count; i++)
            //      {

            //         allP[i] = players.play[i];

            //     }

            return Task.FromResult(players.play.ToArray());

        }

        public Task<Player> Modify(Guid id, ModifiedPlayer player)
        {

            // collection.Mod(id, player);

            Player searched = new Player();


            string AllText = File.ReadAllText(path);
            AllPlayers players = JsonConvert.DeserializeObject<AllPlayers>(AllText);

            for (int i = 0; i < players.play.Count; i++)
            {

                if (players.play[i].Id == id)
                {

                    players.play[i].Score = player.Score;
                    searched = players.play[i];


                }

            }


            string playerInfo = JsonConvert.SerializeObject(players);
            File.WriteAllText(path, playerInfo);

            return Task.FromResult(searched);

        }



        public Task<Item> CreateItem(Guid player, Item playerItem)
        {



            string AllText = File.ReadAllText(path);
            AllPlayers players = JsonConvert.DeserializeObject<AllPlayers>(AllText);


            for (int i = 0; i < players.play.Count; i++)
            {

                if (players.play[i].Id == player)
                {

                    players.play[i].items.Add(playerItem);



                }

            }

            string playerInfo = JsonConvert.SerializeObject(players);
            File.WriteAllText(path, playerInfo);


            return Task.FromResult(playerItem);


        }

        public Task<Item> DeleteItem(Guid player, Guid id)
        {




            Item searchedo = new Item();




            string AllText = File.ReadAllText(path);
            AllPlayers players = JsonConvert.DeserializeObject<AllPlayers>(AllText);


            for (int i = 0; i < players.play.Count; i++)
            {

                if (players.play[i].Id == player)
                {

                    for (int o = 0; o < players.play[i].items.Count; o++)
                    {

                        if (players.play[i].items[o].Id == id)
                        {

                            searchedo = players.play[i].items[o];

                            players.play[i].items.Remove(players.play[i].items[o]);
                        }
                    }



                }

            }

            string playerInfo = JsonConvert.SerializeObject(players);
            File.WriteAllText(path, playerInfo);










            return Task.FromResult(searchedo);



        }
        public Task<Item> GetItem(Guid player, Guid id)
        {


            Item searched = new Item();

            string AllText = File.ReadAllText(path);
            AllPlayers players = JsonConvert.DeserializeObject<AllPlayers>(AllText);


            for (int i = 0; i < players.play.Count; i++)
            {

                if (players.play[i].Id == player)
                {

                    for (int o = 0; o < players.play[i].items.Count; o++)
                    {

                        if (players.play[i].items[o].Id == id)
                        {

                            searched = players.play[i].items[o];


                        }
                    }



                }

            }








            return Task.FromResult(searched);


        }

        public Task<Item[]> GetAllItems(Guid player)
        {

            string AllText = File.ReadAllText(path);

            AllPlayers players = JsonConvert.DeserializeObject<AllPlayers>(AllText);

            int o = 0;

            for (int i = 0; i < players.play.Count; i++)
            {

                if (players.play[i].Id == player)
                {


                    o = i;



                }

            }




            return Task.FromResult(players.play[o].items.ToArray());

        }





        public Task<Item> ModifyItem(Guid player, Guid id, ModifiedItem item)
        {



            Item searched = new Item();


            string AllText = File.ReadAllText(path);
            AllPlayers players = JsonConvert.DeserializeObject<AllPlayers>(AllText);



            for (int i = 0; i < players.play.Count; i++)
            {

                if (players.play[i].Id == player)
                {


                    for (int o = 0; o < players.play[i].items.Count; i++)
                    {


                        if (players.play[i].items[o].Id == id)
                        {

                            players.play[i].items[o].Level = item.Level;
                            searched = players.play[i].items[o];

                        }


                    }



                }

            }

            string playerInfo = JsonConvert.SerializeObject(players);
            File.WriteAllText(path, playerInfo);

            return Task.FromResult(searched);

        }

        public Task<Item> UpdateItem(Guid player, Guid gui, Item item)
        {

            Item updatedItem = new Item();
            string AllText = File.ReadAllText(path);
            AllPlayers players = JsonConvert.DeserializeObject<AllPlayers>(AllText);



            for (int i = 0; i < players.play.Count; i++)
            {

                if (players.play[i].Id == player)
                {


                    for (int o = 0; o < players.play[i].items.Count; i++)
                    {


                        if (players.play[i].items[o].Id == gui)
                        {

                            players.play[i].items[o].Level = item.Level;
                            updatedItem = players.play[i].items[o];

                        }


                    }



                }

            }

            string playerInfo = JsonConvert.SerializeObject(players);
            File.WriteAllText(path, playerInfo);




            return Task.FromResult(updatedItem);

        }



        public Task<Player[]> GetPlayerWithX(int x)
        {


            string AllText = File.ReadAllText(path);
            AllPlayers players = JsonConvert.DeserializeObject<AllPlayers>(AllText);

            List<Player> list = new List<Player>();

            for (int i = 0; i < players.play.Count; i++)
            {

                if (players.play[i].Level >= x)
                {

                    list.Add(players.play[i]);


                }


            }

            Player[] array = new Player[list.Count];
            array = list.ToArray();


            return Task.FromResult(array);

        }

        public Task<Player> GetPlayerWithName(string name)
        {

            Player play = new Player();
            string AllText = File.ReadAllText(path);
            AllPlayers players = JsonConvert.DeserializeObject<AllPlayers>(AllText);
            for (int i = 0; i < players.play.Count; i++)
            {

                if (players.play[i].Name == name)
                {

                    play = players.play[i];

                }
            }



            return Task.FromResult(play);


        }

        public Task<Player[]> GetPlayerWithItemIn(int level)
        {
            string AllText = File.ReadAllText(path);
            AllPlayers players = JsonConvert.DeserializeObject<AllPlayers>(AllText);
            List<Player> easier = players.play;
            List<Player> itemholders = new List<Player>();
            List<Guid> Ids = new List<Guid>();

            for (int i = 0; i < easier.Count; i++)
            {

                for (int o = 0; o < easier[i].items.Count; o++)
                {

                    if (easier[i].items[o].Level >= level)
                    {

                     
                            itemholders.Add(easier[i]);
                          

                        


                    }

                }

            }

            //   HashSet<Player> withoutDuplicates = new HashSet<Player>(itemholders);
         //   var onlyOneId = itemholders.Distinct().ToArray();



              List<Player> onlyOneId = itemholders.GroupBy(x => x.Id).Select(x => x.First()).ToList();

      
            return Task.FromResult(onlyOneId.ToArray());


        }

        public Task<Player[]> Get10PlayersWithHighScore()
        {

            string AllText = File.ReadAllText(path);
            AllPlayers players = JsonConvert.DeserializeObject<AllPlayers>(AllText);
            List<Player> isList = new List<Player>();
            isList = players.play;

            List<Player> winners = new List<Player>();


            Player[] array = isList.ToArray();
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

            return Task.FromResult(winners.ToArray());

        }


    }
}


