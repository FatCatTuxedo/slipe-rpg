
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
using System;
using System.Numerics;

namespace ServerSide
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
            
        }
        public Program()
        {
        mPlayer.Init();
            Vehicle fastboi = new Vehicle(VehicleModel.Cars.Banshee, new Vector3(0, 15, 3));
            Commands.addCommands();
        }

    }
}