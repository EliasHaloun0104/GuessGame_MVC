using System;
using System.Collections.Generic;
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
        private string lastAccess;
        private string accessToken;

        public int UserId { get => userId; set => userId = value; }
        public string Username { get => username; set => username = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Avatar { get => avatar; set => avatar = value; }
        public string LastAccess { get => lastAccess; set => lastAccess = value; }
        public string AccessToken { get => accessToken; set => accessToken = value; }
    }
}
