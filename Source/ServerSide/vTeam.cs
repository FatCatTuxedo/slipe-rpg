using Slipe.Shared.Elements;
using Slipe.Server.Game;
using Slipe.MtaDefinitions;
using Slipe.Shared.Utilities;

namespace ServerSide
{
    public class vTeam : Team
    {
        public vTeam(string name, Color color) : base(name, color)
        {
            this.Name = name;
            this.Color = color;
        }
    }
}
