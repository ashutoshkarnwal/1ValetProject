using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using WebApplication1.Authentication;
using WebApplication1.Model;
using WebApplication1.Model.DTO;
using WebApplication1.Services;
using WebApplication1.Services.Interface;

namespace WebApplication1.Controllers
{   
    /// <summary>
    /// Device Controller
    /// </summary>
    public class DeviceController: ApiController
    {
        private IDeviceService _deviceService;
        public DeviceController()
        {
            _deviceService = new DeviceService();
        }

        [Route("api/Device/GetDevices")]
        [HttpGet]
        [BasicAuthentication]
        ///<summary>Get the List of all devices</summary>
        public HttpResponseMessage GetDevices()
        {
            try
            {
                JsonSerializer ser = new JsonSerializer();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");

                //DB data               
                var devices = JsonConvert.SerializeObject(_deviceService.GetAllDevices()).ToString();

                //Mock Data from json file
                //var devices = "[{\"deviceId\":1,\"deviceName\":\"Computer\",\"usageDescription\":\"To do daily task\",\"status\":true,\"temperature\":10,\"image\":\"icons8-computer-30.png\",\"relatedDevices\":null},{\"deviceId\":2,\"deviceName\":\"Mouse\",\"usageDescription\":\"Its a pointing device\",\"status\":true,\"temperature\":70,\"image\":\"icons8-mouse-48.png\",\"relatedDevices\":null},{\"deviceId\":3,\"deviceName\":\"Printer\",\"usageDescription\":\"Its a printing device\",\"status\":true,\"temperature\":20,\"image\":\"icons8-printer-48.png\",\"relatedDevices\":null},{\"deviceId\":1003,\"deviceName\":\"Video Game\",\"usageDescription\":\"It is to play games\",\"status\":true,\"temperature\":12,\"image\":\"icons8-video-game-64.png\",\"relatedDevices\":null},{\"deviceId\":1004,\"deviceName\":\"Video Game Controller\",\"usageDescription\":\"It is a controller for playing games\",\"status\":true,\"temperature\":12,\"image\":\"icons8-video-game-48.png\",\"relatedDevices\":null},{\"deviceId\":1005,\"deviceName\":\"SmartPhone\",\"usageDescription\":\"It is a cell phone\",\"status\":true,\"temperature\":120,\"image\":\"icons8-smartphone-64.png\",\"relatedDevices\":null},{\"deviceId\":1006,\"deviceName\":\"Landline\",\"usageDescription\":\"It is a landline\",\"status\":true,\"temperature\":60,\"image\":\"icons8-phone-off-the-hook-50.png\",\"relatedDevices\":null}]";                

                response.Content = new StringContent(devices, Encoding.UTF8, "application/json");
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }

        }

        [Route("api/Device/GetRelatedDevices")]
        [HttpGet]
        [BasicAuthentication]
        ///<summary>Get Detail of a particular selected device and all devices which are related to it</summary>
        ///<param name="id">It is the id of a selected Device</param>
        public HttpResponseMessage GetRelatedDevices(int id)
        {
            try
            {
                JsonSerializer ser = new JsonSerializer();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");

                //DB Data
                var device = JsonConvert.SerializeObject(_deviceService.GetRelatedDevices(id));

                //Mock Data from json file
                //var device = "{\"deviceId\":3,\"deviceName\":\"Printer\",\"usageDescription\":\"Its a printing device\",\"status\":true,\"temperature\":20,\"image\":\"icons8-printer-48.png\",\"relatedDevices\":[{\"deviceId\":1,\"deviceName\":\"Computer\",\"usageDescription\":\"To do daily task\",\"status\":true,\"temperature\":10,\"image\":\"icons8-computer-30.png\",\"relatedDevices\":null},{\"deviceId\":2,\"deviceName\":\"Mouse\",\"usageDescription\":\"Its a pointing device\",\"status\":true,\"temperature\":70,\"image\":\"icons8-mouse-48.png\",\"relatedDevices\":null}]}";
                
                response.Content = new StringContent(device, Encoding.UTF8, "application/json");
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }

        }
    }
}
