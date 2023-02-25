using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Monitoring.View;

namespace Monitoring.Controllers;

[ApiController]
[Route("[controller]")]
public class AssetTypeController : ControllerBase
{

    private readonly ILogger<AssetTypeController> _logger;

    public AssetTypeController(ILogger<AssetTypeController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "PostAssetType")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<AssetTypeReturnStruct> Post([FromBody] AssetTypeStruct NewDetails)
    {
        AssetTypeView newType = new AssetTypeView(NewDetails.AssetTypeName);

        if (newType.ValidType() == true)
        {
            return newType.GetAssetType();
        }
        else
        {
            return NotFound();
        }

    }

    [HttpGet(Name = "GetAssetType")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<List<AssetTypeReturnStruct>> Get()
    {
        HomeView home = new HomeView();

        List<AssetTypeReturnStruct> response = home.GetAssetTypes();

        return response;
    }
}

