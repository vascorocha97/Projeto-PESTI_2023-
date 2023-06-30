namespace PESTI_MinimalAPIs.Contracts.Contacts;

public class CRMContactResponse
{
    public Guid? contactid { get; set; }
    public string firstname { get; set; } = string.Empty;
    public string lastname { get; set; } = string.Empty;
    public string jobtitle { get; set; } = string.Empty;
    public Guid _parentcustomerid_value { get; set; } 
    public string emailaddress1 { get; set; } = string.Empty;
    public string telephone1 { get; set; } = string.Empty;
}

public class CRMContactsResponse
{
    public string first { get; set; }
    public List<CRMContactResponse> value { get; set; }
}