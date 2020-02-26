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
            Debug.WriteLine("My debug string here");
            var email = value["email"];
            Debug.WriteLine(email);
            var nickName = value["nickName"];
            Debug.WriteLine(nickName);
            var password = value["password"];
            Debug.WriteLine(password);
            var avatar = value["avatar"];
            Debug.WriteLine(avatar);
            Debug.WriteLine("My debug string here");
            UserMiddleware.AddNewUser(email, nickName, password, avatar);
            return email +", "+ nickName + ", " + password + ", " + avatar;
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
