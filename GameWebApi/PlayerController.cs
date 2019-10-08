using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GameWebApi
{
    [ApiController]
    [Route("Api/Players")]
    public class PlayerController : ControllerBase
    {
        private IRepository _repository;
        public PlayerController(IRepository repository)
        {

            _repository = repository;


        }

        [HttpGet("{id}")]
        public Task<Player> Get(Guid id) { return _repository.Get(id); }
        [HttpGet]
        public Task<Player[]> GetAll() { return _repository.GetAll(); }

        
        [HttpGet("withlevel")]
        public Task<Player[]> GetPlayerWithX(int x) { return _repository.GetPlayerWithX(x); }

        [HttpGet("withname")]
        public Task<Player> GetPlayerWithName(string name){return _repository.GetPlayerWithName(name);}


        [HttpPost]
        public Task<Player> Create(NewPlayer player)
        {

            

            Player newPlayer = new Player();

            newPlayer.Name = player.Name;

            newPlayer.Id = Guid.NewGuid();

            newPlayer.IsBanned = player.IsBanned;

            newPlayer.Level = player.Level;

            newPlayer.Score = player.Score;

           

            newPlayer.CreationTime = player.CreationTime;


            return _repository.Create(newPlayer);
        }

        [HttpPut("{id}")]
        public Task<Player> Modify(Guid id, ModifiedPlayer player) { return _repository.Modify(id, player); }
        [HttpDelete("{id}")]
        public Task<Player> Delete(Guid id) { return _repository.Delete(id); }

        [HttpGet("itemlevel")]
        public Task<Player[]> GetPlayerWithItemIn(int level){return _repository.GetPlayerWithItemIn(level);}

        [HttpGet("highscoreP")]
        public Task<Player[]> Get10PlayersWithHighScore(){return _repository.Get10PlayersWithHighScore();}


    }
}