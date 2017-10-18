using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.Elements;
using VehicleInfoLoader.Data;

namespace VehicleInfoLoader
{
    public static class VehicleInfoExtensions
    {
        public static VehicleManifest Manifest(this Vehicle vehicle) => VehicleInfoLoader.Get(vehicle);
        public static async Task<VehicleManifest> ManifestAsync(this Vehicle vehicle) => await VehicleInfoLoader.GetAsync(vehicle);
    }   
}