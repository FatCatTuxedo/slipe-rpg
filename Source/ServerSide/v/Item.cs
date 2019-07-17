using Slipe.Server.Peds;
using Slipe.Shared.Elements;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ServerSide
{
    public class PlayerItem
    {
        public string ID;
        public int amount;
        public vPlayer Owner;

        public PlayerItem(string name, int a, int playerid)
        {
            this.ID = name;
            this.amount = a;
            this.Owner = (vPlayer)ElementManager.Instance.GetByType<Player>().FirstOrDefault(e => ((vPlayer)e).accountID == playerid);
        }
    }
}
