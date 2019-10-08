using System;
using System.Collections.Generic;
using System.Linq;
namespace Teht2
{
    public class Player : IPlayer
    {


        public System.Guid Id { get; set; }
        public int Score { get; set; }
        public List<Item> Items { get; set; }

        //public static System.Collections.Generic.IEnumerable<TSource> Distinct<TSource> (this System.Collections.Generic.IEnumerable<TSource> source);

        public Player[] InstantiatePlayers()
        {

            Player[] playerlist = new Player[1000000];



            Guid[] values = new Guid[1000000];



            Console.WriteLine("made player array");

            for (int i = 0; i < 1000000; i++)
            {
                playerlist[i] = new Player();
                //  Guid id = Guid.NewGuid();
                playerlist[i].Id = Guid.NewGuid();
                values[i] = playerlist[i].Id;

            }




            var sorted = playerlist.ToList();



            List<Player> onlyOneId = sorted.GroupBy(x => x.Id).Select(x => x.First()).ToList();
            List<Player> newL = new List<Player>();


            if (onlyOneId.Count != sorted.Count)
            {

                while (onlyOneId.Count != sorted.Count)
                {
                    Player pl = new Player();
                    pl.Id = Guid.NewGuid();
                    onlyOneId.Add(pl);
                    newL = onlyOneId.GroupBy(x => x.Id).Select(x => x.First()).ToList();
                    onlyOneId = newL;

                }

            }



/*
            for (var index = 1; index < sorted.Count; index++)
            {


                var previous = sorted[index - 1];
                var current = sorted[index];
                if (current == previous)
                {
                    Console.WriteLine(string.Format("duplicated value: {0}", current));




                }


*/



            






            /*

                        var result = playerlist.Distinct(new PlayerEqualityComparer());
                        //    IEnumerable<Player> distinghtplayers = playerlist.Distinct();
                        //foreach(var player in result.Distinct(d => d.Id).ToList()){    // }
                        //    if(playerlist.Count != playerlist.Distinct().Count()){}


                        for (int i = 0; i < 1000000; i++)
                        {


                            if (playerlist[i] != result)
                            {
                                Console.WriteLine(playerlist[i].Id);
                            }

                        }

            */

            return onlyOneId.ToArray();





        }


        public void InstantiateItems()
        {

            if (Items == null)
            {

                Random random = new Random();

                Items = new List<Item>();

                for (int i = 0; i < 10; i++)
                {

                    Item item = new Item();
                    item.Id = Guid.NewGuid();
                    int randomNumber = random.Next(1, 101);

                    item.Level = randomNumber;
                    Items.Add(item);



                }







            }

            else
            {



            }





        }

        public Item GetHighestLevelItem()
        {

            Item highestLevel = new Item();


            InstantiateItems();





            //   Console.WriteLine(Items.Count);

            for (int i = 1; i < Items.Count; i++)
            {


                if (Items[i].Level > Items[i - 1].Level)
                {


                    highestLevel = Items[i];


                }

            }


            return highestLevel;




        }



        public Item[] GetItems(Player player)
        {

            if (player.Items == null) { player.InstantiateItems(); }

            Item[] returnable = player.Items.ToArray();

            return returnable;


        }



        public Item[] GetItemsWithLinq(Player playa)
        {


            if (playa.Items == null) { playa.InstantiateItems(); }

            Item[] returnate = new Item[Items.Count];

            returnate = playa.Items.ConvertAll(c => c).ToArray();

            return returnate;









        }



        public Item FirstItem(Player pla)
        {


            if (pla.Items == null)
            {


                return null;



            }

            else
            {

                return pla.Items[0];


            }





        }


        public Item FirstItemWithLinq(Player plat)
        {


            if (plat.Items == null)
            {


                return null;



            }

            else
            {

                return plat.Items.FirstOrDefault();


            }





        }


        public void ProcessEachItem(Player player, Action<Item> process)
        {


            for (int i = 0; i < player.Items.Count; i++)
            {

                process.Invoke(player.Items[i]);

            }




        }


        public void PrintItem(Item item)
        {

            Console.WriteLine("this item's id is: ");

            Console.WriteLine(item.Id);
            Console.WriteLine("and level is: ");

            Console.WriteLine(item.Level);
            Console.WriteLine(" ");





        }





    }
}

















/*

    class PlayerEqualityComparer : IEqualityComparer<Player>
    {
        public bool Equals(Player x, Player y)
        {

            return x.Id == y.Id;
        }

        public int GetHashCode(Player obj)
        {
            return obj.Id.GetHashCode();
        }
    }
    
    
}

*/
