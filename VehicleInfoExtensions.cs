using GrandTheftMultiplayer.Server.Elements;
using VehicleInfoLoader.data;

namespace VehicleInfoLoader
{
    public static class VehicleInfoExtensions
    {
        public static VehicleManifest Manifest(this Vehicle vehicle) => VehicleInfo.Get(vehicle.model);
    }   
}