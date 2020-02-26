using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessGame.Models
{
    public class ParticipentModel
    {
        int game_id;
        int user_id;
        float rate;

        public int Game_id { get => game_id; set => game_id = value; }
        public int User_id { get => user_id; set => user_id = value; }
        public float Rate { get => rate; set => rate = value; }
    }
}
