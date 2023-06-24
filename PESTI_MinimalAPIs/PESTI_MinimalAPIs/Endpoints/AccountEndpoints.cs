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
        //Create New Account
        app.MapPost("/createaccount", CreateAccount)
            .Accepts<Account>("application/json")
            .Produces(200,typeof(Account))
            .RequireAuthorization(new AuthorizeAttribute {AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme});
        
        //Update Account
        app.MapPost("/updateaccount", UpdateAccount)
            .Accepts<Account>("application/json")
            .Produces(200,typeof(Account))
            .RequireAuthorization(new AuthorizeAttribute {AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme});
        
        //Get All Accounts
        app.MapPost("/getallaccounts", GetAllAccounts)
            .Accepts<Account>("application/json")
            .Produces(200,typeof(Account))
            .RequireAuthorization(new AuthorizeAttribute {AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme});
        
        //Get Account By Id
        app.MapPost("/getaccountbyid", GetAccountById)
            .Accepts<Account>("application/json")
            .Produces(200,typeof(Account))
            .RequireAuthorization(new AuthorizeAttribute {AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme});
    }
    
    private static async Task<IResult> CreateAccount(HttpContext context, IAccountService accountService, CreateAccountRequest createAccountRequest, [FromServices] CreateAccountMapper createAccountMapper)
    {
        var crmAccount = createAccountMapper.CreateAccountRequestToCRMAccount(createAccountRequest);
        var createdAccount = await accountService.CreateAccount(crmAccount);
        return Results.Ok(createdAccount);
    }
    
    private static async Task<IResult> UpdateAccount(HttpContext context, IAccountService accountService, UpdateAccountRequest updateAccountRequest, [FromServices] UpdateAccountMapper updateAccountMapper)
    {
        var crmAccountUpdate = updateAccountMapper.UpdateAccountRequestToCRMUpdateAccountRequest(updateAccountRequest);
        var updatedAccount = await accountService.UpdateAccount(crmAccountUpdate);
        return Results.Ok(updatedAccount);
    }
    
    private static async Task<IResult> GetAllAccounts(HttpContext context, IAccountService accountService)
    {
        var accounts = await accountService.GetAllAccounts();
        return Results.Ok(accounts);
    }
    
    private static async Task<IResult> GetAccountById(HttpContext context, IAccountService accountService, AccountIdRequest accountIdRequest, [FromServices] AccountIdMapper accountIdMapper)
    {
        var crmAccountId = accountIdMapper.AccountIdRequestToCrmAccountId(accountIdRequest);
        var account = await accountService.GetAccountById(crmAccountId);
        return Results.Ok(account);
    }

    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<CreateAccountMapper>();
        services.AddScoped<CRMAccountMapper>();
        services.AddScoped<CRMAccountResponseMapper>();
        services.AddScoped<AccountIdMapper>();
        services.AddScoped<UpdateAccountMapper>();
    }
}
