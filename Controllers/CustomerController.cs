using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Monitoring.View;

namespace Monitoring.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{

    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "PostCustomer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<CustomerReturnStruct> Post([FromBody] CustomerStruct NewDetails)
    {
        CustomerView newType = new CustomerView(NewDetails.CustomerName, NewDetails.PartnerID);

        if (newType.ValidCustomer() == true)
        {
            return newType.GetCustomer();
        }
        else
        {
            return NotFound();
        }

    }

    [HttpGet(Name = "GetCustomers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public ActionResult<List<CustomerReturnStruct>> Get()
    {
        HomeView home = new HomeView();

        List<CustomerReturnStruct> response = home.GetCustomers();

        return response;
    }

    [HttpPut(Name = "PutCustomer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Consumes(MediaTypeNames.Application.Json)]
    public ActionResult<CustomerReturnStruct> Put([FromBody] CustomerUpdateStruct CustomerDetails)
    {
        CustomerView currentCustomer = new CustomerView(CustomerDetails.CustomerID);

        if (currentCustomer.ValidCustomer() == true)
        {
            currentCustomer.Update(CustomerDetails.CustomerName, CustomerDetails.PartnerID);
            CustomerReturnStruct response = currentCustomer.GetCustomer();
            return response;
        }
        else
        {
            return NotFound();
        }
    }
}

