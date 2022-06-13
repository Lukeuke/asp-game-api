using Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("/initialize")]
public class InitializeController : ControllerBase
{
    [HttpPost]
    public InitializeDto Post(InitializeDto initializeDto)
    {
        var rnd = new Random();
        initializeDto.Id = rnd.Next(1, 100);

        return initializeDto;
    }
}