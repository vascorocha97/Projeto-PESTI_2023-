using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PESTI_MinimalAPIs.Dto;
using PESTI_MinimalAPIs.Endpoints.Internal;
using PESTI_MinimalAPIs.Mappers;
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
    
    private static async Task<IResult> CreateContact(HttpContext context, IContactService contactService, Contact contact, [FromServices] ContactMapper contactMapper)
    {
        //map account to dto
        var contactDto = contactMapper.ContactToDto(contact);
        //create an account
        var createdContact = await contactService.CreateContact(contactDto);
        //set response content type to json
        return Results.Ok(createdContact);
    }

    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IContactService, ContactService>();
        services.AddScoped<ContactMapper>();
    }
}