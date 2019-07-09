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

        public static async Task getJobs()
        {
            var results = await database.Query("SELECT * FROM jobs");
            foreach (var row in results)
            {
                mJob.Jobs.Add(row["title"], new vJob(row["id"], row["title"], row["type"], row["r"], row["g"], row["b"], row["team"]));
            }
        }
    }
}
