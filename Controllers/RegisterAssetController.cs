using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Monitoring.View;

namespace Monitoring.Controllers;

[ApiController]
[Route("[controller]")]
public class RegisterAssetController : ControllerBase
{

    private readonly ILogger<RegisterAssetController> _logger;

    public RegisterAssetController(ILogger<RegisterAssetController> logger)
    {
        _logger = logger;
    }


    [HttpPut(Name = "PutRegister")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Consumes(MediaTypeNames.Application.Json)]
    public ActionResult<AssetReturnStruct> Put([FromBody] RegisterAssetStruct AssetDetails)
    {
        AssetView currentAsset = new AssetView(AssetDetails.AssetID);

        if (currentAsset.ValidAsset() == true)
        {
            var operationStatus = currentAsset.Assign(AssetDetails.UnitID, AssetDetails.StartDate);
            AssetReturnStruct response = currentAsset.GetAsset();
            return response;
        }
        else
        {
            return NotFound();
        }
    }
}

