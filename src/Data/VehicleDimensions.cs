using GrandTheftMultiplayer.Shared.Math;
using Newtonsoft.Json;

namespace VehicleInfoLoader.Data
{
    public class VehicleDimensions
    {
        [JsonProperty("min")]
        public Vector3 Min { get; internal set; }
        
        [JsonProperty("max")]
        public Vector3 Max { get; internal set; }
    }
}
