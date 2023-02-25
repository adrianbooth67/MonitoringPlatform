using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Monitoring.View;

namespace Monitoring.Controllers;

[ApiController]
[Route("[controller]")]
public class DeviceRegisterController : ControllerBase
{

    private readonly ILogger<DeviceRegisterController> _logger;

    public DeviceRegisterController(ILogger<DeviceRegisterController> logger)
    {
        _logger = logger;
    }


    [HttpPut(Name = "PutDeviceSetLive")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<DeviceReturnStruct> PutDeviceSetLive([FromBody] SetLiveDeviceStruct newDetails)
    {
        DeviceView currentDevice = new DeviceView(newDetails.DeviceSerialNumber);

        currentDevice.SetLive();
        DeviceReturnStruct response = currentDevice.GetDevice();

        return response;
    }
}

