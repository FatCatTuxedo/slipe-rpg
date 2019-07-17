using Slipe.Server.Peds;
using Slipe.Shared.Elements;
using System.Timers;
using Slipe.Server.IO;
using Slipe.Shared.Utilities;

namespace ServerSide
{
    public static class mPlayer
    {
        private static int autosave = 0;
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
        public static string HexCodeFromName(vPlayer p)
        {
            Color myColor = p.NametagColor;

            return myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");
        }
        public static void sendGlobalMessage(string type, string message)
        {
            switch (type)
            {
                case "staff":
                    foreach (vPlayer p in ElementManager.Instance.GetByType<Player>())
                    {
                        if (p.StaffLevel >= 1)
                        {
                            ChatBox.WriteLine(message, p, Color.White, true);
                        }
                    }
                break;
                    case "main":
                        ChatBox.WriteLine(message, Color.White, true);
                    break;
            }
        }

        private static void checkUsers()
        {
            try
            {
                foreach (vPlayer player in ElementManager.Instance.GetByType<Player>())
                {

                    if (player.loggedin)
                    {

                        if (player.needsRespawn)
                        {
                            player.respawnTimer += 1;
                            if (player.respawnTimer > 4)
                            {
                                player.respawnHosp();
                                player.needsRespawn = false;
                                player.respawnTimer = 0;
                            }
                        }
                        if (player.suicide)
                        {
                            player.suicideTimer += 1;
                            player.Frozen = true;
                            if (player.suicideTimer > 4)
                            {
                                player.doSuicide();
                                player.suicide = false;
                                player.suicideTimer = 0;
                            }
                        }
                    }
                }
            }
            catch { }
        }
    }
}
