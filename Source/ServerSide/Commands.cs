using Slipe.Server.IO;
using Slipe.Server.Peds;
using Slipe.Shared.Utilities;
using System;
using Slipe.Shared.Exceptions;
using Slipe.Server.Vehicles;

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
            new CommandHandler("staff", HandleCommand);
            new CommandHandler("quitjob", HandleCommand);
            new CommandHandler("criminal", HandleCommand);
            new CommandHandler("gangster", HandleCommand);
        }
        public static void HandleCommand(Player player, string command, string[] arguments)
        {
            vPlayer p = (vPlayer)player;
            switch (command)
            {
                #region General Gameplay Commands
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
                #endregion

                #region Login Commands (will be removed once GUI is done)
                case "slogin":
                    _ = dbManager.AttemptLogin(player, arguments[0], arguments[1]);
                    break;
                case "sregister":
                    _ = dbManager.Register(player, arguments[0], arguments[1]);
                    break;
                #endregion

                #region Money related commands
                case "balance":
                    ChatBox.WriteLine("Your Bank Balance is: $" + p.BankBalance, player, Color.GreenYellow);
                    break;
                #endregion

                #region Job related commands
                case "quitjob":
                    p.quitJob();
                    break;
                case "criminal":
                    p.setJob("Criminal");
                    break;
                case "gangster":
                    p.setJob("Gangster");
                    break;
                #endregion

                #region Staff Commands
                case "staff":
                    if (Checking.hasStaffPermission(0.1f, p, "/staff"))
                    {
                        if (p.StaffLevel < 1 && p.StaffLevel > 0)
                        {
                            p.setJob("Helper");
                            p.Model = 217;
                        }
                        else
                        {
                            p.setJob("L" + p.StaffLevel + " Staff");
                            p.Model = 217;
                        }
                    }
                    break;
                case "setskin":
                    string[] syntax = { "player", "skinID" };
                    if (Checking.hasStaffPermission(1, p, "/setskin"))
                    {
                        try
                        {
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
                        catch (ArgumentOutOfRangeException) { Checking.processCommandError(p, "setskin", Checking.noSyntax, "Incorrect syntax."); }
                        catch (NullElementException e) { Checking.processCommandError(p, "setskin", Checking.noSyntax, e.Message); }
                    }
                    break;
                    #endregion
            }
        }
    }
}
