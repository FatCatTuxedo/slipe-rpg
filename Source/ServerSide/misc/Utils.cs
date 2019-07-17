using Slipe.Server.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerSide.misc
{
    public class Utils
    {
        public static string getCityCode(vPlayer p)
        {
            string city = ElementExtensions.GetZoneName(p, true);
            switch (city)
            {
                case "Los Santos":
                case "Red County":
                case "Flint County":
                    return "LS";
                case "Bone County":
                case "Las Venturas":
                    return "LV";
                case "San Fierro":
                case "Whetstone":
                case "Tierra Robada":
                    return "SF";
                default:
                    return "SA";
            }
        }
    }
}
