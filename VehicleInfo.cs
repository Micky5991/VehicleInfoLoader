using System;
using System.Collections.Generic;
using System.IO;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using Newtonsoft.Json;
using VehicleInfoLoader.data;

namespace VehicleInfoLoader
{
    public sealed class VehicleInfo
    {
        private static string basePath = "vehicleinfo/";
        private static readonly Dictionary<int, VehicleManifest> Vehicles = new Dictionary<int, VehicleManifest>();

        public static VehicleManifest Get(string vehiclename) => Get((VehicleHash) API.shared.getHashKey(vehiclename));
        public static VehicleManifest Get(Vehicle vehicle)    => Get(vehicle.model);
        public static VehicleManifest Get(VehicleHash hash) => Get((int) hash);
        
        public static VehicleManifest Get(int vehicle)
        {
            if (Vehicles.ContainsKey(vehicle)) return Vehicles[vehicle];
            
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
                
                Vehicles.Add((int)vehicleManifest.hash, vehicleManifest);
                return vehicleManifest;
            }
            catch (JsonReaderException e)
            {
                API.shared.consoleOutput(LogCat.Error, "[VehicleInfo] An error occured while reading '" + path + "': " + e.Message);
                return null;
            }
        }

        
        public static void Remove(string vehiclename) => Remove((VehicleHash) API.shared.getHashKey(vehiclename));
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

        public static void Setup(string path)
        {
            VehicleInfo.basePath = path;
        }

        internal static string MakePath(string relativePath)
        {
            return Path.Combine(basePath, relativePath);
        }

    }
}