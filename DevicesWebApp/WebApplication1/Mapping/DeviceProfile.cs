using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Model;
using WebApplication1.Model.DTO;

namespace WebApplication1.Mapping
{
    public class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<Device, DeviceDTO>()
                .ForMember(e => e.DeviceId, p => p.MapFrom(e => e.DeviceId))
                .ForMember(e => e.DeviceName, p => p.MapFrom(e => e.DeviceName))
                .ForMember(e => e.UsageDescription, p => p.MapFrom(e => e.UsageDescription))
                .ForMember(e => e.Status, p => p.MapFrom(e => e.Status))
                .ForMember(e => e.Temperature, p => p.MapFrom(e => e.Temperature))
                .ForMember(e => e.RelatedDevices, p => p.MapFrom(e => e.DeviceRelations));

            CreateMap<DeviceRelation, DeviceRelationDTO>()
               .ForMember(e => e.DeviceId, p => p.MapFrom(e => e.DeviceId))
               .ForMember(e => e.DeviceRelationId, p => p.MapFrom(e => e.DeviceRelationId))
               .ForMember(e => e.RelatedDeviceId, p => p.MapFrom(e => e.RelatedDeviceId));         
        }
    }
}