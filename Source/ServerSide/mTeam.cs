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
            Teams.Add("Police", new vTeam("Police", new Color(30, 144, 255)));
            Teams.Add("Civs", new vTeam("Civilians", new Color(255, 215, 0)));
            Teams.Add("Gangsters", new vTeam("Gangsters", new Color(112, 13, 199))); 
            Teams.Add("Criminals", new vTeam("Criminals", new Color(178, 34, 34)));
        }

    }
}
