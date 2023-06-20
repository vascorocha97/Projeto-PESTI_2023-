using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        app.MapPost("/accounts", CreateAccount)
            .Accepts<AccountDto>("application/json")
            .Produces(200,typeof(AccountDto))
            .RequireAuthorization(new AuthorizeAttribute {AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme});
    }
    
    private static async Task CreateAccount(HttpContext context, IAccountService accountService, AccountMapper accountMapper)
    {
        //use StreamReader to convert the json to an AccountDto object
        var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
        var accountDto = JsonSerializer.Deserialize<AccountDto>(requestBody);

        if (accountDto == null)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid account information");
            return;
        }

        try
        {
            //create an account
            var createdAccount = accountService.CreateAccount(accountDto);
            //set response content type to json
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(createdAccount));
        }
        catch (Exception )
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("An error occurred while creating the account");
        }
    }

    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAccountService, AccountService>();
    }
}