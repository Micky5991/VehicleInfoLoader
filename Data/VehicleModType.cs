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

        public VehicleMod Mod(int mod)  => this.list?[mod];
        public bool HasMod(int mod)     => Mod(mod) != null;

    }
}