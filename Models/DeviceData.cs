using System.Collections.Generic;

namespace BitRateCalculator.Models
{
    public class DeviceData
    {
        public string Device { get; set; }
        public string Model { get; set; }
        public List<NetworkInterface> NIC { get; set; }
    }
}
