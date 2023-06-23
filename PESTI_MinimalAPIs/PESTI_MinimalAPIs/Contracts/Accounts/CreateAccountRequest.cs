namespace PESTI_MinimalAPIs.Contracts.Accounts;

public class CreateAccountRequest
{
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Fax { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public Guid ParentAccount { get; set; }
    public string Ticker { get; set; } = string.Empty;
    public int RelationshipField { get; set; }
}