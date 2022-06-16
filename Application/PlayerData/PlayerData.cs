using Application.Models;

namespace Application.PlayerData;

public class PlayerData : IPlayerData
{
    private readonly PlayerContext _playerContext;

    public PlayerData(PlayerContext playerContext)
    {
        _playerContext = playerContext;
    }
    
    public List<Player> GetPlayers()
    {
        return _playerContext.Players.ToList();
    }

    public Player GetPlayer(Guid id)
    {
        return _playerContext.Players.Find(id) ?? new Player();
    }

    public Player CreatePlayer(Player player)
    {
        player.Id = Guid.NewGuid();
        _playerContext.Players.Add(player);
        _playerContext.SaveChanges();
        return player;
    }

    public void DeletePlayer(Player player)
    {
        _playerContext.Players.Remove(player);
        _playerContext.SaveChanges();
    }

    public Player EditPlayer(Player player)
    {
        var existingPlayer = _playerContext.Players.Find(player.Id);

        if (existingPlayer == null) return player;

        existingPlayer.Name = player.Name;
        _playerContext.Players.Update(existingPlayer);
        _playerContext.SaveChanges();

        return player;
    }
}