using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Model.DTO
{
    public class DeviceDTO
    {
        [JsonProperty("deviceId")]
        public int DeviceId { get; set; }

        [JsonProperty("deviceName")]
        public string DeviceName { get; set; }

        [JsonProperty("usageDescription")]
        public string UsageDescription { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("temperature")]
        public Nullable<int> Temperature { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("relatedDevices")]
        public ICollection<DeviceDTO> RelatedDevices { get; set; }
    }
}