using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VehicleInfoLoader.Data;

namespace VehicleInfoLoader
{
    public sealed class VehicleInfoLoader
    {
        private static string _basePath = $"vehicleinfo{Path.DirectorySeparatorChar}";
        private static bool _cache = true;
        private static readonly Dictionary<int, VehicleManifest> _vehicles = new Dictionary<int, VehicleManifest>();
        
        public static VehicleManifest Get(int vehicle)
        {
            lock (_vehicles)
            {
                if (_cache && _vehicles.ContainsKey(vehicle))
                {
                    return _vehicles[vehicle];
                }
            }
            
            string path = MakePath(vehicle + ".json");
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Could not find '{path}'");
            }

            var vehicleManifest = JsonConvert.DeserializeObject<VehicleManifest>(
                File.ReadAllText(path), 
                new JsonSerializerSettings
                {
                    ContractResolver = new EnableWriteableInternal()
                });

            if (_cache)
            {
                lock (_vehicles)
                {
                    _vehicles.Add(vehicleManifest.Hash, vehicleManifest);
                }
            }
            
            return vehicleManifest;
        }

        public static async Task<VehicleManifest> GetAsync(int vehicle)
        {
            return await Task.Run(() => Get(vehicle));
        }

        public static void Remove(int vehicle)
        {
            lock (_vehicles)
            {
                _vehicles.Remove(vehicle);
            }
        } 

        public static void Clear()
        {
            lock (_vehicles)
            {
                _vehicles.Clear();
            }
        }

        public static void Load()
        {
            string[] files = Directory.GetFiles(MakePath(), "*.json");
            
            foreach (var file in files)
            {
                Get(Convert.ToInt32(Path.GetFileNameWithoutExtension(file)));
            }
        }

        public static void Setup(string path, bool cache=true)
        {
            _basePath = path;
            _cache = cache;
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
