using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    
    [HttpPost("register")]
    public IActionResult Register(AuthenticationRequestDto requestDto)
    {
        var (success, content) = _authenticationService.Register(requestDto.Username, requestDto.Password);

        if (!success)
        {
            return BadRequest(content);
        }

        return Login(requestDto);
    }
    
    [HttpPost("login")]
    public IActionResult Login(AuthenticationRequestDto requestDto)
    {
        Console.WriteLine($"{requestDto.Password}, {requestDto.Username}");
        var (success, content) = _authenticationService.Login(requestDto.Username, requestDto.Password);
        
        if (!success)
        {
            return BadRequest(content);
        }

        var result = new AuthenticationResponseDto()
        {
            Token = content
        };
        
        return Ok(result);
    }
}