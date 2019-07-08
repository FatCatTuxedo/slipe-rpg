using Slipe.Server.IO;
using Slipe.Server.Peds;
using Slipe.Shared.Utilities;
using System;
using Slipe.Shared.Exceptions;

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
            new CommandHandler("setskin", HandleCommand);
        }
        public static void HandleCommand(Player player, string command, string[] arguments)
        {
            vPlayer p = (vPlayer)player;
            switch (command)
            {
                case "kill":
                    if (p.suicide)
                    {
                        ChatBox.WriteLine("You cancelled your suicide.", player, Color.GreenYellow);
                        p.suicide = false;
                        p.suicideTimer = 0;
                        p.Frozen = false;
                    }
                    else if (Checking.playerOkToSuicide(p))
                    {
                        //add a check for already frozen
                        ChatBox.WriteLine("You will be killed in 5 seconds use /kill again to cancel.", player, Color.AquaMarine);
                        p.suicide = true;
                        p.suicideTimer = 0;
                    }
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
                case "setskin":
                    string[] syntax = { "player", "skinID" };
                    if (Checking.hasStaffPermission(1, p, "/setskin"))
                    {
                        try {
                           vPlayer target = (vPlayer)Player.GetFromName(arguments[0]);
                            int skin;
                            bool success = Int32.TryParse(arguments[1], out skin);
                            if (success)
                            {
                                if (Checking.isValidSkin(skin))
                                {
                                    target.skin = skin;
                                    target.Model = skin;
                                }
                                else
                                    Checking.processCommandError(p, command, syntax, "Invalid Skin");
                            }
                            else
                                Checking.processCommandError(p, command, syntax, "Invalid Skin");
                        }
                        catch(ArgumentOutOfRangeException) { Checking.processCommandError(p, "setskin", Checking.noSyntax, "Incorrect syntax."); }
                        catch(NullElementException e) { Checking.processCommandError(p, "setskin", Checking.noSyntax, e.Message); }
                    }
                break;
            }
        }
    }
}
