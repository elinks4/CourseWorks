using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.IO;
using MongoDB.Driver;



namespace NewProjectTry
{
    public class MongoDbRepository : IRepository
    {
        private IMongoClient client;
        private IMongoDatabase database;

        public bool blackTurn = true;

        public List<string> nameList = new List<string>();



        public bool GameOn = true;


        public int blackScore = 0;
        public int whiteScore = 0;






        private IMongoCollection<Gameboard> boardcollection;

        public MongoDbRepository()
        {
            string connectionString = "mongodb://localhost:27017";

            client = new MongoClient(connectionString);
            database = client.GetDatabase("mongo");
            boardcollection = database.GetCollection<Gameboard>("boards");


        }

        public Task<Gameboard> Create(Gameboard board)
        {

            for (int i = 0; i < board.listOfCards.Count; i++)
            {

                nameList.Add(board.listOfCards[i].Name);
                board.listOfCards[i].Name = "?";
            }

            boardcollection.InsertOneAsync(board);
            return Task.FromResult(board);


        }



        public async Task<Gameboard> Get(Guid id)
        {
            var filter = Builders<Gameboard>.Filter.Eq(p => p.Id, id);
            var result = await boardcollection.Find(filter).FirstAsync();

            return result;

        }

        public async Task<Card[]> Getall(Guid gameId)
        {
            var filter = Builders<Gameboard>.Filter.Eq(p => p.Id, gameId);

            var board = await boardcollection.Find(filter).FirstAsync();

            return board.listOfCards.ToArray();
        }

        public async Task<string[]> GetPair(Guid gameId, int numberId, int secondId)
        {
            var filter = Builders<Gameboard>.Filter.Eq(p => p.Id, gameId);

            var board = await boardcollection.Find(filter).FirstAsync();

            var result = board.listOfCards.First(i => i.Id == numberId);

            var result2 = board.listOfCards.First(i => i.Id == secondId);

            int pairCards = 0;


            List<Card> pair = new List<Card>();
            List<Card> updatedpair = new List<Card>();
            List<string> returnable = new List<string>();



            pair.Add(result);
            pair.Add(result2);

            for (int i = 0; i < board.listOfCards.Count; i++)
            {

                board.listOfCards[i].Name = nameList[i];

                if (result.Id == board.listOfCards[i].Id)
                {

                    result.Name = board.listOfCards[i].Name;
                }
                if (result2.Id == board.listOfCards[i].Id)
                {
                    result2.Name = board.listOfCards[i].Name;
                }
            }


            if ((result.Id != result2.Id) && (result2.GotPair == false && result.GotPair == false) && (result.Name == result2.Name))
            {

                if (blackTurn)
                {
                    blackScore += 1;
                    blackTurn = false;

                }
                else if (blackTurn == false)
                {
                    whiteScore += 1;
                    blackTurn = true;
                }

                for (int i = 0; i < board.listOfCards.Count; i++)
                {

                    if (result.Id == board.listOfCards[i].Id || result2.Id == board.listOfCards[i].Id)
                    {





                        board.listOfCards[i].GotPair = true;

                        if (board.listOfCards[i].CardName() == "X")
                        {

                            board.listOfCards[i].Mark = "X";

                        }
                        else if (board.listOfCards[i].CardName() == "O")
                        {
                            board.listOfCards[i].Mark = "O";

                        }

                        updatedpair.Add(board.listOfCards[i]);
                    }
                }
            }

            for (int i = 0; i < board.listOfCards.Count; i++)
            {

                if (board.listOfCards[i].GotPair)
                {
                    pairCards += 1;
                }

            }

            if (pairCards >= 8)
            {
                GameOn = false;
            }


            var update = Builders<Gameboard>.Update.Set(p => p.listOfCards, board.listOfCards);
            var resulted = await boardcollection.UpdateOneAsync(filter, update);

            if (GameOn)
            {
                for (int i = 0; i < board.listOfCards.Count; i++)
                {

                    returnable.Add("Card " + (i + 1).ToString() + " Mark " + board.listOfCards[i].Mark.ToString() + " Id " + board.listOfCards[i].Id.ToString());
                    //  returnable.Add(board.listOfCards[i].Id.ToString());

                }



                string first = "First player has a score of: ";
                string sec = "Second player has a score of: ";

                returnable.Add(first);
                returnable.Add(blackScore.ToString());
                returnable.Add(sec);
                returnable.Add(whiteScore.ToString());

                returnable.Add("The Game is continuing ");

            }
            else
            {

                returnable.Add("The game has ended. ");

                if (blackScore > whiteScore)
                {
                    string winner = blackScore.ToString();
                    returnable.Add("The winner was the First player with a score of: " + winner);

                }
                else if (blackScore < whiteScore)
                {
                    string winner = whiteScore.ToString();
                    returnable.Add("The winner was the Second player with a score of: " + winner);

                }
                else
                {
                    string winner = whiteScore.ToString();
                    returnable.Add("The game was a draw with scores of: " + winner + " and " + winner);

                }
            }



            return returnable.ToArray();

        }








        public Task<string[]> GetScore(Guid gameid)
        {
            List<string> score = new List<string>();
            string first = "First player has ";
            string sec = "Second player has ";

            score.Add(first);
            score.Add(blackScore.ToString());
            score.Add(sec);
            score.Add(whiteScore.ToString());

            return Task.FromResult(score.ToArray());
        }


    }
}