using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Monitoring.View;

namespace Monitoring.Controllers;

[ApiController]
[Route("[controller]")]
public class EnergyController : ControllerBase
{

    private readonly ILogger<EnergyController> _logger;

    public EnergyController(ILogger<EnergyController> logger)
    {
        _logger = logger;
    }


    [HttpPut(Name = "PutEnergy")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<DeviceReturnStruct> Put([FromBody] SetLiveDeviceStruct newDetails)
    {
        DeviceView currentDevice = new DeviceView(newDetails.DeviceSerialNumber);

        currentDevice.SetLive();
        DeviceReturnStruct response = currentDevice.GetDevice();

        return response;
    }
}


