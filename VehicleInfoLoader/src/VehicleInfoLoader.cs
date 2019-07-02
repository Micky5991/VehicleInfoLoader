using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json;
using VehicleInfoLoader.Data;

namespace VehicleInfoLoader
{
    [PublicAPI]
    public sealed class VehicleInfoLoader
    {
        private static string _basePath = $"vehicleinfo{Path.DirectorySeparatorChar}";
        private static bool _cache = true;
        private static readonly ConcurrentDictionary<int, VehicleManifest> _vehicles = new ConcurrentDictionary<int, VehicleManifest>();

        public static VehicleManifest Get(int vehicle)
        {
            if (_cache && _vehicles.TryGetValue(vehicle, out var manifest))
            {
                return manifest;
            }

            var path = MakePath(vehicle + ".json");
            if (File.Exists(path) == false)
            {
                throw new FileNotFoundException($"Could not find '{path}'");
            }

            var vehicleManifest = JsonConvert.DeserializeObject<VehicleManifest>(File.ReadAllText(path),
                new JsonSerializerSettings
                {
                    ContractResolver = new EnableWriteableInternal()
                });

            if (_cache && _vehicles.TryAdd((int) vehicleManifest.Hash, vehicleManifest) == false)
            {
                return null;
            }

            return vehicleManifest;
        }

        public static async Task<VehicleManifest> GetAsync(int vehicle)
        {
            return await Task.Run(() => Get(vehicle));
        }

        public static void Remove(VehicleManifest manifest)
        {
            if (manifest == null)
            {
                throw new ArgumentNullException(nameof(manifest));
            }

            Remove((int) manifest.Hash);
        }

        public static void Remove(int vehicle)
        {
            _vehicles.TryRemove(vehicle, out _);
        }

        public static void Clear()
        {
            _vehicles.Clear();
        }

        public static void LoadAllManifests()
        {
            var files = Directory.GetFiles(MakePath(), "*.json");

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

        private static string MakePath(string relativePath = "")
        {
            return Path.GetFullPath(Path.Combine(_basePath, relativePath));
        }

    }
}
