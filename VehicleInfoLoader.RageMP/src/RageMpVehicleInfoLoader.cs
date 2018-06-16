using System.IO;
using System.Threading.Tasks;
using GTANetworkAPI;
using VehicleInfoLoader.Data;

namespace VehicleInfoLoader.RageMP
{
    public static class RageMpVehicleInfoLoader
    {
        public static VehicleManifest Manifest(this Vehicle vehicle)
        {
            return VehicleInfoLoader.Get((int) vehicle.Model);
        }

        public static async Task<VehicleManifest> ManifestAsync(this Vehicle vehicle)
        {
            return await VehicleInfoLoader.GetAsync((int) vehicle.Model);
        }

        public static VehicleManifest Get(VehicleHash hash)
        {
            return VehicleInfoLoader.Get((int) hash);
        }

        public static Task<VehicleManifest> GetAsync(VehicleHash hash)
        {
            return VehicleInfoLoader.GetAsync((int) hash);
        }

        public static void Setup(Script scriptEngine, string path = null, bool cache = true)
        {
            VehicleInfoLoader.Setup(Path.Combine(NAPI.Resource.GetResourceFolder(scriptEngine), path ?? $"vehicleInfo{Path.DirectorySeparatorChar}"), cache);
        }
    }
}
