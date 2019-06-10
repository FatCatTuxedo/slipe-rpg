using Slipe.Server;
using Slipe.Server.Elements;
using Slipe.Server.IO;
using Slipe.Server.Peds;
using Slipe.Server.Vehicles;
using Slipe.Shared.Elements;
using Slipe.Shared.Weapons;
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
        public bool needsRespawn = false;
        public int respawnTimer = 0;
        public vPlayer(MtaElement element) : base(element)
        {
            OnSpawn += (Player source, OnSpawnEventArgs eventArgs) =>
            {
                Camera.Target = this;
                Camera.Fade(CameraFade.In);
            };

            OnWasted += (Ped source, OnWastedEventArgs eventArgs) =>
            {
                needsRespawn = true;
                respawnTimer = 0;
            };

            OnLogin += (Player source, OnLoginEventArgs eventArgs) =>
            {
                respawn();
                loadPlayerData();
            };

            OnLogout += (Player source, OnLogoutEventArgs eventArgs) =>
            {
                MtaServer.KickPlayer(this.element, "Console", "you logged out");
            };
        }
        public void loadPlayerData()
        {
            Money = 1234;
            GiveWeapon(SharedWeaponModel.CombatShotgun, 100);
            SetStat(PedStat.WeapontypeSpas12ShotgunSkill, 1000);
        }
        public void respawn()
        {
            Spawn(new Vector3(0, 0, 5), PedModel.cj);
            loadPlayerData();
            needsRespawn = false;
            respawnTimer = 0;
        }

    }
}
