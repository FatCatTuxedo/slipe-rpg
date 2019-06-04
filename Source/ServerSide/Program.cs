
using Slipe.Server;
using Slipe.Server.Elements;
using Slipe.Server.Game;
using Slipe.Server.IO;
using Slipe.Server.Peds;
using Slipe.Server.Peds.Events;
using Slipe.Server.Vehicles;
using Slipe.Shared.Elements;
using Slipe.Shared.Utilities;
using Slipe.Sql;
using System.Numerics;

namespace ServerSide
{
    class Program
    {
        Database database = new Database(new MySqlConnectionString()
        {
            Hostname = "127.0.0.1",
            Port = 3306,
            DbName = "mta"
        }, "root", "toor", new SqlOptions()
        {
            AutoReconnect = true
        });
        static void Main(string[] args)
        {
            new Program();
            
        }
        public Program()
        {
            Vehicle fastboi = new Vehicle(VehicleModel.Cars.Banshee, new Vector3(0, 15, 3));
            // Spawn a player in Blueberry
            Player.OnJoin += (Player p, OnJoinEventArgs eventArgs) => p.Spawn(new Vector3(0, 0, 5), Slipe.Shared.Peds.PedModel.cj);
        }
    }
}
