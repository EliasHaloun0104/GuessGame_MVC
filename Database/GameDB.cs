﻿using GuessGame.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessGame.Database
{
    public class GameDB
    {
        public bool Add(string userid, string text)
        {
            var db = new DB_Connection();

            try
            {
                db.OpenConnection();
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(null, db.Connection);
                cmd.CommandText = "INSERT INTO activegame (userid, drawTexr)" + "VALUES(@uuserid, @drawText)";

                var userIdParam = new MySqlParameter("@userid", MySqlDbType.Int16, 45);
                userIdParam.Value = userid;
                var textParam = new MySqlParameter("@drawText", MySqlDbType.VarChar, 45);
                textParam.Value = text;
                


                cmd.Parameters.Add(userIdParam);
                cmd.Parameters.Add(textParam);
                
                // Call Prepare after setting the Commandtext and Parameters.
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //close connection
                db.CloseConnection();
                return true;

            }
            catch (MySqlException)
            {
                return false;
            }

        }

        public List<GameModel> GetAll()
        {
            var db = new DB_Connection();
            List<GameModel> result = new List<GameModel>();
            try
            {
                db.OpenConnection();
                string query = "SELECT * FROM games";
                MySqlCommand cmd = new MySqlCommand(query, db.Connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list

                while (dataReader.Read())
                {
                    var game = new GameModel(dataReader);
                    result.Add(game);
                }

                //close Data Reader
                dataReader.Close();
                db.CloseConnection();
                return result;

            }
            catch (MySqlException)
            {
                return null;
            }

        }

        public GameModel GetGame(int gameid)
        {
            var allGames = GetAll();
            foreach (var item in allGames)
            {
                if (gameid == item.Gameid) return item;
            }
            return null;
        }

    }
}
