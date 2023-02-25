using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Monitoring.View;

namespace Monitoring.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{

    private readonly ILogger<LoginController> _logger;

    public LoginController(ILogger<LoginController> logger)
    {
        _logger = logger;
    }

    [HttpPut(Name = "PutLogin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Consumes(MediaTypeNames.Application.Json)]
    public ActionResult<LoginReturnStruct> Put([FromBody] LoginStruct LoginDetails)
    {
        UserView loginUser = new UserView(LoginDetails.userName, LoginDetails.password);

        if (loginUser.ValidPerson() == true)
        {
            LoginReturnStruct response = loginUser.GetLoginDetails();
            return response;
        }
        else
        {
            return NotFound();
        }
    }
}

