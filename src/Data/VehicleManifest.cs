using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;

namespace VehicleInfoLoader.Data
{
    public sealed class VehicleManifest
    {
        [JsonProperty("hash")]
        public int Hash              { get; internal set; }
        
        [JsonProperty("name")]
        public string Name                   { get; internal set; }
        
        [JsonProperty("displayName")]
        public string DisplayName            { get; internal set; }
        
        [JsonProperty("localizedName")]
        public string LocalizedName          { get; internal set; }
        
        [JsonProperty("manufacturerName")]
        public string ManufacturerName       { get; internal set; }
        
        [JsonProperty("localizedManufacturer")]
        public string LocalizedManufacturer  { get; internal set; }
        
        [JsonProperty("vehicleClass")]
        public int VehicleClass              { get; internal set; }
        
        [JsonProperty("vehicleClassName")]
        public string VehicleClassName       { get; internal set; }
        
        [JsonProperty("localizedVehicleClass")]
        public string LocalizedVehicleClass  { get; internal set; }
        
        [JsonProperty("wheelType")]
        public int WheelType                 { get; internal set; }
        
        [JsonProperty("wheelTypeName")]
        public string WheelTypeName          { get; internal set; }
        
        [JsonProperty("localizedWheelType")]
        public string LocalizedWheelType     { get; internal set; }

        [JsonProperty("convertible")]
        public bool Convertible              { get; internal set; }
        
        [JsonProperty("electric")]
        public bool Electric                 { get; internal set; }
        
        [JsonProperty("trailer")]
        public bool Trailer                  { get; internal set; }
        
        [JsonProperty("neon")]
        public bool Neon                     { get; internal set; }
        
        [JsonProperty("dimensions")]
        public VehicleDimensions Dimensions  { get; internal set; }

        [JsonProperty("bones")]
        public ReadOnlyDictionary<string, int> Bones { get; internal set; }
        
        [JsonProperty("maxSpeed")]
        public float MaxSpeed                { get; internal set; }
        
        [JsonProperty("maxBraking")]
        public float MaxBraking              { get; internal set; }
        
        [JsonProperty("maxTraction")]
        public float MaxTraction             { get; internal set; }
        
        [JsonProperty("maxAcceleration")]
        public float MaxAcceleration         { get; internal set; }
        
        [JsonProperty]
        public float _0xBFBA3BA79CFF7EBF     { get; internal set; }
        
        [JsonProperty]
        public float _0x53409B5163D5B846     { get; internal set; }
        
        [JsonProperty]
        public float _0xC6AD107DDC9054CC     { get; internal set; }
        
        [JsonProperty]
        public float _0x5AA3F878A178C4FC     { get; internal set; }
        
        [JsonProperty("maxNumberOfPassengers")]
        public int MaxNumberOfPassengers     { get; internal set; }
        
        [JsonProperty("maxOccupants")]
        public int MaxOccupants              { get; internal set; }
        
        [JsonProperty("rewards")]
        public string[] Rewards              { get; internal set; }
        
        [JsonProperty("mods")]
        internal Dictionary<int, VehicleModType> ModList;
        
        [JsonProperty("liveries")]
        internal LiveryCollection LiveryList;
        
        public bool HasMods
        {
            get { return ModList.Any(); }
        }

        public IEnumerable<int> ModTypes
        {
            get { return ModList?.Keys ?? Enumerable.Empty<int>(); }
        }

        public bool HasMod(int type, int mod = 0)
        {
            return Mod(type, mod) != null;
        }

        public VehicleModType ModType(int type)
        {
            return ModList?[type];
        }

        public VehicleMod Mod(int type, int mod)
        {
            if (ModList == null || !ModList.ContainsKey(type)) return null;
            return ModType(type)?.Mod(mod);
        }

        public IEnumerable<int> ModIds(int type)
        {
            if (!HasMod(type)) return Enumerable.Empty<int>();
            return ModType(type)?.List?.Keys ?? Enumerable.Empty<int>();
        }

        public IEnumerable<VehicleMod> Mods(int type)
        {
            if (!HasMod(type)) return Enumerable.Empty<VehicleMod>();
            return ModType(type)?.List?.Values ?? Enumerable.Empty<VehicleMod>();
        }

        public Dictionary<int, Dictionary<int, string>> ValidMods()
        {
            return ModList.ToDictionary(m => m.Key, m => m.Value.Mods().ToDictionary(t => t.Key, t => t.Value.Name));
        }

        public bool HasLiveries
        {
            get { return LiveryIds.Any(); }
        }

        public IEnumerable<int> LiveryIds
        {
            get { return LiveryList?.List?.Keys ?? Enumerable.Empty<int>(); }
        }

        public IEnumerable<Livery> Liveries
        {
            get { return LiveryList?.List?.Values ?? Enumerable.Empty<Livery>(); }
        }

        public int LiveryCount
        {
            get { return Liveries.Count(); }
        }

        public bool HasLivery(int id)
        {
            return Livery(id) != null;
        }

        public Livery Livery(int id)
        {
            return !HasLiveries ? null : LiveryList?.List[id];
        }

        public bool HasBone(int boneIndex)
        {
            return Bones.Any(k => k.Value == boneIndex);
        }

        public bool HasBone(string boneName)
        {
            return Bones.ContainsKey(boneName);
        }

        public IEnumerable<string> GetBoneNames()
        {
            return Bones.Select(s => s.Key);
        }

        public IEnumerable<int> GetBoneIndexes()
        {
            return Bones.Select(s => s.Value);
        }
    }
}
