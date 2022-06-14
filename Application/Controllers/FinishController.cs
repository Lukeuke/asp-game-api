using Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("/finish")]
public class FinishController : ControllerBase
{
    [HttpPost]
    public FinishResponseDto Post(FinishRequestDto finishRequestDto)
    {
        Console.WriteLine($"{finishRequestDto.Id}, {finishRequestDto.Word}");
        // TODO: Business logic with FinishRequestDto, Connection to Db
        return new FinishResponseDto(); // For now its empty but here will return if player has won and bonus amount 
    }
}