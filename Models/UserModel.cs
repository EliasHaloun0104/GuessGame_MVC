using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuessGame.Models
{
    public class UserModel
    {
        private int userId;
        private string username;
        private string email;
        private string password;
        private string avatar;
        private DateTime lastAccess;
        private string accessToken;

        public UserModel(MySqlDataReader record)
        {
            this.userId = (int) record["userId"];
            this.username = (string) record["username"]; ;
            this.email = (string)record["email"]; ;
            this.password = (string)record["password"]; ;
            //this.avatar = (string)record["avatar"]; ;
            this.lastAccess = (DateTime)record["lastaccess"]; ;
            this.accessToken = (string)record["accesstoken"]; ;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }


        public int UserId { get => userId; set => userId = value; }
        [Key]
        public string Username { get => username; set => username = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Avatar { get => avatar; set => avatar = value; }
        public DateTime LastAccess { get => lastAccess; set => lastAccess = value; }
        public string AccessToken { get => accessToken; set => accessToken = value; }
    }
}
