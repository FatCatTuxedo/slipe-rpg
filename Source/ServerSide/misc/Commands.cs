using Slipe.Server.IO;
using Slipe.Server.Peds;
using Slipe.Shared.Utilities;
using System;
using Slipe.Shared.Exceptions;
using Slipe.Server.Vehicles;
using Slipe.Server.Elements;
using Slipe.Shared.Elements;
using ServerSide.misc;

namespace ServerSide
{
    class Commands
    {
        public static string[] commandList =
        {
            "kill",
            "slogin",
            "sregister",
            "balance",
            "setskin",
            "staff",
            "staffg",
            "quitjob",
            "criminal",
            "gangster",
            "checkitems",
            "savedata",
            "xc",
            "main",
            "police",
            "medic"
        };
        public static void addCommands()
        {
            foreach (string cmd in commandList)
            {
                new CommandHandler(cmd, HandleCommand);
            }
        }
        public static void HandleCommand(Player player, string command, string[] arguments)
        {
            vPlayer p = (vPlayer)player;
            switch (command)
            {
                #region temp commands
                case "checkitems":
                    p.editMoney(-100);
                    break;
                #endregion

                #region Chat
                    case "main":
                        mPlayer.sendGlobalMessage("main", "#" + mPlayer.HexCodeFromName(p) + "(" + Utils.getCityCode(p) + ") " + p.Name + ": #FFFFFF" + String.Join("", arguments));
                    break;
                    case "xc":
                    if (Checking.hasStaffPermission(0.1f, p, "/xc"))
                    {
                        mPlayer.sendGlobalMessage("staff", "#" + mPlayer.HexCodeFromName(p) + "(STAFF) " + p.Name + ": #FFFFFF" + String.Join("", arguments));
                    }
                    break;
                #endregion

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
                    Program.dx.Invoke("shout", p.MTAElement, "You are now a criminal", 255, 0, 0);
                    break;
                case "gangster":
                    p.setJob("Gangster");
                    break;
                case "police":
                    p.setJob("Police Officer");
                    break;
                case "medic":
                    p.setJob("Paramedic");
                    break;
                #endregion

                #region Staff Commands
                case "staff":
                    if (Checking.hasStaffPermission(1, p, "/staff"))
                    {
                        p.setJob("L" + p.StaffLevel + " Staff");
                            p.Model = 217;
                    }
                    break;
                case "staffg":
                    if (Checking.hasStaffPermission(1, p, "/staffg"))
                    {
                            p.setJob("L" + p.StaffLevel + " Staff");
                            p.Model = 211;
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
