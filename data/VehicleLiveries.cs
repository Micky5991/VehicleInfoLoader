using System.Collections.Generic;

namespace VehicleInfoLoader.data
{
    public sealed class VehicleLiveries
    {
        public int amount;
        public Dictionary<int, Livery> list = new Dictionary<int, Livery>();
    }
}