using System;
using System.Threading.Tasks;

namespace NewProjectTry
{
    public interface IRepository
    {
        Task<Gameboard> Create(Gameboard game);

        Task<Gameboard> Get(Guid id);

        Task<string[]> GetPair(Guid gameId, int numberId, int secondId);

        Task<Card[]> Getall(Guid gameId);

        Task<string[]> GetScore(Guid gameid);

         
    }
}