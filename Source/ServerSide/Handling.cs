using System;
using System.Collections.Generic;
using System.Text;
using Slipe.Shared.Vehicles;
using Slipe.Json;
using System.Numerics;

namespace ServerSide
{
    public static class HandlingManager
    {
        public static Dictionary<int, CustomHandling> HandlingList;

        public static void loadHandling()
        {
            HandlingList = new Dictionary<int, CustomHandling>();
            _ = dbManager.getHandling();
        }

        public static void setHandling(SharedVehicle veh, CustomHandling h)
        {
            veh.Handling.Mass = h.Mass;
            veh.Handling.TurnMass = h.TurnMass;
            veh.Handling.DragCoefficient = h.DragCoefficient;
            veh.Handling.CenterOfMass = h.CenterOfMass;
            veh.Handling.PercentSubmerged = h.PercentSubmerged;
            veh.Handling.TractionMultiplier = h.TractionMultiplier;
            veh.Handling.TractionLoss = h.TractionLoss;
            veh.Handling.TractionBias = h.TractionBias;
            veh.Handling.NumberOfGears = h.NumberOfGears;
            veh.Handling.MaxVelocity = h.MaxVelocity;
            veh.Handling.EngineAcceleration = h.EngineAcceleration;
            veh.Handling.EngineInertia = h.EngineInertia;
            veh.Handling.DriveType = h.DriveType;
            veh.Handling.EngineType = h.EngineType;
            veh.Handling.BrakeDeceleration = h.BrakeDeceleration;
            veh.Handling.BrakeBias = h.BrakeBias;
            veh.Handling.SteeringLock = h.SteeringLock;
            veh.Handling.SuspensionForceLevel = h.SuspensionForceLevel;
            veh.Handling.SuspensionDamping = h.SuspensionDamping;
            veh.Handling.SuspensionHighSpeedDamping = h.SuspensionHighSpeedDamping;
            veh.Handling.SuspensionUpperLimit = h.SuspensionUpperLimit;
            veh.Handling.SuspensionLowerLimit = h.SuspensionLowerLimit;
            veh.Handling.SuspensionFrontRearBias = h.SuspensionFrontRearBias;
            veh.Handling.SuspensionAntiDiveMultiplier = h.SuspensionAntiDiveMultiplier;
            veh.Handling.SeatOffsetDistance = h.SeatOffsetDistance;
            veh.Handling.CollisionDamageMultiplier = h.CollisionDamageMultiplier;
        }
    }
    public class CustomHandling : Handling
    {
        public int id;
        public int vehicle;
        public CustomHandling(int i, int veh, float mass, float turnmass, float dragCoeff, float x, float y, float z, int persub,
            float tmult, float tloss, float tbias, int gears, float maxvel, float enga, float engi, string dType,
            string etype, float breakd, float breakbias, float steerlock, float sfl, float sd, float shsd, float sul,
             float sll, float sfrb, float sadm, float sosd, float cdm)
        {
            id = i;
            vehicle = veh;
            this.Mass = mass;
            this.TurnMass = turnmass;
            this.DragCoefficient = dragCoeff;
            this.CenterOfMass = new Vector3(x, y, z);
            this.PercentSubmerged = persub;
            this.TractionMultiplier = tmult;
            this.TractionLoss = tloss;
            this.TractionBias = tbias;
            this.NumberOfGears = gears;
            this.MaxVelocity = maxvel;
            this.EngineAcceleration = enga;
            this.EngineInertia = engi;
            this.DriveType = (DriveType)Enum.Parse(typeof(DriveType), dType);
            this.EngineType = (EngineType)Enum.Parse(typeof(EngineType), etype);
            this.BrakeDeceleration = breakd;
            this.BrakeBias = breakbias;
            this.SteeringLock = steerlock;
            this.SuspensionForceLevel = sfl;
            this.SuspensionDamping = sd;
            this.SuspensionHighSpeedDamping = shsd;
            this.SuspensionUpperLimit = sul;
            this.SuspensionLowerLimit = sll;
            this.SuspensionFrontRearBias = sfrb;
            this.SuspensionAntiDiveMultiplier = sadm;
            this.SeatOffsetDistance = sosd;
            this.CollisionDamageMultiplier = cdm;
        }
    }
}
