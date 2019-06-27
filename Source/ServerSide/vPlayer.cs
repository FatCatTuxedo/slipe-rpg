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
using Slipe.Server.Accounts;
using System.Timers;
using System;
using System.Data;
using Slipe.Sql;
using Slipe.Server.Peds.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerSide
{
    [DefaultElementClass(ElementType.Player)]
    public class vPlayer : Player
    {
        public bool needsRespawn = false;
        public int respawnTimer = 0;
        public int skin;
        public int BankBalance;
        public int StaffLevel;
        public bool loggedin;
        public Dictionary<string, int> inventory = new Dictionary<string, int>();
        public vPlayer(MtaElement element) : base(element)
        {
            OnJoin += (Player p, OnJoinEventArgs eventArgs) =>
            {
                loggedin = false;
                ChatBox.WriteLine("Please login with /slogin", p, Color.Orange);
            };
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

            OnQuit += (Player source, OnQuitEventArgs eventArgs) =>
            {
                saveData();
            };

        }
        public void saveData()
        {

        }
        public void loadPlayerData(int money, int sskin, int bank, int staff)
        {
            //set element data here for re-logging in after resource restart
            loggedin = true;
            skin = sskin;
            respawn();
            Money = money;
            BankBalance = bank;
            StaffLevel = staff;
            
        }
        public void respawn()
        {
            Spawn(new Vector3(0, 0, 5), (PedModel)skin);
            //load player weapons here
            needsRespawn = false;
            respawnTimer = 0;
        }
        public void suicide()
        {
            ChatBox.WriteLine("Goodbye cruel world.", this, Color.Red);
            Kill(this, Slipe.Shared.Weapons.SharedWeaponModel.Bomb, BodyPart.Head);
        }

    }
}
