using Slipe.Server.Vehicles;
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
            mTeam.loadTeams();
            mJob.loadJobs();
        }

    }
}