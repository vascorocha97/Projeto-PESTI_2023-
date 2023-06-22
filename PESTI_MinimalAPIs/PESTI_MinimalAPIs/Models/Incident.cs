namespace PESTI_MinimalAPIs.Models;

public class Incident
{
    public Guid? Id { get; set; }
    public string Tile { get; set; } = string.Empty;
    public Guid SubjectId { get; set; }
    public Guid CustomerId { get; set; }
    public int Origin { get; set; }
    public Guid ContactId { get; set; }
    public int Satisfaction { get; set; }
}