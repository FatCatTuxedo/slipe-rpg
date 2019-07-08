using System;
using System.Collections.Generic;
using System.Text;
using Slipe.Shared.Utilities;
using Slipe.Server.Game;

namespace ServerSide
{
    public class vJob
    {
        public int ID;
        public string Title;
        public mJob.jobType Type;
        public Color Color;
        public vTeam Team;
        public vJob(int id, string title, int type, int r, int g, int b, string team)
        {
            this.ID = id;
            this.Title = title;
            this.Type = (mJob.jobType)type;
            this.Team = mTeam.getTeamByName(team);
            Color color = new Color((byte)r, (byte)g, (byte)b);
            if (color == Color.Black)
            {
                Color = Team.Color;
            }
        }
    }
}
