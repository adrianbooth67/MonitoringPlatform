using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Monitoring.View;

namespace Monitoring.Controllers;

[ApiController]
[Route("[controller]")]
public class SupplierController : ControllerBase
{

    private readonly ILogger<SupplierController> _logger;

    public SupplierController(ILogger<SupplierController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "PostSupplier")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<SupplierReturnStruct> Post([FromBody] SupplierStruct NewDetails)
    {
        SupplierView newType = new SupplierView(NewDetails.SupplierName);

        if (newType.ValidType() == true)
        {
            return newType.GetSupplier();
        }
        else
        {
            return NotFound();
        }

    }

    [HttpGet(Name = "GetSuppliers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<List<SupplierReturnStruct>> Get()
    {
        HomeView home = new HomeView();

        List<SupplierReturnStruct> response = home.GetSuppliers();

        return response;
    }
}


