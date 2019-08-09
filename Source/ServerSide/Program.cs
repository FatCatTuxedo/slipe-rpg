using Slipe.Server.Vehicles;
using System.Numerics;
using Slipe.Server.Resources;
using Slipe.Server.Peds;
using Slipe.Shared.Elements;
using Slipe.Server.IO;
using Slipe.Server.Elements;
using Slipe.Shared.Utilities;
using Slipe.Shared.Peds;
using System.Collections.Generic;
using Slipe.Server.Rpc;
using System.Text;

namespace ServerSide
{
    class Program
    {
        public static Resource dx;
        static void Main(string[] args)
        {
            new Program();

        }
        public Program()
        {
            RpcManager.Instance.RegisterRPC<LoginRpc>("xoaLogin", HandleTestRPC);
            //HandlingManager.loadHandling();
            mPlayer.Init();
            Commands.addCommands();
            mTeam.loadTeams();
            mJob.loadJobs();
            
            HandleRestart();
            Resource.Get("XoaLUA-SkinMods").Start();
            Resource.Get("XoaLUA-StaffMisc").Start();
            Resource.Get("XoaLUA-WepDamage").Start();
            Resource.Get("XoaLUA-MapFixes").Start();
            Resource.Get("XoaLUA-Speaker").Start();
            Resource.Get("XoaLUA-Sirens").Start();
            Resource.Get("XoaLUA-Blips").Start();
            dx = Resource.Get("XoaLuadx");
            dx.Start();
        }


        public void HandleTestRPC(Player p, LoginRpc arguments)
        {
            _ = dbManager.AttemptLogin(p, arguments.username, arguments.password);
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
                        Slipe.MtaDefinitions.MtaServer.KickPlayer(player.MTAElement, "Xoa", "System restarted but you were not logged in.");

                    }
                }
                catch
                {
                    Slipe.MtaDefinitions.MtaServer.KickPlayer(player.MTAElement, "Xoa", "System restarted but you were not logged in.");
                }
            }

        }
        public static string wrapParameters(string[] s, int startIndex)
        {
            StringBuilder sb = new StringBuilder();
            {
                for (int i = startIndex; i < s.Length; i++)
                    sb.Append(" " + s[i]);

                return sb.ToString().Substring(1);
            }
        }
    }
}