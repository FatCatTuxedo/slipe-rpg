using Slipe.Server.Game;
using Slipe.Shared.Elements;
using Slipe.Shared.Utilities;

namespace ServerSide
{
    public static class mTeam
    {
        public static vTeam Staff;
        public static vTeam AuxStaff;
        public static vTeam Police;
        public static vTeam Civs;
        public static vTeam Criminals;
        public static vTeam Gangsters;

        public static void loadTeams()
        {
            Staff = new vTeam("Administrative Staff", Color.White);
            AuxStaff = new vTeam("Support Staff", Color.LimeGreen);
            Police = new vTeam("Police", new Color(30, 144, 255));
            Civs = new vTeam("Civilians", new Color(255, 215, 0));
            Gangsters = new vTeam("Gangsters", new Color(112, 13, 199));
            Criminals = new vTeam("Criminals", new Color(178, 34, 34));
           
        }

        public static vTeam getTeamByName(string name)
        {
            foreach (vTeam t in ElementManager.Instance.GetByType<Team>())
            {
                if (t.Name == name)
                {
                    return t;
                }
            }
            return null;
        }
    }
}
