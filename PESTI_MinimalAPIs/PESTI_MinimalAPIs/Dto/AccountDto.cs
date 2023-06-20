namespace PESTI_MinimalAPIs.Dto;

public class AccountDto
{
    public string Name { get; set; } = string.Empty;
    public string Telephone1 { get; set; } = string.Empty;
    public string Fax { get; set; } = string.Empty;
    public string WebsiteUrl { get; set; } = string.Empty;
    public Guid ParentAccountId { get; set; }
    public string TickerSymbol { get; set; } = string.Empty;
    public int CustomerTypeCode { get; set; }
}
