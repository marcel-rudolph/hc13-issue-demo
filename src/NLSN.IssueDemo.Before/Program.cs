using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using NLSN.IssueDemo.Before;

var builder = WebApplication.CreateBuilder(args);

var signingKey = new SymmetricSecurityKey(
	Encoding.UTF8.GetBytes(AuthQueryResolvers.Secret)
);

builder.Services
	.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new()
		{
			ValidIssuer = AuthQueryResolvers.Issuer,
			ValidAudience = AuthQueryResolvers.Audience,
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = signingKey
		};
	});

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("ColorReadOnly", configurePolicy =>
		configurePolicy.Requirements.Add(
			new ClientPermissionsRequirement("Color", false)
		)
	);
});

builder.Services.AddSingleton<IAuthorizationHandler, ClientPermissionsHandler>();

builder.Services.AddSingleton<ColorRepository>();

builder.Services.AddGraphQLServer()
	.AddAuthorization()
	.AddTypes();

var app = builder.Build();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapGraphQL();
app.MapGet("/", context =>
{
	context.Response.Redirect("/graphql", false);
	return Task.CompletedTask;
});

app.Run();
