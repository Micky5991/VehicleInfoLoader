using System.IO;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Interfaces;
using VehicleInfoLoader.Data;

namespace VehicleInfoLoader.RageMP.Net
{
    public static class AlternateLifeRageMpVehicleInfoLoader
    {
        public static VehicleManifest Manifest(this IVehicle vehicle)
        {
            return VehicleInfoLoader.Get((int) vehicle.GetModel());
        }

        public static async Task<VehicleManifest> ManifestAsync(this IVehicle vehicle)
        {
            return await VehicleInfoLoader.GetAsync((int) await vehicle.GetModelAsync());
        }

        public static VehicleManifest Get(VehicleHash hash)
        {
            return VehicleInfoLoader.Get((int) hash);
        }

        public static Task<VehicleManifest> GetAsync(VehicleHash hash)
        {
            return VehicleInfoLoader.GetAsync((int) hash);
        }

        public static void Setup(string path = null, bool cache = true)
        {
            VehicleInfoLoader.Setup(path ?? $"vehicleInfo{Path.DirectorySeparatorChar}", cache);
        }
    }
}
