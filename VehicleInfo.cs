using System;
using System.Collections.Generic;
using System.IO;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using Newtonsoft.Json;
using VehicleInfoLoader.Data;

namespace VehicleInfoLoader
{
    public sealed class VehicleInfo
    {
        private static string basePath = "vehicleinfo/";
        private static bool cache = true;
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
            if (cache && Vehicles.ContainsKey(vehicle)) return Vehicles[vehicle];
            
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
                
                if(cache) Vehicles.Add((int)vehicleManifest.hash, vehicleManifest);
                return vehicleManifest;
            }
            catch (JsonReaderException e)
            {
                API.shared.consoleOutput(LogCat.Error, "[VehicleInfo] An error occured while reading '" + path + "': " + e.Message);
                return null;
            }
        }
        
        /*
        public static Task<VehicleManifest> GetAsync(string vehiclename) => GetAsync(API.shared.getHashKey(vehiclename));
        public static Task<VehicleManifest> GetAsync(Vehicle vehicle)    => GetAsync(vehicle.model);
        public static Task<VehicleManifest> GetAsync(VehicleHash hash)   => GetAsync((int) hash);
        
        public static Task<VehicleManifest> GetAsync(int vehicle)
        {
            var tsc = new TaskCompletionSource<VehicleManifest>();
            
            var task = new ThreadStart(() => GetSync(tsc, vehicle));
            API.shared.startThread(task);
            
            return tsc.Task;
        }

        private static void GetSync(TaskCompletionSource<VehicleManifest> tcs, int vehicle)
        {
            try
            {
                tcs.SetResult(Get(vehicle));
            }
            catch (Exception e)
            {
                tcs.SetException(e);
            }
        }
        */
        
        public static void Remove(string vehiclename) => Remove(API.shared.getHashKey(vehiclename));
        public static void Remove(Vehicle vehicle)    => Remove(vehicle.model);
        public static void Remove(VehicleHash hash)   => Remove((int) hash);

        public static void Remove(int vehicle)        => Vehicles.Remove(vehicle);

        public static void Clear() => Vehicles.Clear();
        

        public static void Load()
        {
            API.shared.consoleOutput(LogCat.Info, "[VehicleInfo] Loading all vehiclemanifests...");
            string[] files = Directory.GetFiles(basePath, "*.json");
            foreach (var file in files) Get(Convert.ToInt32(Path.GetFileNameWithoutExtension(file)));
            API.shared.consoleOutput(LogCat.Info, "[VehicleInfo] Loading completed!");
        }

        public static void Setup(string path, bool cache)
        {
            VehicleInfo.basePath = path;
            VehicleInfo.cache = cache;
        }

        internal static string MakePath(string relativePath)
        {
            return Path.Combine(basePath, relativePath);
        }

    }
}