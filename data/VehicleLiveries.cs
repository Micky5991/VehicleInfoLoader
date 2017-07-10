using System.Collections.Generic;

namespace VehicleInfoLoader.data
{
    public sealed class VehicleLiveries
    {
        public int amount { get; internal set; }
        public Dictionary<int, Livery> list { get; internal set; }
    }
}