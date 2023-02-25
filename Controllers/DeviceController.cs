using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Monitoring.View;

namespace Monitoring.Controllers;

[ApiController]
[Route("[controller]")]
public class DeviceController : ControllerBase
{

    private readonly ILogger<DeviceController> _logger;

    public DeviceController(ILogger<DeviceController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "PostDevice")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<DeviceReturnStruct> Post([FromBody] DeviceSetupStruct NewDetails)
    {
        DeviceView newDevice = new DeviceView(NewDetails.DeviceSerialNumber);

        if (newDevice.ValidDevice() == true)
        {
            return newDevice.GetDevice();
        }
        else
        {
            return NotFound();
        }

    }

    [HttpPut(Name = "PutDeviceAllocation")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<DeviceReturnStruct> PutDeviceAllocation([FromBody] AllocateDeviceStruct newDetails)
    {
        DeviceView currentDevice = new DeviceView(newDetails.DeviceID);

        currentDevice.AllocateDevice(newDetails.UnitID);
        DeviceReturnStruct response = currentDevice.GetDevice();

        return response;
    }
}



