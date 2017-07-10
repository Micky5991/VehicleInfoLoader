using System.Collections.Generic;
using System.Linq;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using Newtonsoft.Json;

// ReSharper disable InconsistentNaming

namespace VehicleInfoLoader.data
{
    public sealed class VehicleManifest
    {
        internal VehicleHash hash;
        public string name                   { get; internal set; }
        public string displayName            { get; internal set; }
        public string localizedName          { get; internal set; }
        public string manufacturerName       { get; internal set; }
        public string localizedManufacturer  { get; internal set; }
        
        public int vehicleClass              { get; internal set; }
        public string vehicleClassName       { get; internal set; }
        public string localizedVehicleClass  { get; internal set; }

        public bool convertible              { get; internal set; }
        public bool electric                 { get; internal set; }
        public bool trailer                  { get; internal set; }
        public bool neon                     { get; internal set; }
        public VehicleDimensions dimensions  { get; internal set; }

        public string[] rewards              { get; internal set; }
        
        [JsonProperty]
        internal Dictionary<int, VehicleModType> mods;
        
        [JsonProperty]
        internal VehicleLiveries liveries;
        
        
        

        public VehicleModType ModType(int type) => mods?[type];
        public VehicleMod Mod(int type, int mod)
        {
            if (this.mods == null || !this.mods.ContainsKey(type)) return null;
            return ModType(type)?.Mod(mod);
        }

        public IEnumerable<int> ModIds(int type)
        {
            if (!HasMod(type)) return Enumerable.Empty<int>();
            return ModType(type)?.list?.Keys ?? Enumerable.Empty<int>();
        }

        public IEnumerable<VehicleMod> Mods(int type)
        {
            if (!HasMod(type)) return Enumerable.Empty<VehicleMod>();
            return ModType(type)?.list?.Values ?? Enumerable.Empty<VehicleMod>();
        }
        
        public bool HasMod(int type, int mod = 0) => Mod(type, mod) != null;


    }
    
    
}