using System;
using System.Collections.Generic;
using System.Linq;


namespace Teht2
{
    public class Game<T> where T : IPlayer
    {


        private List<T> _players;

        public Game(List<T> players)
        {
            _players = players;
        }

        public T[] GetTop10Players()
        {


            T[] topPlayers;


            T[] array = _players.ToArray();

            Array.Sort<T>(array, new Comparison<T>((i1, i2) => i2.Score.CompareTo(i1.Score)));

            // T temp;


            /*          for (int i = 0; i < _players.Count - 1; i++)
                      {
                          for (int j = i + 1; i < _players.Count; j++)
                          {


                              if (_players[i].Score < _players[j].Score)
                              {

                                  temp = _players[i];
                                  _players[i] = _players[j];
                                  _players[j] = temp;



                              }


                          }
                      }


          */
            if (_players.Count >= 10)
            {

                topPlayers = new T[10];


                for (int i = 0; i < 10; i++)
                {

                    topPlayers[i] = array[i];



                }
            }

            else
            {

                topPlayers = new T[array.Length];

                for (int i = 0; i < array.Length; i++)
                {

                    topPlayers[i] = array[i];



                }


            }

            return topPlayers;

        }












    }
}