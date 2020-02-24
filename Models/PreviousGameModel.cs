using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessGame.Models
{
    public class PreviousGameModel
    {
        int game_id;
        int user_id;
        string draw_txt;
        string canvas_data;

        public int Game_id { get => game_id; set => game_id = value; }
        public int User_id { get => user_id; set => user_id = value; }
        public string Draw_txt { get => draw_txt; set => draw_txt = value; }
        public string Canvas_data { get => canvas_data; set => canvas_data = value; }
    }
}
