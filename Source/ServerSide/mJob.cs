using System;
using System.Collections.Generic;
using System.Text;

namespace ServerSide
{
    public static class mJob
    {
        public static Dictionary<int, vJob> Jobs;
        public enum jobType
        {
            Staff = 1,
            Police = 2,
            Criminal = 3,
            Gangster = 4,
            Pilot = 5,
            Trucker = 6
        };

        public static void loadJobs()
        {
            Jobs = new Dictionary<int, vJob>();
            _ = dbManager.getJobs();
        }
    }
}
