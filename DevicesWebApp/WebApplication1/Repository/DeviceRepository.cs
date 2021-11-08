using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Model;
using WebApplication1.Model.DeviceDetail;
using WebApplication1.Repository.Interface;

namespace WebApplication1.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        public List<Device> GetAllDevices()
        {
            var devices = new List<Device>();

            using (var db = new Entities())
            {
                devices = db.Devices.ToList();
                return devices;
            }
        }

        public DetailDevice GetRelatedDevices(int deviceId)
        {
            var devices = new List<Device>();

            using (var db = new Entities())
            {
                var relation= db.Devices.Where(x => x.DeviceId == deviceId).FirstOrDefault();
                return new DetailDevice
                {
                    RelatedDevices = relation.DeviceRelations.Select(x =>x.RelatedDevice).ToList() ,
                    DeviceName = relation.DeviceName,
                    DeviceId =relation.DeviceId,
                    UsageDescription = relation.UsageDescription,
                    Status =relation.Status,
                    Image = relation.Image,
                    Temperature =relation.Temperature
                };
            }
        }
    }
}