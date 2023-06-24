using System.Text.Json.Serialization;
using Newtonsoft.Json;
using PESTI_MinimalAPIs.Contracts;
using PESTI_MinimalAPIs.Contracts.Incidents;
using PESTI_MinimalAPIs.Helpers;
using PESTI_MinimalAPIs.Mappers;
using PESTI_MinimalAPIs.Mappers.Incidents;
using PESTI_MinimalAPIs.Models;
using RestSharp;

namespace PESTI_MinimalAPIs.Services.Incidents;

public class IncidentService : IIncidentService
{
    private readonly CRMIncidentResponseMapper _crmIncidentResponseMapper;
    private readonly IConfiguration _configuration;
    
    public IncidentService(IConfiguration configuration)
    {
        _configuration = configuration;
        _crmIncidentResponseMapper = new CRMIncidentResponseMapper();
    }
    public async Task<Incident?> CreateIncident(CRMIncident incidentRequest)
    {
        var accessToken = await TokenUtils.GetAccessToken(_configuration);

        var client = new RestClient(_configuration["Dynamics365:BaseUrl"]!);
        var request = new RestRequest("myp_createIncident", Method.Post);
        request.AddHeader("Authorization", "Bearer " + accessToken);
        request.AddJsonBody(incidentRequest);

        var result = await client.ExecuteAsync(request);

        if (!result.IsSuccessStatusCode) return null;
        
        var createdIncident = JsonConvert.DeserializeObject<CRMIncidentResponse>(result.Content!);
        return createdIncident is null ? null : _crmIncidentResponseMapper.CRMIncidentResponseToIncident(createdIncident);

    }

    public async Task<Incident?> GetIncidentById(CRMIncidentId crmIncidentId)
    {
        var accessToken = await TokenUtils.GetAccessToken(_configuration);

        var client = new RestClient(_configuration["Dynamics365:BaseUrl"]!);
        var request = new RestRequest("myp_getIncidentById", Method.Post);
        request.AddHeader("Authorization", "Bearer " + accessToken);
        request.AddJsonBody(crmIncidentId);

        var result = await client.ExecuteAsync(request);

        if (!result.IsSuccessStatusCode) return null;

        var incident = JsonConvert.DeserializeObject<CRMIncidentResponse>(result.Content!);
        return incident is null ? null : _crmIncidentResponseMapper.CRMIncidentResponseToIncident(incident);
    }

    public async Task<Incident?> UpdateIncident(CRMUpdateIncidentRequest crmUpdateIncidentRequest)
    {
        var accessToken = await TokenUtils.GetAccessToken(_configuration);

        var client = new RestClient(_configuration["Dynamics365:BaseUrl"]!);
        var request = new RestRequest("myp_updateIncident", Method.Post);
        request.AddHeader("Authorization", "Bearer " + accessToken);
        request.AddJsonBody(crmUpdateIncidentRequest);

        var result = await client.ExecuteAsync(request);

        if (!result.IsSuccessStatusCode) return null;
        
        var updatedIncident = JsonConvert.DeserializeObject<CRMIncidentResponse>(result.Content!);
        return updatedIncident is null ? null : _crmIncidentResponseMapper.CRMIncidentResponseToIncident(updatedIncident);
    }
}