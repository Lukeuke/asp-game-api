using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("/initialize")]
public class InitializeController : ControllerBase
{
    [HttpPost]
    [Authorize]
    public InitializeResponseDto Post(InitializeRequestDto initializeRequestDto)
    {
        initializeRequestDto.Id = GameService.GetInstance().GetIdFromDb(initializeRequestDto);
        GameService.GetInstance().SomeBusinessMethod();

        return new InitializeResponseDto()
        {
            Id = initializeRequestDto.Id,
            WonCount = 2,
            TotalMoneyWon = 100,
            CanPlay = GameService.GetInstance().CanPlay()
        };
    }
}