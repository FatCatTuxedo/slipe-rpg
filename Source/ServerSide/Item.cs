using Slipe.Server.Peds;
using Slipe.Shared.Elements;
using System;
using System.Collections.Generic;
using System.Text;

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
            foreach (vPlayer player in ElementManager.Instance.GetByType<Player>())
            {
                if (player.accountID == playerid)
                    this.Owner = player;
            }
        }
    }
}
