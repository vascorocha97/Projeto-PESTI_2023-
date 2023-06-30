using PESTI_MinimalAPIs.Contracts.Incidents;
using PESTI_MinimalAPIs.Models;


namespace PESTI_MinimalAPIs.Services.Incidents;

public interface IIncidentService
{
    public Task<Incident?> CreateIncident(CRMIncident crmIncident);
    public Task<Incident?> GetIncidentById(CRMIncidentId crmIncidentId);
    public Task<Incident?> UpdateIncident(CRMUpdateIncidentRequest crmUpdateIncidentRequest);
    public Task<bool> DeleteIncident(CRMDeleteIncidentId crmIncidentId);
    public Task<List<Incident>?> GetAllIncidents();
}