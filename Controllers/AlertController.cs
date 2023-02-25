using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Monitoring.View;

namespace Monitoring.Controllers;

[ApiController]
[Route("[controller]")]
public class AlertController : ControllerBase
{

    private readonly ILogger<AlertController> _logger;

    public AlertController(ILogger<AlertController> logger)
    {
        _logger = logger;
    }


    [HttpPut(Name = "PutAlert")]
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


