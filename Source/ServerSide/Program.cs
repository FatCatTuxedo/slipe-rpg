
using Slipe.Server;
using Slipe.Server.Elements;
using Slipe.Server.Game;
using Slipe.Server.IO;
using Slipe.Server.Peds;
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
        }, "root", "fmjwaekx", new SqlOptions()
        {
            AutoReconnect = true
        });
        static void Main(string[] args)
        {
            new Program();
            
        }
        public void Woopsie(Player player)
        {
            player.Spawn(new Vector3(1, 17, 3));
            player.Camera.Fade(Slipe.Shared.Rendering.CameraFade.In);
            player.Camera.Target = player;
        }
        public Program()
        {
            Vehicle patriot = new Vehicle(VehicleModel.Tug, new Vector3(0, 15, 3));
            // Spawn a player in Blueberry
            Player.OnJoin += (Player p) =>
            {
                p.Spawn(new Vector3(0, 0, 5));
            };
        }
    }
}
