
using Slipe.Server;
using Slipe.Server.Elements;
using Slipe.Server.GameServer;
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
            new ElementManager(new ElementHelper());
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
            Server.Log.WriteLine("Hello server");
            ChatBox.WriteLine("Hello world", 0xff00ff);
            Vehicle patriot = new Vehicle(VehicleModel.Patriot, new Vector3(0, 15, 3));
            patriot.Sirens.Add(new Vector3(-0.6f, 1, 0.5f), Color.Red, 200);
            patriot.Sirens.Add(new Vector3(0.6f, 1, 0.5f), new Color(0, 0, 255), 200);
            patriot.Sirens.On = true;
            patriot.Sirens.Silent = true;
            /*[[
            addEventHandler("onPlayerJoin", getRootElement(), function()
                local element = Slipe.Shared.Elements.ElementManager.getInstance():GetElement(source)
                this:Woopsie(element)
            end)
            ]]*/
        }
    }
}
