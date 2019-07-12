using Slipe.Server.Vehicles;
using System.Numerics;
using Slipe.Server.Resources;
using Slipe.Server.Peds;
using Slipe.Shared.Elements;
using Slipe.Server.IO;
using Slipe.Shared.Utilities;
using Slipe.Shared.Peds;
using System.Collections.Generic;

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
            //HandlingManager.loadHandling();
            mPlayer.Init();
            Commands.addCommands();
            mTeam.loadTeams();
            mJob.loadJobs();
            
            HandleRestart();
            
        }

        private void HandleRestart()
        {
            foreach (vPlayer player in ElementManager.Instance.GetByType<Player>())
            {
                try
                {
                    var accid = Slipe.MtaDefinitions.MtaShared.GetElementData(player.MTAElement, "accountid", false);
                    if (accid && accid > 0)
                    {
                        dbManager.AttemptPlayerRelog(player, accid);
                    }
                    else
                    {
                        Slipe.MtaDefinitions.MtaServer.KickPlayer(player.MTAElement, "Xoa", "Resource restarted but you were not logged in.");

                    }
                }
                catch
                {
                    Slipe.MtaDefinitions.MtaServer.KickPlayer(player.MTAElement, "Xoa", "Resource restarted but you were not logged in.");
                }
            }

        }
    }
}