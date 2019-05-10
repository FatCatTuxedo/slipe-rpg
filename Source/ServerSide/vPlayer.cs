using Slipe.Server;
using Slipe.Server.Elements;
using Slipe.Server.IO;
using Slipe.Server.Peds;
using Slipe.Server.Vehicles;
using Slipe.Shared.Elements;
using Slipe.Shared.Utilities;
using Slipe.MtaDefinitions;
using System.Numerics;
using Slipe.Server.Game;
using Slipe.Shared.Peds;
using Slipe.Shared.Rendering;

namespace ServerSide
{
    [DefaultElementClass(ElementType.Player)]
    public class vPlayer : Player
    {
        public vPlayer(MtaElement element) : base(element)
        {
            this.OnSpawn += (Vector3 position, float rotation, Team team, PedModel model, int interior, int dimension) =>
            {
                this.Camera.Target = this;
                this.Camera.Fade(CameraFade.In);
            };
        }
    }
}
