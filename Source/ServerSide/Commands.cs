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
using Slipe.Server.Peds.Events;

namespace ServerSide
{
    class Commands
    {
        public static void addCommands()
        {
            new CommandHandler("testing", HandleCommand);
        }
        public static void HandleCommand(Player player, string command, string[] arguments)
        {
            switch (command)
            {
                case "testing":
                    ChatBox.WriteLine("passed", player, Color.Azure);
                    break;
            }
        }
    }
}
