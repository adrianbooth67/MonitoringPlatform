using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Monitoring.View;

namespace Monitoring.Controllers;

[ApiController]
[Route("[controller]")]
public class AssetController : ControllerBase
{

    private readonly ILogger<AssetController> _logger;

    public AssetController(ILogger<AssetController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "PostAsset")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<AssetReturnStruct> Post([FromBody] AssetStruct NewDetails)
    {
        AssetView newType = new AssetView(NewDetails.AssetSerialNumber, NewDetails.SupplierID, NewDetails.CreationDate);

        if (newType.ValidAsset() == true)
        {
            return newType.GetAsset();
        }
        else
        {
            return NotFound();
        }

    }

    [HttpGet(Name = "GetAsset")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<AssetReturnStruct> Get(Int32 AssetID)
    {

        var currentAsset = new AssetView(AssetID);
        if (currentAsset.ValidAsset() == true)
        {
            var response = currentAsset.GetAsset();
            return response;
        }
        else
        {
            return NotFound();
        }
        
    }

    [HttpPut(Name = "PutAsset")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Consumes(MediaTypeNames.Application.Json)]
    public ActionResult<AssetReturnStruct> Put([FromBody] AssetUpdateStruct AssetDetails)
    {
        AssetView currentAsset = new AssetView(AssetDetails.AssetID);

        if (currentAsset.ValidAsset() == true)
        {
            currentAsset.Update(AssetDetails.AssetSerialNumber, AssetDetails.SupplierID);
            AssetReturnStruct response = currentAsset.GetAsset();
            return response;
        }
        else
        {
            return NotFound();
        }
    }
}

