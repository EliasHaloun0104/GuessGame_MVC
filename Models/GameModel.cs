using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessGame.Models
{
    public class GameModel
    {
        int gameid;
        int userid;
        string drawText;
        bool active;
        int winnerId;
        byte[] blob;


        public GameModel(MySqlDataReader record)
        {
            this.Gameid = (int)record["gameid"];
            this.Userid = (int)record["userid"];
            this.DrawText = (string)record["drawText"];
            this.Active = (bool)record["active"];
            this.WinnerId = Convert.IsDBNull(record["winnerId"]) ? -1: (int)record["winnerId"];
            this.Blob = Convert.IsDBNull(record["img"]) ? null : (byte[])record["img"];
        }

        public int Gameid { get => gameid; set => gameid = value; }
        public int Userid { get => userid; set => userid = value; }
        public string DrawText { get => drawText; set => drawText = value; }
        public bool Active { get => active; set => active = value; }
        public int WinnerId { get => winnerId; set => winnerId = value; }
        public byte[] Blob { get => blob; set => blob = value; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
            //return DrawText;
        }

    }
}
