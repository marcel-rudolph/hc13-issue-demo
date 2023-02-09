using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace NLSN.IssueDemo.Before;

[QueryType]
public static class AuthQueryResolvers
{
	public const string Issuer = "https://auth.chillicream.com";
	public const string Audience = "https://graphql.chillicream.com";
	public const string Secret = "MySuperSecretKey";

	public static string Auth()
	{
		var claims = new List<Claim>
		{
			new("sub", "me"),
		};
		var notBefore = DateTime.UtcNow.AddSeconds(1);
		var expiresAt = DateTime.UtcNow.AddHours(1);
		var issuedAt = DateTime.UtcNow;

		var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
		var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512);

		var header = new JwtHeader(signingCredentials);
		var payload = new JwtPayload(Issuer, Audience, claims, notBefore, expiresAt, issuedAt);
		var jwt = new JwtSecurityToken(header, payload);

		return new JwtSecurityTokenHandler().WriteToken(jwt);
	}
}
