namespace PESTI_MinimalAPIs.Contracts.Incidents;

public class CRMIncident
{
    public string myp_IncidentTitle { get; set; } = string.Empty;
    public Guid myp_IncidentSubjectId { get; set; }
    public Guid myp_IncidentCustomerId { get; set; }
    public int myp_IncidentOrigin { get; set; }
    public Guid myp_IncidentContactId { get; set; }
    public int myp_IncidentSatisfaction { get; set; }
}