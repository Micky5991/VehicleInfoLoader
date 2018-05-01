using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.Elements;
using VehicleInfoLoader.Data;

namespace VehicleInfoLoader
{
    public static class VehicleInfoExtensions
    {
        public static VehicleManifest Manifest(this Vehicle vehicle)
        {
            return VehicleInfoLoader.Get(vehicle);
        }

        public static async Task<VehicleManifest> ManifestAsync(this Vehicle vehicle)
        {
            return await VehicleInfoLoader.GetAsync(vehicle);
        }
    }   
}
