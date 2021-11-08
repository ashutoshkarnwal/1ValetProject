using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Model.DeviceDetail
{
    public class DetailDevice
    {
        public int DeviceId { get; set; }

        public string DeviceName { get; set; }

        public string UsageDescription { get; set; }

        public string Image { get; set; }

        public bool Status { get; set; }

        public Nullable<int> Temperature { get; set; }

        public List<Device> RelatedDevices { get; set; }
    }
}