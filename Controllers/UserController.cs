using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Monitoring.View;

namespace Monitoring.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "PostUser")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Consumes(MediaTypeNames.Application.Json)]
    public ActionResult<NewUserReturnStruct> Post([FromBody] NewUserStruct NewUserDetails)
    {
        UserView newUser = new UserView(NewUserDetails.fullName, NewUserDetails.password, NewUserDetails.userName);

        if (newUser.ValidPerson() == true)
        {
            NewUserReturnStruct response = newUser.GetUser();
            return response;
        }
        else
        {
            return NotFound();
        }
    }
}

