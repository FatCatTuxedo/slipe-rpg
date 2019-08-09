using Slipe.Server.IO;
using Slipe.Server.Peds;
using Slipe.Shared.Elements;
using Slipe.Shared.Utilities;
using Slipe.MtaDefinitions;
using System.Numerics;
using Slipe.Shared.Peds;
using Slipe.Shared.Rendering;
using Slipe.Server.Peds.Events;
using System.Collections.Generic;
using Slipe.Server.Events;

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
        public float StaffLevel;
        public bool loggedin;
        public bool combatTag = false;
        public bool suicide = false;
        public int suicideTimer = 0;
        public vJob Job;
        public Dictionary<string, PlayerItem> Inventory;
        public vPlayer(MtaElement element) : base(element)
        {
            OnJoin += (Player p, OnJoinEventArgs eventArgs) =>
            {
                loggedin = false;
                p.SetHudComponentVisible(HudComponent.area_name, false);
                p.SetHudComponentVisible(HudComponent.vehicle_name, false);
                p.SetHudComponentVisible(HudComponent.radar, false);
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
            //dbManager.database.Exec("UPDATE users SET (skin, money, bank, staff_level, x, y, z, rot, dim, int, job) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?) WHERE id = ?;", skin, Money, BankBalance, StaffLevel, Position.X, Position.Y, Position.Z, Rotation, Dimension, Interior, Job.Title, accountID);
            dbManager.database.Exec("UPDATE `users` SET `skin` = ?, `money`=?, `bank` = ?, `staff_level` = ?, `x` = ?, `y` = ?, `z` = ?, `rot` = ?, `dim` = ?, `int` = ?, `job` = ? WHERE `id` = ?", skin, Money, BankBalance, StaffLevel, Position.X, Position.Y, Position.Z, Rotation.Z, Dimension, Interior, Job.ID, accountID);
        }
        public void loadPlayerData(int money, int sskin, int bank, float staff, int dim, int i, float x, float y, float z, float rot, int job)
        {
            //set element data here for re-logging in after resource restart
            loggedin = true;
            Slipe.MtaDefinitions.MtaShared.SetElementData(this.element, "accountid", accountID, true);
            skin = sskin;
            respawn(dim, i, x, y, z, (int)rot);
            Money = money;
            BankBalance = bank;
            StaffLevel = staff;
            setJobviaID(job);
            Inventory = new Dictionary<string, PlayerItem>();
            _ = dbManager.getPlayerItems(this);
            this.SetHudComponentVisible(HudComponent.radar, true);
            if (accountID == 1)
            {
                this.Login(Slipe.Server.Accounts.Account.Get("Ariana"), "ariana123");
            }
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

        public void setJob(string job)
        {
            
            this.Job = mJob.Jobs[job];
            this.NametagColor = Job.Color;
            this.Team = Job.Team;
            this.SetData("o", Job.Title, true);
            Program.dx.Invoke("add", this.MTAElement, "job", Job.Title, Job.Color.R, Job.Color.G, Job.Color.B);
        }
        public void setJobviaID(int job)
        {

            this.Job = mJob.getJobfromID(job);
            this.NametagColor = Job.Color;
            this.Team = Job.Team;
            this.SetData("o", Job.Title, true);
            Program.dx.Invoke("add", this.MTAElement, "job", Job.Title, Job.Color.R, Job.Color.G, Job.Color.B);
        }
        public void quitJob()
        {
            setJob("Unemployed");
            this.Model = skin;
        }

        public void editMoney(int amount)
        {
            Program.dx.Invoke("moneyText", this.MTAElement, this.Money, (this.Money + amount));
            if (amount < 0)
            {
                
                TakeMoney(System.Math.Abs(amount));

                //Program.dx.Invoke("modTextBar", this.MTAElement, "money", "", 0, 0, 0);
                Program.dx.Invoke("modTextBar", this.MTAElement, "money", "-$" + System.Math.Abs(amount), 255, 0, 0);
            }
            else
            {
                GiveMoney(amount);
                //Program.dx.Invoke("modTextBar", this.MTAElement, "money", "", 0, 0, 0);
                Program.dx.Invoke("modTextBar", this.MTAElement, "money", "$" + amount, 0, 255, 0);
            }

        }

        public void editBankMoney(int amount)
        {
            BankBalance += amount;
        }

        public void withdrawBankMoney(int amount)
        {
            if (this.BankBalance >= amount)
            {
                editBankMoney(-amount);
                editMoney(amount);
            }
            else
            {
                //not enough money in bank
                Program.dx.Invoke("shout", this.MTAElement, "You lack the funds to make this withdrawal.", 255, 0, 0);
            }
        }

        public void depositMoney(int amount)
        {
            if (this.Money >= amount)
            {
                editMoney(-amount);
                editBankMoney(amount);
            }
            else
            {
                //cant deposit money u dont have
                Program.dx.Invoke("shout", this.MTAElement, "You lack the funds to make this deposit.", 255, 0, 0);
            }
        }
    }
}
