using Microsoft.EntityFrameworkCore;

namespace Application.Models;

public class PlayerContext : DbContext
{
    public PlayerContext(DbContextOptions<PlayerContext> options) : base(options)
    {
        
    }

    public DbSet<Player> Players { get; set; } // This is Table of Players
}