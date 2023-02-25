using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Monitoring.View;

namespace Monitoring.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationController : ControllerBase
{

    private readonly ILogger<LocationController> _logger;

    public LocationController(ILogger<LocationController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "PostLocation")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<LocationReturnStruct> Post([FromBody] LocationStruct NewDetails)
    {
        LocationView newLocation = new LocationView(NewDetails.LocationName, NewDetails.PostCode, NewDetails.AddressLine1, NewDetails.CustomerID);

        if (newLocation.ValidLocation() == true)
        {
            return newLocation.GetLocation();
        }
        else
        {
            return NotFound();
        }

    }

    [HttpGet(Name = "GetLocation")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<LocationReturnStruct> Get(Int32 LocationID)
    {

        var currentLocation = new LocationView(LocationID);
        if (currentLocation.ValidLocation() == true)
        {
            var response = currentLocation.GetLocation();
            return response;
        }
        else
        {
            return NotFound();
        }

    }

    [HttpPut(Name = "PutLocation")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Consumes(MediaTypeNames.Application.Json)]
    public ActionResult<LocationReturnStruct> Put([FromBody] LocationUpdateStruct LocationDetails)
    {
        LocationView currentLocation = new LocationView(LocationDetails.LocationID);

        if (currentLocation.ValidLocation() == true)
        {
            currentLocation.Update(LocationDetails.LocationName, LocationDetails.PostCode, LocationDetails.AddressLine1,LocationDetails.CustomerID);
            LocationReturnStruct response = currentLocation.GetLocation();

            return response;
        }
        else
        {
            return NotFound();
        }
    }
}

