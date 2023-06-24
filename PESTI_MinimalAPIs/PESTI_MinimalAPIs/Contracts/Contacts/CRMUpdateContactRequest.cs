namespace PESTI_MinimalAPIs.Contracts.Contacts;

public class CRMUpdateContactRequest
{
    public Guid? myp_UpdateContactId { get; set; }
    public string myp_UpdateConctactFirstName { get; set; } = string.Empty;
    public string myp_UpdateConctactLastName { get; set; } = string.Empty;
    public string myp_UpdateConctactJobTitle { get; set; } = string.Empty;
    public Guid myp_UpdateContactAccountId { get; set; } 
    public string myp_UpdateContactEmail { get; set; } = string.Empty;
    public string myp_UpdateContactPhone { get; set; } = string.Empty;
}