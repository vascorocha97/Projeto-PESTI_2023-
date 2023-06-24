using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PESTI_MinimalAPIs.Contracts.Contacts;
using PESTI_MinimalAPIs.Endpoints.Internal;
using PESTI_MinimalAPIs.Mappers;
using PESTI_MinimalAPIs.Mappers.Accounts;
using PESTI_MinimalAPIs.Mappers.Contacts;
using PESTI_MinimalAPIs.Models;
using PESTI_MinimalAPIs.Services;
using PESTI_MinimalAPIs.Services.Contacts;

namespace PESTI_MinimalAPIs.Endpoints;

public class ContactEndpoints : IEndpoints
{
    public static void DefineEndpoints(IEndpointRouteBuilder app)
    {
        //Create Contact
        app.MapPost("/createcontact", CreateContact)
            .Accepts<Contact>("application/json")
            .Produces(200,typeof(Contact))
            .RequireAuthorization(new AuthorizeAttribute {AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme});
        
        //Update Contact
        app.MapPost("/updatecontact", UpdateContact)
            .Accepts<Contact>("application/json")
            .Produces(200,typeof(Contact))
            .RequireAuthorization(new AuthorizeAttribute {AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme});
        
        //Get Contact By Id
        app.MapPost("/getcontactbyid", GetContactById)
            .Accepts<Account>("application/json")
            .Produces(200,typeof(Account))
            .RequireAuthorization(new AuthorizeAttribute {AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme});
        
        //Delete Contact
        app.MapPost("/deletecontact", DeleteContact)
            .Accepts<Account>("application/json")
            .Produces(200,typeof(Account))
            .RequireAuthorization(new AuthorizeAttribute {AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme});
    }

    private static async Task<IResult> CreateContact(HttpContext context, IContactService contactService, CreateContactRequest createContactRequest, [FromServices] CreateContactMapper createContactMapper)
    {
        var cmrContact = createContactMapper.CreateContactRequestToCRMContact(createContactRequest);
        var createdContact = await contactService.CreateContact(cmrContact);
        return Results.Ok(createdContact);
    }
    
    private static async Task<IResult> UpdateContact(HttpContext context, IContactService contactService, UpdateContactRequest updateContactRequest, [FromServices] UpdateContactMapper updateContactMapper)
    {
        var cmrContactUpdate = updateContactMapper.UpdateContactRequestToCRMUpdateContactRequest(updateContactRequest);
        var updatedContact = await contactService.UpdateContact(cmrContactUpdate);
        return Results.Ok(updatedContact);
    }
    
    private static async Task<IResult> GetContactById(HttpContext context, IContactService contactService, ContactIdRequest contactIdRequest, [FromServices] ContactIdMapper contactIdMapper)
    {
        var crmContactId = contactIdMapper.ContactIdRequestToCrmContactId(contactIdRequest);
        var account = await contactService.GetContactById(crmContactId);
        return Results.Ok(account);
    }
    
    private static async Task<IResult> DeleteContact(HttpContext context, IContactService contactService, ContactIdRequest contactIdRequest, [FromServices] DeleteContactMapper deleteContactMapper)
    {
        var crmContactId = deleteContactMapper.ContactIdRequestToCrmDeleteContactId(contactIdRequest);
        var isDeleted = await contactService.DeleteContact(crmContactId);
        return isDeleted ? Results.NoContent() : Results.NotFound("Contact not found");
    }

    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IContactService, ContactService>();
        services.AddScoped<CreateContactMapper>();
        services.AddScoped<CRMContactMapper>();
        services.AddScoped<CRMContactResponseMapper>();
        services.AddScoped<ContactIdMapper>();
        services.AddScoped<UpdateContactMapper>();
        services.AddScoped<DeleteContactMapper>();
    }
}