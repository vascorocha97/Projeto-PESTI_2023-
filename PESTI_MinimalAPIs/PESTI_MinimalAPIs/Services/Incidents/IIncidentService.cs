using PESTI_MinimalAPIs.Contracts.Incidents;
using PESTI_MinimalAPIs.Models;


namespace PESTI_MinimalAPIs.Services.Incidents;

public interface IIncidentService
{
    public Task<Incident?> CreateIncident(CRMIncident crmIncident);
}