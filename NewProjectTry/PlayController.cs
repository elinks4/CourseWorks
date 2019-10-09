using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NewProjectTry
{

    [ApiController]
    [Route("Api/Game/{game}/play")] 
    public class PlayController : ControllerBase
    {
        private IRepository _repository;
        public PlayController(IRepository repository)
        {

            _repository = repository;


        }

        [HttpGet("score")]
        public Task<string[]> GetScore(Guid gameid) { return _repository.GetScore(gameid); }

        [HttpGet("all")]
        public Task<Card[]> Getall(Guid gameId) { return _repository.Getall(gameId); }

        [HttpPut("pair")]
        public Task<string[]> GetPair(Guid gameId, int numberId, int secondId) { return _repository.GetPair(gameId, numberId, secondId); }
    }
}