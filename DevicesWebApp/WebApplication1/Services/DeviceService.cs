using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Model;
using WebApplication1.Model.DTO;
using WebApplication1.Repository;
using WebApplication1.Repository.Interface;
using WebApplication1.Services.Interface;

namespace WebApplication1.Services
{
    public class DeviceService: IDeviceService
    {
        private IDeviceRepository _deviceRepository;
        public DeviceService()
        {
            _deviceRepository = new DeviceRepository();
        }
        public List<DeviceDTO> GetAllDevices()
        {
            var devices = _deviceRepository.GetAllDevices();
            return devices
            .Select(t => new DeviceDTO
            {
                Status = t.Status,
                DeviceName = t.DeviceName,
                UsageDescription = t.UsageDescription,
                Temperature = t.Temperature,
                DeviceId = t.DeviceId,
                Image = t.Image
            }).ToList();

        }

        public DeviceDTO GetRelatedDevices(int deviceId)
        {
            var device = _deviceRepository.GetRelatedDevices(deviceId);
            return new DeviceDTO()
            {
                Status = device.Status,
                DeviceName = device.DeviceName,
                UsageDescription = device.UsageDescription,
                Temperature = device.Temperature,
                DeviceId = device.DeviceId,
                Image = device.Image,
                RelatedDevices = device.RelatedDevices.Select(t => new DeviceDTO
                {
                    Status = t.Status,
                    Image = t.Image,
                    DeviceName = t.DeviceName,
                    UsageDescription = t.UsageDescription,
                    Temperature = t.Temperature,
                    DeviceId = t.DeviceId
                }).ToList()
        };

        }
    }
}