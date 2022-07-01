using Application.DTO;
using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("/initialize")]
public class InitializeController : ControllerBase
{
    private readonly PlayerContext _playerContext;

    public InitializeController(PlayerContext playerContext)
    {
        _playerContext = playerContext;
    }
    
    [HttpPost]
    [Authorize]
    public InitializeResponseDto Post(InitializeRequestDto initializeRequestDto)
    {
        Console.WriteLine("Id: " + initializeRequestDto.Id);

        // Getting id from Db based on requested username
        var player = _playerContext.Players.FirstOrDefault(x => x.Name == initializeRequestDto.Name);

        GameService.GetInstance().SomeBusinessMethod();
        GameService.GetInstance().GetNewWord();

        return new InitializeResponseDto()
        {
            Id = player.Id,
            WonCount = player.WonCount,
            TotalMoneyWon = player.TotalMoneyWon,
            CanPlay = true
        };
    }
}