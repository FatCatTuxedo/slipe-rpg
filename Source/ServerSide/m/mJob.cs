using System;
using System.Collections.Generic;
using System.Text;

namespace ServerSide
{
    public static class mJob
    {
        public static Dictionary<string, vJob> Jobs;
        public enum jobType
        {
            Staff = 1,
            Police = 2,
            Criminal = 3,
            Gangster = 4,
            CivNoFunction = 5,
            Pilot = 6,
            Trucker = 7,
            Medic = 8
        };

        public static void loadJobs()
        {
            Jobs = new Dictionary<string, vJob>();
            _ = dbManager.getJobs();
        }
    }
}
