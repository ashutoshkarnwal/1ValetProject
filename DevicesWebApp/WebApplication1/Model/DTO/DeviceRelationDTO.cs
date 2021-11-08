using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Model.DTO
{
    public class DeviceRelationDTO
    {
        [JsonProperty("deviceRelationId")]
        public int DeviceRelationId { get; set; }

        [JsonProperty("deviceId")]
        public int DeviceId { get; set; }

        [JsonProperty("relatedDeviceId")]
        public int RelatedDeviceId { get; set; }
    }
}