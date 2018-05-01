using System.Collections.Generic;
using Newtonsoft.Json;

namespace VehicleInfoLoader.Data
{
    internal sealed class LiveryCollection
    {
        [JsonProperty("amount")]
        public int Amount { get; internal set; }

        [JsonProperty("list")]
        internal Dictionary<int, Livery> List { get; set; }
    }
}
