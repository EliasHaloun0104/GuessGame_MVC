using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GuessGame.Database;
using GuessGame.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;


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
            var result = GetUsersList();
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
            var list = GetUsersList();
            foreach (var item in list)
            {
                if (item.UserId == id) return item.ToString();
            }
            return "{The requested item doesn't exist in database}";               
        }

        // POST: api/Users
        [HttpPost]
        public string AddUser(IFormCollection value)
        {
            var email = value["email"];
            var nickName = value["nickName"];
            var password = value["password"];
            var avatar = value["avatar"];
            var db = new DB_Connection();
            //open connection
            if (db.OpenConnection())
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(null, db.Connection);
                cmd.CommandText = "INSERT INTO users (username, email, password, avatar)" + "VALUES(@userName, @email, @password, @avatar)";

                var userNameParam = new MySqlParameter("@userName", MySqlDbType.VarChar, 45);
                userNameParam.Value = nickName;
                var emailParam = new MySqlParameter("@email", MySqlDbType.VarChar, 45);
                emailParam.Value = email;
                var passwordParam = new MySqlParameter("@password", MySqlDbType.VarChar, 45);
                passwordParam.Value = password;
                var avatarParam = new MySqlParameter("@avatar", MySqlDbType.VarChar, 30);
                avatarParam.Value = avatar;


                cmd.Parameters.Add(userNameParam);
                cmd.Parameters.Add(emailParam);
                cmd.Parameters.Add(passwordParam);
                cmd.Parameters.Add(avatarParam);

                // Call Prepare after setting the Commandtext and Parameters.
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //close connection
                db.CloseConnection();
            }




            return "New Users Added succesffully";
        }

        // PUT: api/User/5
        [HttpPut]
        public string AuthUser(IFormCollection value)
        {
            var email = value["signInEmail"];
            var password = value["signInPassword"];
            var db = new DB_Connection();
            if (db.OpenConnection())
            {

                string query = $"SELECT * FROM users WHERE email = '{email}' AND password = '{password}'";
                MySqlCommand cmd = new MySqlCommand(query, db.Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        var user = new UserModel(dataReader);
                        dataReader.Close();
                        db.CloseConnection();
                        return user.ToString();
                    }
                }

                //close Data Reader
                dataReader.Close();
                db.CloseConnection();

            }
            return "The User email or pass not exist or doesn't match";
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        //Middleware
        public List<UserModel> GetUsersList()
        {
            var db = new DB_Connection();
            List<UserModel> result = new List<UserModel>(); ;
            if (db.OpenConnection())
            {

                string query = "SELECT * FROM users";
                MySqlCommand cmd = new MySqlCommand(query, db.Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list

                while (dataReader.Read())
                {
                    var user = new UserModel(dataReader);
                    result.Add(user);
                }

                //close Data Reader
                dataReader.Close();
                db.CloseConnection();
            }
            return result;
        }
    }
}

