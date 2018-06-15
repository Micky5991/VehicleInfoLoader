using System.Collections.Generic;
using System.Linq;

namespace VehicleInfoLoader.Data
{
    public sealed partial class VehicleManifest
    {
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
            if (ModList == null || !ModList.ContainsKey(type))
            {
                return null;
            }
            
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
