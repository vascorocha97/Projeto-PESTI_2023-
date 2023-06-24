namespace PESTI_MinimalAPIs.Contracts.Incidents;

public class CRMUpdateIncidentRequest
{
    public Guid? myp_UpdateIncidentId { get; set; }
    public string myp_UpdateIncidentTile { get; set; } = string.Empty;
    public Guid myp_UpdateIncidentSubjectId { get; set; }
    public Guid myp_UpdateIncidentCustomerId { get; set; }
    public int myp_UpdateIncidentOrigin { get; set; }
    public Guid myp_UpdateIncidentContactId { get; set; }
    public int myp_UpdateIncidentSatisfaction { get; set; }
}