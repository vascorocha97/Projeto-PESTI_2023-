using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PESTI_MinimalAPIs.Contracts.Accounts;
using PESTI_MinimalAPIs.Endpoints.Internal;
using PESTI_MinimalAPIs.Mappers.Accounts;
using PESTI_MinimalAPIs.Models;
using PESTI_MinimalAPIs.Services.Accounts;

namespace PESTI_MinimalAPIs.Endpoints;

public class AccountEndpoints : IEndpoints
{
    public static void DefineEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost("/createaccount", CreateAccount)
            .Accepts<Account>("application/json")
            .Produces(200,typeof(Account))
            .RequireAuthorization(new AuthorizeAttribute {AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme});
    }
    
    private static async Task<IResult> CreateAccount(HttpContext context, IAccountService accountService, CreateAccountRequest createAccountRequest, [FromServices] CreateAccountMapper createAccountMapper)
    {
        //map account to dto
        var crmAccount = createAccountMapper.CreateAccountRequestToCRMAccount(createAccountRequest);
        //create an account
        var createdAccount = await accountService.CreateAccount(crmAccount);
        //set response content type to json
        return Results.Ok(createdAccount);
    }

    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<CreateAccountMapper>();
        services.AddScoped<CRMAccountMapper>();
        services.AddScoped<CRMAccountResponseMapper>();
    }
}
