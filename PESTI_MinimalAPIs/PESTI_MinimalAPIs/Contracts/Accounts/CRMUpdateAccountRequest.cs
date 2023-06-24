namespace PESTI_MinimalAPIs.Contracts.Accounts;

public class CRMUpdateAccountRequest
{
    public Guid myp_UpdateAccountId { get; set; }
    public string myp_UpdateAccountName { get; set; } = string.Empty;
    public string myp_UpdateAccountPhone { get; set; } = string.Empty;
    public string myp_UpdateAccountFax { get; set; } = string.Empty;
    public string myp_UpdateAccountWebsite { get; set; } = string.Empty;
    public Guid myp_UpdateParentAccountId { get; set; }
    public string myp_UpdateAccountTicker { get; set; } = string.Empty;
    public int myp_UpdateRelationshipField { get; set; }
}