using System.Collections.Generic;
// ReSharper disable InconsistentNaming

namespace VehicleInfoLoader.data
{
    public sealed class VehicleModType
    {
        public int amount { get; internal set; }
        internal Dictionary<int, VehicleMod> list;

        public VehicleMod Mod(int mod)  => this.list?[mod];
        public bool HasMod(int mod)     => Mod(mod) != null;

    }
}