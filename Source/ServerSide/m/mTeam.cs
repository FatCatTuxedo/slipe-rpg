using Slipe.Server.Game;
using Slipe.Shared.Elements;
using Slipe.Shared.Utilities;
using System.Collections.Generic;
namespace ServerSide
{
    public static class mTeam
    {
        public static Dictionary<string, vTeam> Teams;

        public static void loadTeams()
        {
            Teams = new Dictionary<string, vTeam>();
            Teams.Add("Staff", new vTeam("Administrative Staff", Color.White));
            Teams.Add("AuxStaff", new vTeam("Support Staff", Color.LimeGreen));
            Teams.Add("USMS", new vTeam("U.S. Marshals Service", new Color(150, 150, 150)));
            Teams.Add("SP", new vTeam("State Police", new Color(185, 175, 120)));
            Teams.Add("Police", new vTeam("Police Department", new Color(30, 125, 255)));
            Teams.Add("EMS", new vTeam("Fire Department", new Color(30, 255, 125)));
            Teams.Add("Civs", new vTeam("Civilians", new Color(255, 200, 0)));
            Teams.Add("Gangsters", new vTeam("Gangsters", new Color(112, 13, 199)));
            Teams.Add("Criminals", new vTeam("Criminals", new Color(175, 25, 25)));
        }

    }
}