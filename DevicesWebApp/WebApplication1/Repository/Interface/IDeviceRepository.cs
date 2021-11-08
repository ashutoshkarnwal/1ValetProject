using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Model;
using WebApplication1.Model.DeviceDetail;

namespace WebApplication1.Repository.Interface
{
    public interface IDeviceRepository
    {
        List<Device> GetAllDevices();

        DetailDevice GetRelatedDevices(int deviceId);
    }
}