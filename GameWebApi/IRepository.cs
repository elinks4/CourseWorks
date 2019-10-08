using System;
using System.Threading.Tasks;

namespace GameWebApi
{
    public interface IRepository
    {
        Task<Player> Get(Guid id);
        Task<Player[]> GetAll();
        Task<Player> Create(Player player);
        Task<Player> Modify(Guid id, ModifiedPlayer player);
        Task<Player> Delete(Guid id);
        Task<Item> CreateItem(Guid player,Item playerItem);


        Task<Item> DeleteItem(Guid player,Guid id);

        Task<Item> GetItem(Guid player,Guid id);

        Task<Item[]> GetAllItems(Guid player);

       Task<Item> ModifyItem(Guid player,Guid id, ModifiedItem item);

        Task<Item> UpdateItem(Guid player,Guid id, Item item);

        Task<Player[]> GetPlayerWithX(int x);

        Task<Player> GetPlayerWithName(string name);

        Task<Player[]> GetPlayerWithItemIn(int level);

        Task<Player[]> Get10PlayersWithHighScore();

     




    }
}