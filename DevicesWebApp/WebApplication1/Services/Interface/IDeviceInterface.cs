using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Model;
using WebApplication1.Model.DTO;

namespace WebApplication1.Services.Interface
{
    public interface IDeviceService
    {
        List<DeviceDTO> GetAllDevices();

        DeviceDTO GetRelatedDevices(int deviceId);
    }
}