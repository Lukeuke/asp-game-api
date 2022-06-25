using Application.DTO;
using Application.Models;

namespace Application.Services;

public class FinishService : IFinishService
{
    private readonly PlayerContext _playerContext;

    public FinishService(PlayerContext playerContext)
    {
        _playerContext = playerContext;
    }
    
    public void AddToDb(FinishRequestDto finishRequestDto)
    {
        var player = _playerContext.Players.FirstOrDefault(x => x.Id == finishRequestDto.Id);
        player.WonCount++;
        player.TotalMoneyWon += 100;
        _playerContext.SaveChanges();
    }
}