using Slipe.Server;
using Slipe.Server.Elements;
using Slipe.Server.IO;
using Slipe.Server.Peds;
using Slipe.Server.Vehicles;
using Slipe.Shared.Elements;
using Slipe.Shared.Utilities;
using Slipe.Server.Accounts;
using Slipe.MtaDefinitions;
using System.Numerics;
using Slipe.Server.Game;
using Slipe.Shared.Peds;
using Slipe.Shared.Rendering;
using System.Timers;
using System;
using Slipe.Server.Peds.Events;
using System.Threading.Tasks;

namespace ServerSide
{
    class Commands
    {
        public static void addCommands()
        {
            new CommandHandler("kill", HandleCommand);
            new CommandHandler("slogin", HandleCommand);
            new CommandHandler("sregister", HandleCommand);
            new CommandHandler("balance", HandleCommand);
        }
        public static void HandleCommand(Player player, string command, string[] arguments)
        {
            vPlayer p = (vPlayer)player;
            switch (command)
            {
                case "kill":
                    p.suicide();
                    break;
                case "slogin":
                    _ = dbManager.AttemptLogin(player, arguments[0], arguments[1]);
                    break;
                case "sregister":
                    _ = dbManager.Register(player, arguments[0], arguments[1]);
                    break;
                case "balance":
                    ChatBox.WriteLine("Your Bank Balance is: $" + p.BankBalance, player, Color.GreenYellow);
                    break;
            }
        }
    }
}
