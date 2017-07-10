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
                
                API.shared.consoleOutput(JsonConvert.SerializeObject(vehicleManifest));
                
                Vehicles.Add((int)vehicleManifest.hash, vehicleManifest);
                return vehicleManifest;
            }
            catch (JsonSerializationException e)
            {
                API.shared.consoleOutput(LogCat.Error, "[VehicleInfo] An error occured while reading '" + path + "': " + e.Message);
                return null;
            }
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