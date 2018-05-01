using System.Collections.Generic;
using Newtonsoft.Json;

namespace VehicleInfoLoader.Data
{
    public sealed class VehicleModType
    {
        [JsonProperty("amount")]
        public int Amount { get; internal set; }
        
        [JsonProperty("list")]
        internal Dictionary<int, VehicleMod> List;

        public IReadOnlyDictionary<int, VehicleMod> Mods()
        {
            return List;
        }

        public VehicleMod Mod(int mod)
        {
            if (List == null || !List.ContainsKey(mod))
            {
                return null;
            }
            
            return List[mod];
        }

        public bool HasMod(int mod)
        {
            return Mod(mod) != null;
        }
    }
}
