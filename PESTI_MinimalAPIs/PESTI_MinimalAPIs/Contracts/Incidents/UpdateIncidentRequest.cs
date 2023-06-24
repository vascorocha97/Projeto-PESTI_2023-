namespace PESTI_MinimalAPIs.Contracts.Incidents;

public class UpdateIncidentRequest
{
    public Guid? Id { get; set; }
    public string Tile { get; set; } = string.Empty;
    public Guid SubjectId { get; set; }
    public Guid CustomerId { get; set; }
    public int Origin { get; set; }
    public Guid ContactId { get; set; }
    public int Satisfaction { get; set; }
}