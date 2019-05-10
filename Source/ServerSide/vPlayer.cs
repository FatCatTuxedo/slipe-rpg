using Slipe.Server;
using Slipe.Server.Elements;
using Slipe.Server.IO;
using Slipe.Server.Peds;
using Slipe.Server.Vehicles;
using Slipe.Shared.Elements;
using Slipe.Shared.Utilities;
using Slipe.MtaDefinitions;
using System.Numerics;

namespace ServerSide
{
    [DefaultElementClass(ElementType.Player)]
    public class vPlayer : Player
    {
        public vPlayer(MtaElement element) : base(element)
        {
            // Spawn a player in Blueberry
            OnJoin += (Player p) =>
            {
                p.Spawn(new Vector3(0, 0, 5));
                p.Camera.Target = p;
                p.Camera.Fade(Slipe.Shared.Rendering.CameraFade.In);
            };
        }
    }
}
