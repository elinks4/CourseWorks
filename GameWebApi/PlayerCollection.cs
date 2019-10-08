using System;
using System.Collections.Generic;

namespace GameWebApi
{
    public class PlayerCollection
    {

        public List<Player> collection = new List<Player>();
        //public List<Item> items = new List<Item>();


        public PlayerCollection() { }

        public void addPlayer(Player player)
        {


            collection.Add(player);



        }

        public Item CreateItem(Guid id,string name, int level, Enum type)
        {
           
         


          

        
  

           


            Item item = new Item();

            return item;

        }

        public void addItem(Guid player, Item playerItem)
        {

            Player top = GetOne(player);

            top.items.Add(playerItem);






        }


        public void deletePlayer(Guid id)
        {

            for (int i = 0; i < collection.Count; i++)
            {


                if (collection[i].Id == id)
                {

                    collection.Remove(collection[i]);


                }


            }


        }


        public void deleteItem(Guid player, Guid id)
        {


            Player top = GetOne(player);


            for (int i = 0; i < top.items.Count; i++)
            {


                if (top.items[i].Id == id)
                {

                    top.items.Remove(top.items[i]);


                }


            }


        }


        public Player[] GetAll()
        {


            Player[] array = new Player[collection.Count];

            array = collection.ToArray();


            return array;



        }

        public Item[] GetAllItems(Guid player)
        {

            Player top = GetOne(player);

            Item[] array = new Item[top.items.Count];

            array = top.items.ToArray();


            return array;



        }

        public Player GetOne(Guid id)
        {



            Player searched = new Player();

            for (int i = 0; i < collection.Count; i++)
            {


                if (collection[i].Id == id)
                {

                    searched = collection[i];


                }


            }


            return searched;


        }

        public Item GetOneItem(Guid player, Guid id)
        {

            Player top = GetOne(player);

            Item searched = new Item();

            for (int i = 0; i < top.items.Count; i++)
            {


                if (top.items[i].Id == id)
                {

                    searched = top.items[i];


                }


            }


            return searched;


        }

        public void Mod(Guid id, ModifiedPlayer player)
        {


            for (int i = 0; i < collection.Count; i++)
            {


                if (collection[i].Id == id)
                {

                    collection[i].Score = player.Score;


                }


            }

        }

        public void ModItem(Guid player, Guid id, ModifiedItem item)
        {

            Player top = GetOne(player);

            for (int i = 0; i < top.items.Count; i++)
            {


                if (top.items[i].Id == id)
                {

                    top.items[i].Level = item.Level;


                }


            }

        }


        public Item UpdateItem(Guid player, Item item){

            Player top = GetOne(player);

            Item updatedItem = item;

            return updatedItem;


        }

    }
}