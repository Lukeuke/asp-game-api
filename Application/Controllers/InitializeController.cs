using Application.DTO;
using Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("/initialize")]
public class InitializeController : ControllerBase
{
    [HttpPost]
    public InitializeDto Post(InitializeDto initializeDto)
    {
        initializeDto.Id = 2; // TODO: Make a business logic
        GameService.GetInstance().SomeBusinessMethod();
        return initializeDto;
    }
}