using Application.DTO;
using Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("/initialize")]
public class InitializeController : ControllerBase
{
    [HttpPost]
    public InitializeResponseDto Post(InitializeRequestDto initializeRequestDto)
    {
        initializeRequestDto.Id = GameService.GetInstance().GetIdFromDb(initializeRequestDto);
        GameService.GetInstance().SomeBusinessMethod();

        return new InitializeResponseDto()
        {
            Id = initializeRequestDto.Id,
            CanPlay = GameService.GetInstance().CanPlay()
        };
    }
}