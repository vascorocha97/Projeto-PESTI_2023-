using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using PESTI_MinimalAPIs.Dto;
using PESTI_MinimalAPIs.Endpoints.Internal;
using PESTI_MinimalAPIs.Helpers;
using PESTI_MinimalAPIs.Models;
using PESTI_MinimalAPIs.Services;

namespace PESTI_MinimalAPIs.Endpoints;

public class AuthEndpoints : IEndpoints
{
    public static void DefineEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("test",
            () => "This is a test request");
        
        app.MapGet("testauth", 
            [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
            () => "You are authenticated");
        
        app.MapPost("/login", Login)
            .Accepts<UserDto>("application/json")
            .Produces<string>();

        IResult Login(UserLogin user, IUserService service, IConfiguration config)
        {
            if (!string.IsNullOrEmpty(user.Email) &&
                !string.IsNullOrEmpty(user.Password))
            {
                //TODO: Replace this with proper authentication 
                var loggedInUser = service.GetUserByEmail(user);
                
                if (PasswordUtils.ValidatePassword(user.Password, loggedInUser.PasswordHash!,
                        loggedInUser.PasswordSalt))
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, loggedInUser.Id.ToString()),
                        new Claim(ClaimTypes.Email, loggedInUser.Email),
                        new Claim(ClaimTypes.GivenName, loggedInUser.Name)
                    };

                    var token = new JwtSecurityToken
                    (
                        issuer: config["Jwt:Issuer"],
                        audience: config["Jwt:Audience"],
                        claims: claims,
                        expires: DateTime.UtcNow.AddDays(60),
                        notBefore: DateTime.UtcNow,
                        signingCredentials: new SigningCredentials(
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!)),
                            SecurityAlgorithms.HmacSha256)
                    );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                    return Results.Ok(tokenString);
                }
            }
            
            return Results.BadRequest("Invalid user credentials");
        }
    }

    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserService, UserService>();
    }
}