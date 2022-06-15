using Application.Models;
using Application.PlayerData;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
public class PlayerController : ControllerBase
{
    private readonly IPlayerData _playerData;

    public PlayerController(IPlayerData playerData)
    {
        _playerData = playerData;
    }

    [HttpGet]
    [Route("/players")]
    public IActionResult GetPlayers()
    {
        return Ok(_playerData.GetPlayers());
    }
    
    [HttpGet]
    [Route("/players/{id}")]
    public IActionResult GetPlayer(Guid id)
    {
        var player = _playerData.GetPlayer(id);

        if (player != null) 
            return Ok(player);
        
        return NotFound($"Player with id: {id} Not Found");
    }

    [HttpPost]
    [Route("/register")]
    public IActionResult AddPlayer(Player player)
    {
        _playerData.CreatePlayer(player);
        return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + player.Id, player);
    }

    [HttpDelete]
    [Route("/players/{id}")]
    public IActionResult DeletePlayer(Guid id)
    {
        var player = _playerData.GetPlayer(id);

        if (player == null) return NotFound();
        
        _playerData.DeletePlayer(player);
        return NoContent();
    }
    
    [HttpPatch]
    [Route("/players/{id}")]
    public IActionResult EditPlayer(Guid id, Player player)
    {
        var existingPlayer = _playerData.GetPlayer(id);

        if (existingPlayer == null) return NotFound();
        
        player.Id = existingPlayer.Id;
        _playerData.EditPlayer(existingPlayer);
        return Ok(player);
    }
}