using System.Collections.Generic;

namespace VehicleInfoLoader.data
{
    public sealed class VehicleLiveries
    {
        public int amount { get; internal set; }
        internal Dictionary<int, Livery> list;
    }
}