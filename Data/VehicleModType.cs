// ReSharper disable InconsistentNaming
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VehicleInfoLoader.Data
{
    public sealed class VehicleModType
    {
        public int amount { get; internal set; }
        
        [JsonProperty]
        internal Dictionary<int, VehicleMod> list;

        public Dictionary<int, VehicleMod> Mods() => list;
        public VehicleMod Mod(int mod)  => list?[mod];
        public bool HasMod(int mod)     => Mod(mod) != null;

    }
}