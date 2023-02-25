using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Monitoring.View;

namespace Monitoring.Controllers;

[ApiController]
[Route("[controller]")]
public class AssetListController : ControllerBase
{

    private readonly ILogger<AssetListController> _logger;

    public AssetListController(ILogger<AssetListController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetAssetList")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<List<AssetReturnStruct>> Get()
    {

        var currentView = new HomeView();

        return currentView.GetAssetList();

    }


}

