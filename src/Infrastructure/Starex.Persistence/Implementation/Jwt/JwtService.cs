using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
public class JwtService : IJwtTokenService
{
    readonly JwtSetting _jwtSettings;
    readonly UserManager<AppUser> _userManager;
    public JwtService(JwtSetting jwtSettings, UserManager<AppUser> userManager)
    {
        _jwtSettings = jwtSettings;
        _userManager = userManager;
    }
    public string JwtTokenGenerator(AppUser user)
    {
        var role = _userManager.GetRolesAsync(user).Result;
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.UserData, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.AuthenticationInstant, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Expiration, DateTime.Now.AddMinutes(_jwtSettings.ExpiryMinutes).ToString()),
        };
        foreach (var item in role)
        {
            claims.Add(new Claim(ClaimTypes.Role, item));
        }
        //IList<string> roles = await _userManager.GetRolesAsync(user);
        // claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        SigningCredentials signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding
            .UTF8.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256);
        JwtSecurityToken securityToken = new(
            claims: claims,
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: DateTime.Now.AddMinutes(_jwtSettings.ExpiryMinutes),
            signingCredentials: signingCredentials
            );
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}

