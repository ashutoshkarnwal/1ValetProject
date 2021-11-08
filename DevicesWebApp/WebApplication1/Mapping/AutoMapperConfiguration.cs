using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DeviceProfile>();
            });
        }
    }
}