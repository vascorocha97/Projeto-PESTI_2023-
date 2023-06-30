namespace PESTI_MinimalAPIs.Contracts.Accounts;

public class CRMAccountResponse
{
    public Guid? accountid { get; set; }
    public string name { get; set; } = string.Empty;
    public string telephone1 { get; set; } = string.Empty;
    public string fax { get; set; } = string.Empty;
    public string websiteurl { get; set; } = string.Empty;
    public Guid _parentaccountid_value { get; set; }
    public string tickersymbol { get; set; } = string.Empty;
    public int customertypecode { get; set; }
}

public class CRMAccountsResponse
{
    public string first { get; set; }
    public List<CRMAccountResponse> value { get; set; }
}