using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessGame.Models
{
    public class Data
    {
        int users;
        int games;

        public Data(int users, int games)
        {
            this.Users = users;
            this.Games = games;
        }

        public int Users { get => users; set => users = value; }
        public int Games { get => games; set => games = value; }
    }
}
