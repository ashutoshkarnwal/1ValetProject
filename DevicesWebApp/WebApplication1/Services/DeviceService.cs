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
    /// <summary>
    /// Device Services
    /// </summary>
    public class DeviceService: IDeviceService
    {
        private IDeviceRepository _deviceRepository;
        public DeviceService()
        {
            _deviceRepository = new DeviceRepository();
        }

        /// <summary>
        /// Get List of All devices
        /// </summary>
        /// <returns></returns>
        public List<DeviceDTO> GetAllDevices()
        {
            var devices = _deviceRepository.GetAllDevices();

            if (devices != null && devices.Any())
            {
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
            else
            {
                return new List<DeviceDTO>();
            }

        }

        /// <summary>
        /// Get detil of a selected device also all related devices associated with it.
        /// </summary>
        /// <param name="deviceId">Selected Device Id</param>
        /// <returns></returns>
        public DeviceDTO GetRelatedDevices(int deviceId)
        {
            var device = _deviceRepository.GetRelatedDevices(deviceId);

            if (device != null)
            {
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
            else
            {
                return new DeviceDTO();
            }

        }
    }
}