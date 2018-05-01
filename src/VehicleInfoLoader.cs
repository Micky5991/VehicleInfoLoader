using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using Newtonsoft.Json;
using VehicleInfoLoader.Data;

namespace VehicleInfoLoader
{
    public sealed class VehicleInfoLoader
    {
        private static string _basePath = $"vehicleinfo{Path.DirectorySeparatorChar}";
        private static bool _cache = true;
        private static readonly Dictionary<int, VehicleManifest> Vehicles = new Dictionary<int, VehicleManifest>();

        public static VehicleManifest Get(string vehiclename) => Get(API.shared.getHashKey(vehiclename));
        public static VehicleManifest Get(Vehicle vehicle)    => vehicle == null ? null : Get(vehicle.model);
        public static VehicleManifest Get(VehicleHash hash)   => Get((int) hash);

        public static VehicleManifest Get(NetHandle handle)
        {
            Vehicle vehicle = API.shared.getEntityFromHandle<Vehicle>(handle);
            return vehicle == null ? null : Get(vehicle);
        }
        
        public static VehicleManifest Get(int vehicle)
        {
            lock (Vehicles)
            {
                if (_cache && Vehicles.ContainsKey(vehicle))
                {
                    return Vehicles[vehicle];
                }
            }
            
            string path = MakePath(vehicle + ".json");
            if (!File.Exists(path))
            {
                API.shared.consoleOutput(LogCat.Error, "[VehicleInfo] Could not find '" + path + "'");
                return null;
            }

            try
            {
                var vehicleManifest = JsonConvert.DeserializeObject<VehicleManifest>(File.ReadAllText(path), 
                    new JsonSerializerSettings{ ContractResolver = new EnableWriteableInternal()});

                if (_cache)
                {
                    lock (Vehicles)
                    {
                        Vehicles.Add((int)vehicleManifest.Hash, vehicleManifest);
                    }
                }
                return vehicleManifest;
            }
            catch (JsonReaderException e)
            {
                API.shared.consoleOutput(LogCat.Error, "[VehicleInfo] An error occured while reading '" + path + "': " + e.Message);
                return null;
            }
        }
        
        
        public static async Task<VehicleManifest> GetAsync(string vehiclename) => await GetAsync(API.shared.getHashKey(vehiclename));
        public static async Task<VehicleManifest> GetAsync(Vehicle vehicle)    => await GetAsync(vehicle.model);
        public static async Task<VehicleManifest> GetAsync(VehicleHash hash)   => await GetAsync((int) hash);
        public static async Task<VehicleManifest> GetAsync(int vehicle)        => await Task.Run(() => Get(vehicle));
        
        
        public static void Remove(string vehiclename) => Remove(API.shared.getHashKey(vehiclename));
        public static void Remove(Vehicle vehicle)    => Remove(vehicle.model);
        public static void Remove(VehicleHash hash)   => Remove((int) hash);

        public static void Remove(int vehicle)
        {
            lock (Vehicles)
            {
                Vehicles.Remove(vehicle);
            }
        } 

        public static void Clear()
        {
            lock (Vehicles)
            {
                Vehicles.Clear();
            }
        }

        public static void Load()
        {
            API.shared.consoleOutput(LogCat.Info, "[VehicleInfo] Loading all vehiclemanifests...");
            string[] files = Directory.GetFiles(MakePath(""), "*.json");
            foreach (var file in files) Get(Convert.ToInt32(Path.GetFileNameWithoutExtension(file)));
            API.shared.consoleOutput(LogCat.Info, "[VehicleInfo] Loading completed!");
        }

        public static void Setup(string path, bool cache=true)
        {
            _basePath = path;
            _cache = cache;
        }

        public static void Setup(API api, string path = null, bool cache=true)
        {
            Setup(Path.Combine(api.getResourceFolder(), path ?? $"vehicleInfo{Path.DirectorySeparatorChar}"), cache);
        }

        internal static string MakePath()
        {
            return MakePath("");
        }

        private static string MakePath(string relativePath)
        {
            return Path.GetFullPath(Path.Combine(_basePath, relativePath));
        }

    }
}
