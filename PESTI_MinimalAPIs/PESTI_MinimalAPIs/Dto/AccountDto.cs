namespace PESTI_MinimalAPIs.Dto;

public class AccountDto
{
    public string myp_AccountName { get; set; } = string.Empty;
    public string myp_AccountPhone { get; set; } = string.Empty;
    public string myp_AccountFax { get; set; } = string.Empty;
    public string myp_AccountWebsite { get; set; } = string.Empty;
    public Guid myp_ParentAccountId { get; set; }
    public string myp_AccountTicker { get; set; } = string.Empty;
    public int myp_RelationshipField { get; set; }
}
