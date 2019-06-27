using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Slipe.Server.Peds;
using Slipe.Sql;
using Slipe.Shared.Cryptography;
using Slipe.Server.IO;

namespace ServerSide
{
    public static class dbManager
    {
        public static Database database = new Database(new MySqlConnectionString()
        {
            Hostname = "127.0.0.1",
            Port = 3306,
            DbName = "mta"
        }, "root", "fmjwaekx", new SqlOptions()
        {
            AutoReconnect = true
        });

        public static async Task AttemptLogin(Player player, string user, string pass)
        {
            vPlayer p = (vPlayer)player;
            int id;
            string username;
            string passhash = "";
            var results = await database.Query("SELECT * FROM users WHERE username = '" + user + "'");
            foreach (var row in results)
            {
                id = row["id"];
                username = row["username"];
                passhash = row["password"];
            }
            bool correct = await Bcrypt.Verify(pass, passhash);
            if (correct)
            {
                p.loadPlayerData(results[0]["money"], results[0]["skin"], results[0]["bank"], results[0]["staff_level"]);
                ChatBox.WriteLine("Welcome " + user, player, Slipe.Shared.Utilities.Color.Green);
            }
            else
            {
                ChatBox.WriteLine("Wrong login info.", player, Slipe.Shared.Utilities.Color.Red);
            }

        }
        public static async Task Register(Player player, string user, string pass)
        {
            var results = await database.Query("SELECT id FROM users WHERE username = ?", user);
            if (results.Length < 1)
            {
                    string password = await Bcrypt.Hash(pass);
                    database.Exec("INSERT INTO `users` (`username`, `password`) VALUES (?, ?)", user, password);
                    ChatBox.WriteLine( "done now /slogin", player, Slipe.Shared.Utilities.Color.Green);
            }
            else
            {
                ChatBox.WriteLine("That username has been taken.", player, Slipe.Shared.Utilities.Color.Red);
            }
        }
    }
}
