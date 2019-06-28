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
        public int accountID;
        public bool needsRespawn = false;
        public int respawnTimer = 0;
        public int skin;
        public int BankBalance;
        public int StaffLevel;
        public bool loggedin;
        public bool combatTag = false;
        public bool suicide = false;
        public int suicideTimer = 0;
        public Dictionary<string, int> inventory = new Dictionary<string, int>();
        public vPlayer(MtaElement element) : base(element)
        {
            OnJoin += (Player p, OnJoinEventArgs eventArgs) =>
            {
                loggedin = false;
                ChatBox.WriteLine("Please login with /slogin", p, Color.Orange);
                p.SetHudComponentVisible(HudComponent.area_name, false);
                p.SetHudComponentVisible(HudComponent.vehicle_name, false);
                p.NametagColor = Color.Black;
                p.BlurLevel = 0;
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
                if (loggedin)
                {
                saveData();
                }
            };

        }
        public void saveData()
        {
            dbManager.database.Exec("UPDATE users SET (skin, money, bank, staff_level, x, y, z, rot, dim, int) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?) WHERE id = ?", skin, Money, BankBalance, StaffLevel, Position.X, Position.Y, Position.Z, Rotation, Dimension, Interior, accountID);
        }
        public void loadPlayerData(int money, int sskin, int bank, int staff, int dim, int i, float x, float y, float z, int rot)
        {
            //set element data here for re-logging in after resource restart
            loggedin = true;
            skin = sskin;
            respawn(dim, i, x, y, z, rot);
            Money = money;
            BankBalance = bank;
            StaffLevel = staff;
            
        }
        public void respawn(int dim, int i, float x, float y, float z, int rot)
        {
            Spawn(new Vector3(x, y, z), (PedModel)skin, rot, i, dim);
            //load player weapons here
            needsRespawn = false;
            respawnTimer = 0;
            Frozen = false;
        }
        public void respawnHosp()
        {
            Spawn(new Vector3(0, 0, 5), (PedModel)skin);
            needsRespawn = false;
            respawnTimer = 0;
        }
        public void doSuicide()
        {
            Kill(this, Slipe.Shared.Weapons.SharedWeaponModel.Bomb, BodyPart.Head);
            suicide = false;
            suicideTimer = 0;
        }

    }
}
