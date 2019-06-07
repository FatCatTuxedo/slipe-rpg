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
using System.Timers;
using System;
using Slipe.Server.Peds.Events;

namespace ServerSide
{
    [DefaultElementClass(ElementType.Player)]
    public class vPlayer : Player
    {
        int timer = 0;
        public vPlayer(MtaElement element) : base(element)
        {
            OnSpawn += (Player source, OnSpawnEventArgs eventArgs) =>
            {
                Camera.Target = this;
                Camera.Fade(CameraFade.In);
            };

            OnWasted += (Ped source, OnWastedEventArgs eventArgs) =>
            {
                timer = 0;
                Timer aTimer = new Timer(1000);
                aTimer.Elapsed += OnRespawnTimer;
                aTimer.Enabled = true;
                //respawn();
            };
        }
        public void OnRespawnTimer(Object source, ElapsedEventArgs e)
        {
            timer++;
            if (timer >= 5)
            {
                
                Timer t = (Timer)source;
                respawn();
                t.Enabled = false;
            }
        }
        public void respawn()
        {
            Spawn(new Vector3(0, 0, 5), PedModel.cj);
        }

    }
}
