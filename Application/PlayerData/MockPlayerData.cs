using Application.Models;

namespace Application.PlayerData;

public class MockPlayerData : IPlayerData
{
    private List<Player> _players = new List<Player>()
    {
        new Player()
        {
            Id = Guid.NewGuid(),
            Name = "Luke"
        },
        new Player()
        {
            Id = Guid.NewGuid(),
            Name = "Test1"
        }
    };

    public List<Player> GetPlayers()
    {
        return _players;
    }

    public Player GetPlayer(Guid id)
    {
        return _players.SingleOrDefault(p => p.Id == id) ?? new Player();
    }

    public Player CreatePlayer(Player player)
    {
        player.Id = Guid.NewGuid();
        _players.Add(player);
        return player;
    }

    public void DeletePlayer(Player player)
    {
        _players.Remove(player);
    }

    public Player EditPlayer(Player player)
    {
        var existingPlayer = GetPlayer(player.Id);
        existingPlayer.Name = player.Name;
        return existingPlayer;
    }
}