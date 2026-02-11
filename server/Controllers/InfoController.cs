using server.Models;
using server.Services;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class InfoController : ControllerBase
{
    public InfoController()
    {
        
    }

    [HttpGet]
    public ActionResult<Info> Get() =>
        InfoService.GetInfo();
}

