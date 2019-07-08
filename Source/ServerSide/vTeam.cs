using Slipe.Shared.Elements;
using Slipe.Server.Game;
using Slipe.MtaDefinitions;

namespace ServerSide
{
    [DefaultElementClass(ElementType.Team)]
    public class vTeam : Team
    {
        public vTeam(MtaElement element) : base(element)
        {

        }
    }
}
