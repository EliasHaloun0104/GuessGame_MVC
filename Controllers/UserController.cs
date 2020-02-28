using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GuessGame.Database;
using GuessGame.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuessGame.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/Users
        [HttpGet]
        public string GetUsers()
        {
            var result = UserMiddleware.GetUsers();
            var listResult = new List<string>();
            foreach (var item in result)
            {
                listResult.Add(item.ToString());
            }
            return string.Join(",",listResult.ToArray());
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public string GetUser(int id)
        {
            try
            {
                return UserMiddleware.GetUser(id).ToString();
            }
            catch (NullReferenceException)
            {
                return "{The requested item doesn't exist in database}";
            }      
            
        }

        // POST: api/Users
        [HttpPost]
        public string AddUser(IFormCollection value)
        {
            var email = value["email"];
            var nickName = value["nickName"];
            var password = value["password"];
            var avatar = value["avatar"];
            UserMiddleware.AddNewUser(email, nickName, password, avatar);
            return "New Users Added succesffully";
        }

        // PUT: api/User/5
        [HttpPut]
        public string AuthUser(IFormCollection value)
        {
            var email = value["signInEmail"];
            var password = value["signInPassword"];
            return UserMiddleware.AuthUser(email, password).ToString();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
