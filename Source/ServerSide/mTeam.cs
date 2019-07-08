using System;
using System.Collections.Generic;
using System.Text;
using Slipe.MtaDefinitions;
using Slipe.Server.Game;
using Slipe.Shared.Utilities;

namespace ServerSide
{
    public static class mTeam
    {
        public static vTeam Staff = (vTeam)new Team("Staff", Color.White);
        public static vTeam AuxStaff = (vTeam)new Team("Auxiliary Staff", Color.GreenYellow);
        public static vTeam Police = (vTeam)new Team("Police", Color.LightBlue);
        public static vTeam Civs = (vTeam)new Team("Civilians", Color.Yellow);
        public static vTeam Criminals = (vTeam)new Team("Criminals", Color.Red);
        public static vTeam Gangsters = (vTeam)new Team("Gangsters", Color.Purple);
    }
}
