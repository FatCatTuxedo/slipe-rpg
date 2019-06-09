using Slipe.Server;
using Slipe.Server.Elements;
using Slipe.Server.IO;
using Slipe.Server.Peds;
using Slipe.Server.Vehicles;
using Slipe.Shared.Elements;
using Slipe.Shared.Utilities;
using Slipe.MtaDefinitions;
using System.Numerics;
using Slipe.Server.Game;
using Slipe.Shared.Peds;
using Slipe.Shared.Rendering;
using System.Timers;
using System;
using System.Data;
using Slipe.Server.Peds.Events;
using System.Collections;

namespace ServerSide
{
    public static class mPlayer
    {
        private static Timer userChecker;
        public static void Init()
        {
            userChecker = new Timer(1000);
            userChecker.Elapsed += (object source, ElapsedEventArgs args) =>
            {
                checkUsers();
            };
            userChecker.AutoReset = true;
            userChecker.Start();
        }

        private static void checkUsers()
        {
            try
            {
                foreach (vPlayer player in ElementManager.Instance.GetByType<Player>())
                {

                    if (!player.Account.IsGuestAccount)
                    {
                        if (player.needsRespawn)
                        {
                            player.respawnTimer += 1;
                            if (player.respawnTimer > 4)
                                player.respawn();
                        }
                    }
                }
            }
            catch { }
        }
    }
}
