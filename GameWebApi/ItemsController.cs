using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GameWebApi
{

    [ApiController]
    [Route("Api/Players/{player}/items")]
    public class ItemsController : ControllerBase
    {



        private IRepository _repository;
        public ItemsController(IRepository repository)
        {

            _repository = repository;


        }



        [HttpGet("{id}")]
        public Task<Item> GetItem(Guid player, Guid id) { return _repository.GetItem(player, id); }





        [HttpGet]
        public Task<Item[]> GetAllItems(Guid player) { return _repository.GetAllItems(player); }

        [HttpPost]

        public async Task<Item> CreateItem(Guid player, NewItem item)
        {


            Player player1 = new Player();
            Item itemresult = new Item();

            try
            {

                player1 = await _repository.Get(player);





            }
            catch (NotFoundException e)
            {

                Console.WriteLine("Player Guid not found" + e);

            }

            if (player1.Level < 3 && item._type == NewItem.ItemType.SWORD)
            {

                throw new LevelException(player1.Name);

            }


            Guid guid = Guid.NewGuid();

            Console.WriteLine("Comes Here");

            Item origItem = new Item();

            origItem.Name = item.Name;

            origItem.Level = item.Level;

            origItem.Id = guid;

            origItem._type = item._type;//Item.ItemType.POTION;

            origItem.CreationTime = item.CreationTime;//System.DateTime.Now;



            player1.items.Add(origItem);

            itemresult = await _repository.CreateItem(player1.Id, origItem);

            player1.items.Add(itemresult);


            return origItem;
        }

        [HttpPut("{id}")]
        public Task<Item> ModifyItem(Guid player, Guid id, ModifiedItem item) { return _repository.ModifyItem(player, id, item); }


        [HttpDelete("{id}")]
        public Task<Item> DeleteItem(Guid player, Guid id) { return _repository.DeleteItem(player, id); }
    }








}
