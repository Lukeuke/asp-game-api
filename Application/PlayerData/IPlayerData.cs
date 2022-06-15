using Application.Models;

namespace Application.PlayerData;

public interface IPlayerData
{
    List<Player> GetPlayers();
    Player GetPlayer(Guid id);
    Player CreatePlayer(Player player);
    void DeletePlayer(Player player);
    Player EditPlayer(Player player);
}