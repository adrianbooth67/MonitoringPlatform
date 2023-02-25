using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Monitoring.View;

namespace Monitoring.Controllers;

[ApiController]
[Route("[controller]")]
public class PartnerController : ControllerBase
{

    private readonly ILogger<PartnerController> _logger;

    public PartnerController(ILogger<PartnerController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "PostPartner")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<PartnerReturnStruct> Post([FromBody] PartnerStruct NewDetails)
    {
        PartnerView newType = new PartnerView(NewDetails.PartnerName);

        if (newType.ValidPartner() == true)
        {
            return newType.GetPartner();
        }
        else
        {
            return NotFound();
        }

    }

    [HttpGet(Name = "GetPartners")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<List<PartnerReturnStruct>> Get()
    {
        HomeView home = new HomeView();

        List<PartnerReturnStruct> response = home.GetPartners();

        return response;
    }

    [HttpPut(Name = "PutPartner")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Consumes(MediaTypeNames.Application.Json)]
    public ActionResult<PartnerReturnStruct> Put([FromBody] PartnerUpdateStruct PartnerDetails)
    {
        PartnerView currentPartner = new PartnerView(PartnerDetails.PartnerID);

        if (currentPartner.ValidPartner() == true)
        {
            currentPartner.Update(PartnerDetails.PartnerName);
            PartnerReturnStruct response = currentPartner.GetPartner();
            return response;
        }
        else
        {
            return NotFound();
        }
    }
}

