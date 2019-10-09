using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NewProjectTry
{

    [ApiController]
    [Route("Api/Game")]
    public class GameboardController : ControllerBase
    {
        private IRepository _repository;
        public GameboardController(IRepository repository)
        {

            _repository = repository;


        }



        [HttpPost]
        public Task<Gameboard> Create(NewGameboard game)
        {



            Gameboard newgame = new Gameboard();


            newgame.Id = Guid.NewGuid();

            Deck deck = new Deck();

            Card[] array = deck.MakeDeck();

            newgame.listOfCards = array.ToList();






            return _repository.Create(newgame);
        }


        [HttpGet("{id}")]
        public Task<Gameboard> Get(Guid id) { return _repository.Get(id); }
    
    
      





    }
}