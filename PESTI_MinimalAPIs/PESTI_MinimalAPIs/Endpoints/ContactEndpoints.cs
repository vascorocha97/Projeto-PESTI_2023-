using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PESTI_MinimalAPIs.Contracts.Contacts;
using PESTI_MinimalAPIs.Endpoints.Internal;
using PESTI_MinimalAPIs.Mappers;
using PESTI_MinimalAPIs.Mappers.Contacts;
using PESTI_MinimalAPIs.Models;
using PESTI_MinimalAPIs.Services;
using PESTI_MinimalAPIs.Services.Contacts;

namespace PESTI_MinimalAPIs.Endpoints;

public class ContactEndpoints : IEndpoints
{
    public static void DefineEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost("/createcontact", CreateContact)
            .Accepts<Contact>("application/json")
            .Produces(200,typeof(Contact))
            .RequireAuthorization(new AuthorizeAttribute {AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme});
    }
    
    private static async Task<IResult> CreateContact(HttpContext context, IContactService contactService, CreateContactRequest createContactRequest, [FromServices] CreateContactMapper createContactMapper)
    {
        //map account to dto
        var cmrContact = createContactMapper.CreateContactRequestToCRMContact(createContactRequest);
        //create an account
        var createdContact = await contactService.CreateContact(cmrContact);
        //set response content type to json
        return Results.Ok(createdContact);
    }

    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IContactService, ContactService>();
        services.AddScoped<CreateContactMapper>();
        services.AddScoped<CRMContactMapper>();
        services.AddScoped<CRMContactResponseMapper>();
    }
}