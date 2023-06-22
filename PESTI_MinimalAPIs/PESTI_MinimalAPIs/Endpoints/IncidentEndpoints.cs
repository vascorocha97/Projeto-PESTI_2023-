using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PESTI_MinimalAPIs.Contracts.Incidents;
using PESTI_MinimalAPIs.Endpoints.Internal;
using PESTI_MinimalAPIs.Mappers.Incidents;
using PESTI_MinimalAPIs.Services.Incidents;
using Incident = PESTI_MinimalAPIs.Models.Incident;

namespace PESTI_MinimalAPIs.Endpoints;

public class IncidentEndpoints : IEndpoints
{
    public static void DefineEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost("/createincident", CreateIncident)
            .Accepts<Incident>("application/json")
            .Produces(200,typeof(Incident))
            .RequireAuthorization(new AuthorizeAttribute {AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme});
    }
    
    private static async Task<IResult> CreateIncident(HttpContext context, IIncidentService incidentService, CreateIncidentRequest createIncidentRequest, [FromServices] CreateIncidentMapper createIncidentMapper)
    {
        //map incident to dto
        var crmIncident = createIncidentMapper.CreateIncidentRequestToCRMIncident(createIncidentRequest);
        //create an incident
        var createdIncident = await incidentService.CreateIncident(crmIncident);
        return Results.Ok(createdIncident);
    }

    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IIncidentService, IncidentService>();
        services.AddScoped<CreateIncidentMapper>();
        services.AddScoped<CRMIncidentMapper>();
        services.AddScoped<CRMIncidentResponseMapper>();
    }
}