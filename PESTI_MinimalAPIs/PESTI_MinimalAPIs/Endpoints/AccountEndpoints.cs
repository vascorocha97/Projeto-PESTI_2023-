using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PESTI_MinimalAPIs.Dto;
using PESTI_MinimalAPIs.Endpoints.Internal;
using PESTI_MinimalAPIs.Mappers;
using PESTI_MinimalAPIs.Models;
using PESTI_MinimalAPIs.Services.Accounts;

namespace PESTI_MinimalAPIs.Endpoints;

public class AccountEndpoints : IEndpoints
{
    public static void DefineEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost("/createaccount", CreateAccount)
            .Accepts<AccountDto>("application/json")
            .Produces(200,typeof(AccountDto))
            .RequireAuthorization(new AuthorizeAttribute {AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme});
    }
    
    private static async Task<IResult> CreateAccount(HttpContext context, IAccountService accountService, Account account, [FromServices] AccountMapper accountMapper)
    {
        //map account to dto
        var accountDto = accountMapper.AccountToDto(account);
        //create an account
        var createdAccount = await accountService.CreateAccount(accountDto);
        //set response content type to json
        return Results.Ok(createdAccount);
    }

    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<AccountMapper>();
    }
}
