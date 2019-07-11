using System.Threading.Tasks;
using Slipe.Server.Peds;
using Slipe.Sql;
using Slipe.Shared.Cryptography;
using Slipe.Server.IO;
using System;

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
                id = results[0]["id"];
                username = results[0]["username"];
                passhash = results[0]["password"];
            bool correct = await Bcrypt.Verify(pass, passhash);
            if (correct)
            {
                p.accountID = id;
                p.loadPlayerData(results[0]["money"], results[0]["skin"], results[0]["bank"], results[0]["staff_level"], results[0]["dim"], results[0]["int"], results[0]["x"], results[0]["y"], results[0]["z"], results[0]["rot"]);
                ChatBox.WriteLine("Welcome " + user, player, Slipe.Shared.Utilities.Color.Green);
            }
            else
            {
                ChatBox.WriteLine("Wrong login info.", player, Slipe.Shared.Utilities.Color.Red);
            }

        }
        public static async Task AttemptPlayerRelog(Player player, int id)
        {
            
            vPlayer p = (vPlayer)player;
            var results = await database.Query("SELECT * FROM users WHERE id = '" + id + "'");
            id = results[0]["id"];
                p.accountID = id;
                p.loadPlayerData(results[0]["money"], results[0]["skin"], results[0]["bank"], results[0]["staff_level"], results[0]["dim"], results[0]["int"], results[0]["x"], results[0]["y"], results[0]["z"], results[0]["rot"]);
                ChatBox.WriteLine("Welcome " + (string)results[0]["username"], player, Slipe.Shared.Utilities.Color.Green);
            

        }
        public static async Task Register(Player player, string user, string pass)
        {
            var results = await database.Query("SELECT id FROM users WHERE username = ?", user);
            if (results.Length < 1)
            {
                    string password = await Bcrypt.Hash(pass);
                    database.Exec("INSERT INTO `users` (`username`, `password`) VALUES (?, ?)", user, password);
                    var results2 = await database.Query("SELECT id FROM users WHERE username = ?", user);
                await AttemptPlayerRelog(player, results2[0]["id"]);
            }
            else
            {
                ChatBox.WriteLine("That username has been taken.", player, Slipe.Shared.Utilities.Color.Red);
            }
        }

        public static async Task getJobs()
        {
            var results = await database.Query("SELECT * FROM jobs");
            foreach (var row in results)
            {
                mJob.Jobs.Add(row["title"], new vJob(row["id"], row["title"], row["type"], row["r"], row["g"], row["b"], row["team"]));
            }
        }

        public static async Task getHandling()
        {
            var results = await database.Query("SELECT * FROM custom_handling");
            foreach (var row in results)
            {

                
                try {
                HandlingManager.HandlingList.Add(row["id"], new CustomHandling(row["id"], row["vehicle"], row["mass"], row["turnmass"], row["dragCoeff"], row["CentMassX"], row["CentMassY"], row["CentMassZ"], row["persub"], row["tmult"], row["tloss"], row["tbias"], row["gears"], row["maxvel"], row["enga"], row["engi"], row["dtype"], row["etype"], row["breakd"], row["breakbias"], row["steerlock"], row["sfl"], row["sd"], row["shsd"], row["sul"], row["sll"], row["sfrb"], row["sadm"], row["sosd"], row["cdm"]));
                }
                catch { ChatBox.WriteLine("error with handling list", Slipe.Shared.Utilities.Color.Red); }
                
            }
        }
    }
}
