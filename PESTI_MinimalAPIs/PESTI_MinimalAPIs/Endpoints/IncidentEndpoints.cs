using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PESTI_MinimalAPIs.Contracts.Incidents;
using PESTI_MinimalAPIs.Endpoints.Internal;
using PESTI_MinimalAPIs.Mappers.Incidents;
using PESTI_MinimalAPIs.Models;
using PESTI_MinimalAPIs.Services.Incidents;

namespace PESTI_MinimalAPIs.Endpoints;

public class IncidentEndpoints : IEndpoints
{
    public static void DefineEndpoints(IEndpointRouteBuilder app)
    {
        //Create Incident
        app.MapPost("/createincident", CreateIncident)
            .Accepts<Incident>("application/json")
            .Produces(200,typeof(Incident))
            .RequireAuthorization(new AuthorizeAttribute {AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme});
        
        //Update Incident
        app.MapPost("/updateincident", UpdateIncident)
            .Accepts<Incident>("application/json")
            .Produces(200,typeof(Incident))
            .RequireAuthorization(new AuthorizeAttribute {AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme});
        
        //Get Incident By Id
        app.MapPost("/getincidentbyid", GetIncidentById)
            .Accepts<Incident>("application/json")
            .Produces(200,typeof(Incident))
            .RequireAuthorization(new AuthorizeAttribute {AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme});
        
        //Get All Incidents
        app.MapPost("/getallincidents", GetAllIncidents)
            .Accepts<Incident>("application/json")
            .Produces(200,typeof(Incident))
            .RequireAuthorization(new AuthorizeAttribute {AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme});
        
        //Delete Incident 
        app.MapPost("/deleteincident", DeleteIncident)
            .Accepts<Incident>("application/json")
            .Produces(200,typeof(Incident))
            .RequireAuthorization(new AuthorizeAttribute {AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme});
    }
    
    private static async Task<IResult> CreateIncident(HttpContext context, IIncidentService incidentService, CreateIncidentRequest createIncidentRequest, [FromServices] CreateIncidentMapper createIncidentMapper)
    {
        var crmIncident = createIncidentMapper.CreateIncidentRequestToCRMIncident(createIncidentRequest);
        var createdIncident = await incidentService.CreateIncident(crmIncident);
        return Results.Ok(createdIncident);
    }
    
    private static async Task<IResult> UpdateIncident(HttpContext context, IIncidentService incidentService, UpdateIncidentRequest updateIncidentRequest, [FromServices] UpdateIncidentMapper updateIncidentMapper)
    {
        var crmIncidentUpdate = updateIncidentMapper.UpdateIncidentRequestToCRMUpdateIncidentRequest(updateIncidentRequest);
        var updatedIncident = await incidentService.UpdateIncident(crmIncidentUpdate);
        return Results.Ok(updatedIncident);
    }
    
    private static async Task<IResult> GetIncidentById(HttpContext context, IIncidentService incidentService, IncidentIdRequest incidentIdRequest, [FromServices] IncidentIdMapper incidentIdMapper)
    {
        var crmIncidentId = incidentIdMapper.IncidentIdRequestToCrmIncidentId(incidentIdRequest);
        var incident = await incidentService.GetIncidentById(crmIncidentId);
        return Results.Ok(incident);
    }
    
    private static async Task<IResult> GetAllIncidents(HttpContext context, IIncidentService incidentService)
    {
        var accounts = await incidentService.GetAllIncidents();
        return Results.Ok(accounts);
    }
    
    private static async Task<IResult> DeleteIncident(HttpContext context, IIncidentService incidentService, IncidentIdRequest incidentIdRequest, [FromServices] DeleteIncidentMapper deleteIncidentMapper)
    {
        var crmIncidentId = deleteIncidentMapper.IncidentIdRequestToCrmDeleteIncidentId(incidentIdRequest);
        var isDeleted = await incidentService.DeleteIncident(crmIncidentId);
        return isDeleted ? Results.NoContent() : Results.NotFound("Incident not found");
    }

    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IIncidentService, IncidentService>();
        services.AddScoped<CreateIncidentMapper>();
        services.AddScoped<IncidentIdMapper>();
        services.AddScoped<UpdateIncidentMapper>();
        services.AddScoped<DeleteIncidentMapper>();
    }
}