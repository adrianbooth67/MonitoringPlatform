using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Monitoring.View;

namespace Monitoring.Controllers;

[ApiController]
[Route("[controller]")]
public class OperatingUnitController : ControllerBase
{

    private readonly ILogger<OperatingUnitController> _logger;

    public OperatingUnitController(ILogger<OperatingUnitController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "PostOperatingUnit")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<OperatingUnitReturnStruct> Post([FromBody] OperatingUnitStruct NewDetails)
    {
        OperatingUnitView newOperatingUnit = new OperatingUnitView(NewDetails.OperatingUnitName, NewDetails.LocationID);

        if (newOperatingUnit.ValidOperatingUnit() == true)
        {
            return newOperatingUnit.GetOperatingUnit();
        }
        else
        {
            return NotFound();
        }

    }

    [HttpGet(Name = "GetOperatingUnit")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<OperatingUnitReturnStruct> Get(Int32 OperatingUnitID)
    {

        var currentOperatingUnit = new OperatingUnitView(OperatingUnitID);
        if (currentOperatingUnit.ValidOperatingUnit() == true)
        {
            var response = currentOperatingUnit.GetOperatingUnit();
            return response;
        }
        else
        {
            return NotFound();
        }

    }

    [HttpPut(Name = "PutOperatingUnit")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Consumes(MediaTypeNames.Application.Json)]
    public ActionResult<OperatingUnitReturnStruct> Put([FromBody] OperatingUnitUpdateStruct OperatingUnitDetails)
    {
        OperatingUnitView currentOperatingUnit = new OperatingUnitView(OperatingUnitDetails.OperatingUnitID);

        if (currentOperatingUnit.ValidOperatingUnit() == true)
        {
            currentOperatingUnit.Update(OperatingUnitDetails.OperatingUnitName, OperatingUnitDetails.LocationID);
            OperatingUnitReturnStruct response = currentOperatingUnit.GetOperatingUnit();
          
            return response;
        }
        else
        {
            return NotFound();
        }
    }
}

