using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Models;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly Settings _settings;
    private readonly PlayerContext _playerContext;

    public AuthenticationService(Settings settings, PlayerContext playerContext)
    {
        _settings = settings;
        _playerContext = playerContext;
    }
    
    public (bool success, string content) Register(string username, string password)
    {
        if (_playerContext.Players.Any(u => u.Name == username))
            return (false, "Username not available");

        var player = new Player()
        {
            Name = username,
            Password = password
        };

        player.ProvideSaltAndHash();

        _playerContext.Add(player);
        _playerContext.SaveChanges();

        return (true, string.Empty);
    }

    public (bool success, string content) Login(string username, string password)
    {
        var player = _playerContext.Players.SingleOrDefault(p => p.Name == username);

        if (player == null) return (false, "Invalid username");

        if (player.Password != AuthenticationHelper.GenerateHash(password, player.Salt))
            return (false, "Invalid password");

        return (true, GenerateJwt(AssembleClaimsIdentity(player)));
    }

    private string GenerateJwt(ClaimsIdentity subject)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_settings.BearerKey);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = subject,
            Expires = DateTime.Now.AddMinutes(5),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private ClaimsIdentity AssembleClaimsIdentity(Player player)
    {
        var subject = new ClaimsIdentity(new[]
        {
            new Claim("id", player.Id.ToString()),
        });
        return subject;
    }
}