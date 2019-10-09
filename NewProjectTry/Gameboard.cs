using System;
using System.Collections.Generic;
using System.Linq;

namespace NewProjectTry
{
    public class Gameboard
    {
        public Guid Id { get; set; }

        public List<Card> listOfCards = new List<Card>();

        Deck deck = new Deck();



        public Gameboard()
        {

     

           

            listOfCards = new List<Card>();





        }
    }
}