using System;
using System.Collections.Generic;
using System.Linq;
namespace Teht2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            Player player = new Player();
            Player[] oneplay;
            oneplay = player.InstantiatePlayers();

            Item oneTrueItem = new Item();

            oneTrueItem = player.GetHighestLevelItem();


            Console.WriteLine(" ");

            Console.WriteLine(oneTrueItem.Level);

            Item[] littleArray = player.GetItemsWithLinq(player);


            player.ProcessEachItem(player, player.PrintItem);

            Action<Player> lambdaa = x =>
            {
                x.ProcessEachItem(x, x.PrintItem);
            };

            lambdaa.Invoke(player);

            
            player.Score = 1;
            Player player4 = new Player();
            player4.Score = 5;

            List<Player> players = new List<Player> { player, player4 };
            PlayerForAnotherGame pla = new PlayerForAnotherGame();
            pla.Score = 2;

            List<PlayerForAnotherGame> playe = new List<PlayerForAnotherGame> { pla };



            Game<Player> game = new Game<Player>(players);
            Game<PlayerForAnotherGame> game2 = new Game<PlayerForAnotherGame>(playe);

            Player[] top = new Player[players.Count];
            top = game.GetTop10Players();
            PlayerForAnotherGame[] top2 = game2.GetTop10Players();

            foreach (var i in top)
            {

                Console.WriteLine(i.Score);
            }

            foreach (var i in top2)
            {
                
                Console.WriteLine(i.Score);
            }


        }
    }
}
