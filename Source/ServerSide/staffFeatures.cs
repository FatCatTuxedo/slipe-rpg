using Slipe.Server.Events;
using Slipe.Server.Game;
using Slipe.Server.IO;
using Slipe.Server.Peds;
using Slipe.Server.Pickups;
using Slipe.Server.Vehicles;
using Slipe.Server.Vehicles.Events;
using Slipe.Shared.Utilities;
using Slipe.Shared.Vehicles;
using Slipe.Shared.Weapons;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ServerSide
{
    public class StaffDutyVeh : Vehicle
    {
        // The team that this vehicle is locked to
        public Team Team { get; }

        // Create a new super vehicle locked to a team
        public StaffDutyVeh(VehicleModel model, Vector3 position)
          : base(model, position)
        {
            Team = mTeam.Teams["Staff"];
            DamageProof = true;
            
            PlateText = "XoaStaff";
            // If a player wants to enter the driver seat. 
            // He should be of the right team.
            OnStartEnter += (BaseVehicle v, OnStartEnterEventArgs a) =>
            {
                if (a.Seat == Seat.FrontLeft && a.Player.Team != this.Team)
                {
                    ChatBox.WriteLine("Only staff can drive this.", a.Player, Color.Red);
                    Event.Cancel();
                }
            };
        }
    }
}
