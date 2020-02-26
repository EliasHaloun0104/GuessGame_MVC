using GuessGame.Database;
using GuessGame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GuessGame.Middleware
{
    public class UserMiddleware
    {
        public static List<UserModel> GetUsers()
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

        public static UserModel GetUser(int id)
        {
            var list = GetUsers();
            foreach (var item in list)
            {
                if (item.UserId == id) return item;
            }
            return null;
        }



        public static void AddNewUser(string email, string userName, string password, string avatar)
        {
            var db = new DB_Connection();
            //open connection
            if (db.OpenConnection())
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(null, db.Connection);
                cmd.CommandText = "INSERT INTO users (username, email, password, avatar)" + "VALUES(@userName, @email, @password, @avatar)";
                
                var userNameParam = new MySqlParameter("@userName", MySqlDbType.VarChar, 45);
                userNameParam.Value = userName;
                var emailParam = new MySqlParameter("@email", MySqlDbType.VarChar, 45);
                emailParam.Value = email;
                var passwordParam = new MySqlParameter("@password", MySqlDbType.VarChar, 45);
                passwordParam.Value = password;
                var avatarParam = new MySqlParameter("@avatar", MySqlDbType.VarChar, 30);
                avatarParam.Value = avatar;
                Console.WriteLine("WOO");

                
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

        }
    }
}
