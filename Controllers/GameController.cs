using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuessGame.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuessGame.Controllers
{
    [Route("api/Games")]
    [ApiController]
    public class GameController : ControllerBase
    {
        // GET: api/Games
        [HttpGet]
        public string GetGames()
        {
            var games = new GameDB();
            var result = games.GetAll();
            var listResult = new List<string>();
            //Convert array to string
            foreach (var item in result)
            {
                listResult.Add(item.ToString());
            }
            return string.Join(",", listResult.ToArray());
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public string GetGame(int id)
        {
            var games = new GameDB();
            var result = games.GetGame(id);
            return result == null ? "{The requested item doesn't exist in database}" : result.ToString();
        }
       

        // POST: api/Games
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }


        // PUT: api/Games/5
        [HttpPut("{id}")]
        public void Put(int id, IFormCollection value)
        {
            var userid = value["userid"];
            var text = value["drawText"];
            var actGame = new GameDB();
            actGame.Add(userid, text);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
