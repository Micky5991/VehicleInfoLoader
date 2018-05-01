using System.IO;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using VehicleInfoLoader.Data;

namespace VehicleInfoLoader.GTMP
{
    public static class GtmpVehicleInfoLoader
    {
        public static VehicleManifest Manifest(this Vehicle vehicle)
        {
            return VehicleInfoLoader.Get(vehicle.model);
        }

        public static async Task<VehicleManifest> ManifestAsync(this Vehicle vehicle)
        {
            return await VehicleInfoLoader.GetAsync(vehicle.model);
        }

        public static VehicleManifest Get(VehicleHash hash)
        {
            return VehicleInfoLoader.Get((int) hash);
        }

        public static Task<VehicleManifest> GetAsync(VehicleHash hash)
        {
            return VehicleInfoLoader.GetAsync((int) hash);
        }

        public static void Setup(API api, string path = null, bool cache=true)
        {
            VehicleInfoLoader.Setup(Path.Combine(api.getResourceFolder(), path ?? $"vehicleInfo{Path.DirectorySeparatorChar}"), cache);
        }
    }
}
