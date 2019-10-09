using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewProjectTry
{
    
    public class Deck
    {

        

     

        public Card[] MakeDeck()
        {
            List<Card> list = new List<Card>();

            Card X1 = new Card(1);
            X1.Mark = "?";
            
            X1.GotPair = false;
            list.Add(X1);

            Card X2 = new Card(1);
            X2.Mark = "?";
            X2.GotPair = false;
            X2.Id = 1;
            list.Add(X2);

            Card X3 = new Card(1);
            X3.Mark = "?";
            X3.GotPair = false;
            X3.Id = 2;
            list.Add(X3);

            Card X4 = new Card(1);
            X4.Mark = "?";
            X4.GotPair = false;
            list.Add(X4);

            Card O1 = new Card(2);
            O1.Mark = "?";
            O1.GotPair = false;
            list.Add(O1);

            Card O2 = new Card(2);
            O2.Mark = "?";
            O2.GotPair = false;
            list.Add(O2);

            Card O3 = new Card(2);
            O3.Mark = "?";
            O3.GotPair = false;
            list.Add(O3);

            Card O4 = new Card(2);
            O4.Mark = "?";
            O4.GotPair = false;
            list.Add(O4);

            List<int> random1 = new List<int>();


            for (int i = 0; i < list.Count; i++)
            {

                Random rnd = new Random();
                int number = rnd.Next(1, 9);
                random1.Add(number);
            }

            List<int> onlyOneId = random1.Distinct().ToList();
            List<int> newL = new List<int>();


            if (onlyOneId.Count != random1.Count)
            {

                while (onlyOneId.Count != random1.Count)
                {

                    Random rnd = new Random();
                    int number = rnd.Next(1, 9);
                    onlyOneId.Add(number);
                    newL = onlyOneId.Distinct().ToList();
                    onlyOneId = newL;

                }

            }

            for (int i = 0; i < list.Count; i++)
            {

                list[i].Id = onlyOneId[i];
            }

            List<Card> returnable = list.OrderBy(x => x.Id).ToList();


          


            return returnable.ToArray();
        }




    }
}