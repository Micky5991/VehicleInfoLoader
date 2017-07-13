// ReSharper disable InconsistentNaming
using System.Linq;

namespace VehicleInfoLoader.Data
{
    public sealed class VehicleMod
    {
        public string name             { get; internal set; }
        
        public string localizedName    { get; internal set; }
        public string[] flags          { get; internal set; }

        public bool HasFlag(string flag) => this.flags.Contains(flag);

    }
}